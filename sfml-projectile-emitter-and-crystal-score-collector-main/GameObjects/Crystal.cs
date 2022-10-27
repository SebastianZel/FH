using SFML.System;
using SFML.Graphics;
using Game_Assets;
using Game_Utils;

namespace GameObjects
{
    class Crystal : GameObject
    {
        public override void Initialize()
        {
            if (!AssetManager.Instance.Textures.ContainsKey("crystal"))
            {
                AssetManager.Instance.LoadTexture("crystal", @".\assets\crystal.png");
            }
            _texture = AssetManager.Instance.Textures["crystal"];

            _sprite = new Sprite(_texture);
            _sprite.Origin = new Vector2f(_sprite.TextureRect.Width/2, _sprite.TextureRect.Height/2);
            _sprite.Scale = new Vector2f(0.09f, 0.09f);
        }

        public override void Update(float deltaTime)
        {
            SetCollisionRect();
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
           SetCollisionRect();
        }

        protected override void SetCollisionRect()
        {
            collisionRect = new((int)_sprite.GetGlobalBounds().Left, (int)_sprite.GetGlobalBounds().Top + ((int)_sprite.GetGlobalBounds().Height/6)/2,
            (int)_sprite.GetGlobalBounds().Width, (int)_sprite.GetGlobalBounds().Height*5/6);
        }
    }
}