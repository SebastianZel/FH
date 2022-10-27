using System;
using SFML.System;
using SFML.Graphics;
using SFML.Window;
using Game_Assets;
using Game_Input;

namespace GameObjects
{
    partial class Player : GameObject
    {
        protected const int SPEED = 250;
        protected const int PLAYER_TILING_X = 10;
        protected const int PLAYER_TILING_Y = 8;
        float animationTime;
        int animationFrame;
        int maxFrames;
        int[] PlayerAnimationTypeFramesCount = new int[] {
            3,
            3,
            1,
            3,
            10,
            10,
            10,
            10
        };
        PlayerAnimationType currentAnimation;

        public override void Initialize()
        {
            AssetManager.Instance.LoadTexture("player", @".\assets\playerSpriteSheet.png");
            _texture = AssetManager.Instance.Textures["player"];

            _sprite = new Sprite(_texture);
            _sprite.TextureRect = new(0, 0, _sprite.TextureRect.Width/PLAYER_TILING_X, _sprite.TextureRect.Height/PLAYER_TILING_Y);
            _sprite.Origin = new Vector2f(_sprite.TextureRect.Width/2, _sprite.TextureRect.Height/2);
            _sprite.Scale = new Vector2f(2f, 2f);
            maxFrames = PlayerAnimationTypeFramesCount[0]; //Idle Down Frames - IF YOU CHANGE YOUR TextureRect YOU MUST UPDATE THIS APPROPRIATELY
        }

        public override void Update(float deltaTime)
        {
            PlayerMovement(deltaTime);
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
        }

        protected override void SetCollisionRect()
        {
            collisionRect = new((int)_sprite.GetGlobalBounds().Left+((int)_sprite.GetGlobalBounds().Width/5)/2, (int)_sprite.GetGlobalBounds().Top,
            (int)_sprite.GetGlobalBounds().Width*4/5, (int)_sprite.GetGlobalBounds().Height);
        }

        private void PlayerMovement(float deltaTime)
        {
            //Moving
            if (InputManager.Instance.GetKeyPressed(Keyboard.Key.W))
            {
                currentAnimation = PlayerAnimationType.RunUp;

                _sprite.Position += new Vector2f(0, -1) * SPEED * deltaTime;
            }
            else if (InputManager.Instance.GetKeyPressed(Keyboard.Key.A))
            {
                currentAnimation = PlayerAnimationType.RunLeft;

                _sprite.Position += new Vector2f(-1, 0) * SPEED * deltaTime;
            }
            else if (InputManager.Instance.GetKeyPressed(Keyboard.Key.D))
            {
                currentAnimation = PlayerAnimationType.RunRight;

                _sprite.Position += new Vector2f(1, 0) * SPEED * deltaTime;
            }
            else if (InputManager.Instance.GetKeyPressed(Keyboard.Key.S))
            {
                currentAnimation = PlayerAnimationType.RunDown;

                _sprite.Position += new Vector2f(0, 1) * SPEED * deltaTime;
            }

            //Idle
            if (InputManager.Instance.GetKeyUp(Keyboard.Key.W))
            {
                currentAnimation = PlayerAnimationType.IdleUp;
            }
            else if (InputManager.Instance.GetKeyUp(Keyboard.Key.A))
            {
                currentAnimation = PlayerAnimationType.IdleLeft;
            }
            else if (InputManager.Instance.GetKeyUp(Keyboard.Key.D))
            {
                currentAnimation = PlayerAnimationType.IdleRight;
            }
            else if (InputManager.Instance.GetKeyUp(Keyboard.Key.S))
            {
                currentAnimation = PlayerAnimationType.IdleDown;
            }

            maxFrames = PlayerAnimationTypeFramesCount[(int)currentAnimation];

            PlayerAnimation(deltaTime, currentAnimation);
        }

        private void PlayerAnimation(float deltaTime, PlayerAnimationType currentAnimation)
        {
            animationTime += deltaTime * ANIMATIONSPEED;
            animationFrame = (int)animationTime % maxFrames;

            int animationPosX = animationFrame * _sprite.TextureRect.Width;
            int animationPosY = (int)currentAnimation * _sprite.TextureRect.Height;

            _sprite.TextureRect = new IntRect(animationPosX, animationPosY, _sprite.TextureRect.Width, _sprite.TextureRect.Height);
        }
    }
}