using System;
using SFML.System;
using SFML.Graphics;
using SFML.Audio;
using Game_Assets;
using Game_Utils;

namespace GameObjects
{
    class Projectile : GameObject
    {
        const int PROJECTILE_TILING_X = 6;
        const int PROJECTILE_TILING_Y = 1;
        int speed = 225;
        float animationTime;
        int animationFrame;
        int maxFrames;
        int[] animationTypeFramesCount = new int[] {
            6
        };
        FireAnimationType currentAnimation = FireAnimationType.Fire;
        Vector2f moveVector;
        Vector2f nextPointVector;
        Vector2f start;
        Vector2f end;
        Sound fireSound;

        public override void Initialize()
        {
            if (!AssetManager.Instance.Sounds.ContainsKey("fire"))
            {
                AssetManager.Instance.LoadSound("fire", @".\assets\fire.wav");
            }
            fireSound = AssetManager.Instance.Sounds["fire"];
            fireSound.Volume = 10f;

            if (!AssetManager.Instance.Textures.ContainsKey("projectile"))
            {
                AssetManager.Instance.LoadTexture("projectile", @".\assets\projectile.png");
            }
            _texture = AssetManager.Instance.Textures["projectile"];

            _sprite = new Sprite(_texture);
            _sprite.TextureRect = new(0, 0, _sprite.TextureRect.Width/PROJECTILE_TILING_X, _sprite.TextureRect.Height/PROJECTILE_TILING_Y);
            _sprite.Origin = new Vector2f(_sprite.TextureRect.Width/2, _sprite.TextureRect.Height/2);
            _sprite.Scale = new Vector2f(0.19f, 0.19f);
            maxFrames = animationTypeFramesCount[0];
        }

        public override void Update(float deltaTime)
        {
            Fire(deltaTime, start, end);
            SetCollisionRect();
            ProjectileAnimation(deltaTime);
        }

        public override void Draw(RenderWindow window)
        {
            window.Draw(_sprite);
            DrawRectOutline(window, _sprite.Position, (int)_sprite.GetGlobalBounds().Width, (int)_sprite.GetGlobalBounds().Height, Color.Red);
            DrawRectOutlineWithLine(window, new Vector2f(collisionRect.Left, collisionRect.Top), (int)collisionRect.Width, (int)collisionRect.Height, Color.Green);
        }

        public override void SetPosition(Vector2f position)
        {
           _sprite.Position = position;
        }

        protected override void SetCollisionRect()
        {
            collisionRect = new((int)_sprite.GetGlobalBounds().Left + ((int)_sprite.GetGlobalBounds().Width/2)/2, (int)_sprite.GetGlobalBounds().Top + ((int)_sprite.GetGlobalBounds().Height/2)/2,
            (int)_sprite.GetGlobalBounds().Width/2, (int)_sprite.GetGlobalBounds().Height/2);
        }

        internal void SetSpeed(int spd)
        {
           speed = spd;
        }

        public void SetPath(Vector2f startVector, Vector2f endVector)
        {
           start = startVector;
           end = endVector;
        }

        /*
        Fire() Method written so that the projectile upon reaching the end gets put right back at its starting point
        that way the projectile basically loops the same assigned distance
        this is tied to how i wanted the ProjectileEmiter to work
        */
        private void Fire(float deltaTime, Vector2f start, Vector2f end)
        {
            if(_sprite.Position == start)
            {
                fireSound.Play(); //This sound doesn't play without the if-condition
            }
            nextPointVector = end - _sprite.Position;

            if (nextPointVector.SqrMagnitude() < 5f)
            {
                _sprite.Position = start;
                fireSound.Play();
            }

            moveVector = nextPointVector.Normalize() * speed * deltaTime;
            _sprite.Position += moveVector;
        }

        private void ProjectileAnimation(float deltaTime)
        {
            animationTime += deltaTime * ANIMATIONSPEED;
            animationFrame = (int)animationTime % maxFrames;

            int animationPosX = animationFrame * _sprite.TextureRect.Width;
            int animationPosY = (int)currentAnimation * _sprite.TextureRect.Height;

            _sprite.TextureRect = new IntRect(animationPosX, animationPosY, _sprite.TextureRect.Width, _sprite.TextureRect.Height);
        }
    }
}