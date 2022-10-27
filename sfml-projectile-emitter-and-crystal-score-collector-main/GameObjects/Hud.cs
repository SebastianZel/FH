using SFML.System;
using SFML.Graphics;
using SFML.Window;
using Game_Assets;
using Game_Input;

namespace GameObjects
{
    class Hud : GameObject
    {
        protected Font _font;
        protected Text _text;

        public override void Initialize()
        {
            if (!AssetManager.Instance.Fonts.ContainsKey("arial"))
            {
                AssetManager.Instance.LoadFont("arial", @".\assets\arial.ttf");
            }
            _font = AssetManager.Instance.Fonts["arial"];
            _text = new Text();
            _text.Font = _font;
            _text.OutlineColor = Color.Black;
            _text.OutlineThickness = 3;
        }

        public override void Update(float deltaTime)
        {
            
        }

        public override void Draw(RenderWindow window)
        {
            window.Draw(_text);
        }

        public override void SetPosition(Vector2f position)
        {
           _text.Position = position;
        }

        protected override void SetCollisionRect()
        {
            
        }

        public void UpdateText(string text)
        {
            _text.DisplayedString = text;
        }

        public void SetText(Vector2f position, string text, uint size)
        {
           SetPosition(position);
           _text.DisplayedString = text;
           _text.CharacterSize = size;
        }
    }
}