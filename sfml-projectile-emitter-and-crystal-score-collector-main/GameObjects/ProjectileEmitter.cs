using System.Collections.Generic;
using SFML.System;
using SFML.Graphics;
using Game_Assets;
using Game_Utils;

namespace GameObjects
{
    class ProjectileEmitter : GameObject
    {
        Projectile projectile1_1 = new Projectile();
        Projectile projectile1_2 = new Projectile();
        Projectile projectile1_3 = new Projectile();
        Projectile projectile1_4 = new Projectile();
        List<Projectile> projectiles_1 = new List<Projectile>();
        List<Projectile> projectiles_1_spawns = new List<Projectile>();
        Projectile projectile2_1 = new Projectile();
        Projectile projectile2_2 = new Projectile();
        Projectile projectile2_3 = new Projectile();
        Projectile projectile2_4 = new Projectile();
        List<Projectile> projectiles_2 = new List<Projectile>();
        List<Projectile> projectiles_2_spawns = new List<Projectile>();
        public List<Projectile> projectilesAll { get; private set; }
        List<Vector2f> points = new();
        enum Directions
        {
            Up,
            Down,
            Left,
            Right
        }
        static float timeElapsed;
        static float delay = 2f;
        static float delayMultiplier = 2.5f;

        public override void Initialize()
        {
            if (!AssetManager.Instance.Textures.ContainsKey("skull"))
            {
                AssetManager.Instance.LoadTexture("skull", @".\assets\skull.png");
            }
            _texture = AssetManager.Instance.Textures["skull"];

            _sprite = new Sprite(_texture);
            _sprite.Origin = new Vector2f(_sprite.TextureRect.Width/2, _sprite.TextureRect.Height/2);
            _sprite.Scale = new Vector2f(0.25f, 0.25f);

            projectilesAll = new List<Projectile>();
            projectilesAll.Add(projectile1_1);
            projectilesAll.Add(projectile1_2);
            projectilesAll.Add(projectile1_3);
            projectilesAll.Add(projectile1_4);
            projectilesAll.Add(projectile2_1);
            projectilesAll.Add(projectile2_2);
            projectilesAll.Add(projectile2_3);
            projectilesAll.Add(projectile2_4);
            
            projectiles_1.Add(projectile1_1);
            projectiles_1.Add(projectile1_2);
            projectiles_1.Add(projectile1_3);
            projectiles_1.Add(projectile1_4);
            projectiles_2.Add(projectile2_1);
            projectiles_2.Add(projectile2_2);
            projectiles_2.Add(projectile2_3);
            projectiles_2.Add(projectile2_4);
        }

        public override void Update(float deltaTime)
        {
            SetCollisionRect();

            timeElapsed += deltaTime;
            if (timeElapsed > delay)
            {
                foreach (var projectile in projectiles_1_spawns)
                {
                    projectile.Update(deltaTime);
                }
            }
            if (timeElapsed > delay * delayMultiplier)
            {
                foreach (var projectile in projectiles_2_spawns)
                {
                    projectile.Update(deltaTime);
                }
            }
        }

        public override void Draw(RenderWindow window)
        {
            window.Draw(_sprite);
            if (timeElapsed > delay)
            {
                foreach (var projectile in projectiles_1_spawns)
                {
                    projectile.Draw(window);
                }
            }
            if (timeElapsed > delay * delayMultiplier)
            {
                foreach (var projectile in projectiles_2_spawns)
                {
                    projectile.Draw(window);
                }
            }
            DrawRectOutline(window, _sprite.Position, (int)_sprite.GetGlobalBounds().Width, (int)_sprite.GetGlobalBounds().Height, Color.Red);
            DrawRectOutlineWithLine(window, new Vector2f(collisionRect.Left, collisionRect.Top), (int)collisionRect.Width, (int)collisionRect.Height, Color.Green);
        }
        
        //this version is obsolute, use EmitterSettings instead
        public override void SetPosition(Vector2f position)
        {
            _sprite.Position = position;

            foreach (var projectile in projectilesAll)
            {
                projectile.Initialize();
                projectile.SetPosition(_sprite.Position);
            }
            
            float travelDistance = 750;
            points.Add(new Vector2f(_sprite.Position.X, _sprite.Position.Y - travelDistance));      //Point Up
            points.Add(new Vector2f(_sprite.Position.X + travelDistance, _sprite.Position.Y));      //Point Right
            points.Add(new Vector2f(_sprite.Position.X, _sprite.Position.Y + travelDistance));      //Point Down
            points.Add(new Vector2f(_sprite.Position.X - travelDistance, _sprite.Position.Y));      //Point Left

            for (int i = 0; i < projectiles_1.Count; i++)
            {
                projectiles_1[i].SetPath(_sprite.Position, points[i]);
                projectiles_1[i].SetRotation(Utils.AngleBetween(_sprite.Position, points[i]));
                projectiles_2[i].SetPath(_sprite.Position, points[i]);
                projectiles_2[i].SetRotation(Utils.AngleBetween(_sprite.Position, points[i]));
            }
        }

        public void EmitterSettings(Vector2f position, int speed, bool up, bool right, bool down, bool left)
        {
            _sprite.Position = position;
            int range = 0;
            if(up)
            {
                range++;
            }
            if(right)
            {
                range++;
            }
            if(down)
            {
                range++;
            }
            if(left)
            {
                range++;
            }
            
            for(int i = 0; i < range; i++)
            {
                projectiles_1_spawns.Add(projectiles_1[i]);
                projectiles_2_spawns.Add(projectiles_2[i]);
            }
            foreach (var projectile in projectiles_1_spawns)
            {
                projectile.Initialize();
                projectile.SetPosition(_sprite.Position);
                projectile.SetSpeed(speed);
            }
            foreach (var projectile in projectiles_2_spawns)
            {
                projectile.Initialize();
                projectile.SetPosition(_sprite.Position);
                projectile.SetSpeed(speed);
            }
            
            float travelDistance = 700;
            points.Add(new Vector2f(_sprite.Position.X, _sprite.Position.Y - travelDistance));      //Point Up
            points.Add(new Vector2f(_sprite.Position.X + travelDistance, _sprite.Position.Y));      //Point Right
            points.Add(new Vector2f(_sprite.Position.X, _sprite.Position.Y + travelDistance));      //Point Down
            points.Add(new Vector2f(_sprite.Position.X - travelDistance, _sprite.Position.Y));      //Point Left

            for (int i = 0; i < projectiles_1_spawns.Count; i++)
            {
                //order matters, must begin from bottom i.e. left here
                if(left)
                {
                    left = false;
                    projectiles_1_spawns[i].SetPath(_sprite.Position, points[3]);
                    projectiles_1_spawns[i].SetRotation(Utils.AngleBetween(_sprite.Position, points[3]));
                    projectiles_2_spawns[i].SetPath(_sprite.Position, points[3]);
                    projectiles_2_spawns[i].SetRotation(Utils.AngleBetween(_sprite.Position, points[3]));
                }
                else if(down)
                {
                    down = false;
                    projectiles_1_spawns[i].SetPath(_sprite.Position, points[2]);
                    projectiles_1_spawns[i].SetRotation(Utils.AngleBetween(_sprite.Position, points[2]));
                    projectiles_2_spawns[i].SetPath(_sprite.Position, points[2]);
                    projectiles_2_spawns[i].SetRotation(Utils.AngleBetween(_sprite.Position, points[2]));
                }
                else if(right)
                {
                    right = false;
                    projectiles_1_spawns[i].SetPath(_sprite.Position, points[1]);
                    projectiles_1_spawns[i].SetRotation(Utils.AngleBetween(_sprite.Position, points[1]));
                    projectiles_2_spawns[i].SetPath(_sprite.Position, points[1]);
                    projectiles_2_spawns[i].SetRotation(Utils.AngleBetween(_sprite.Position, points[1]));
                }
                else if(up)
                {
                    up = false;
                    projectiles_1_spawns[i].SetPath(_sprite.Position, points[0]);
                    projectiles_1_spawns[i].SetRotation(Utils.AngleBetween(_sprite.Position, points[0]));
                    projectiles_2_spawns[i].SetPath(_sprite.Position, points[0]);
                    projectiles_2_spawns[i].SetRotation(Utils.AngleBetween(_sprite.Position, points[0]));
                }
            }
        }

        protected override void SetCollisionRect()
        {
            collisionRect = new((int)_sprite.GetGlobalBounds().Left+((int)_sprite.GetGlobalBounds().Width/4)/2, (int)_sprite.GetGlobalBounds().Top+((int)_sprite.GetGlobalBounds().Height/4)/2,
            (int)_sprite.GetGlobalBounds().Width*3/4, (int)_sprite.GetGlobalBounds().Height*3/4);
        }
    }
}