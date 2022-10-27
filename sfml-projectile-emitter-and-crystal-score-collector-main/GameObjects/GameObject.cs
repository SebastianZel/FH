using SFML.System;
using SFML.Graphics;

namespace GameObjects
{
    internal abstract class GameObject : Transformable
    {
        protected const int ANIMATIONSPEED = 8;
        protected Texture _texture;
        protected Sprite _sprite;
        public IntRect collisionRect { get; protected set; }
        /*
        Guide to collisionRect
        To make a collisionRect, you will use the global bounds of the sprite
        However usually you will want to make the collisionRect smaller than the bounds
        To properly place and calculate the POSITION of the rect, follow these instructions:
        You should at all times reduce the width/height of the collisionRect with a fractional number (e.g 2/3, 4/5 etc.)
        If you set the Width to 2/3 of the Bounds Width, you will have to add the HALF of the REMAING FRACTION to IntRect.Left
        so e.g. _sprite.GetGlobalBounds.Width*2/3 --> _sprite.GetGlobalBounds.Left + (_sprite.GetGlobalBounds().Width*1/3)/2
        same pattern applies to Height/Top
        this way the IntRect's "imaginary" origin will be the same as the sprite's origin
        A complete example:
          collisionRect = new((int)_sprite.GetGlobalBounds().Left+((int)_sprite.GetGlobalBounds().Width*1/3)/2, (int)_sprite.GetGlobalBounds().Top + ((int)_sprite.GetGlobalBounds().Height*1/3)/2,
          (int)_sprite.GetGlobalBounds().Width*2/3, (int)_sprite.GetGlobalBounds().Height*2/3);
        WARNING: Rect can't rotate
        */
        protected abstract void SetCollisionRect();
        public abstract void Initialize();
        public abstract void Update(float deltaTime);
        public abstract void Draw(RenderWindow window);
        public abstract void SetPosition(Vector2f position);
        public void SetRotation(float rotation)
        {
           _sprite.Rotation = rotation;
        }
        public void DrawRectOutline(RenderWindow window, Vector2f position, int width, int height, Color color)
        {
            RectangleShape rectangle = new RectangleShape(new Vector2f(width, height));
            rectangle.Origin = new Vector2f(width/2, height/2);
            rectangle.Position = position;
            rectangle.FillColor = Color.Transparent;
            rectangle.OutlineColor = color;
            rectangle.OutlineThickness = 2;
            window.Draw(rectangle);
        }

        public void DrawLine(RenderWindow window, Vector2f startPoint, Vector2f endPoint, Color color)
        {
            Vertex[] line = { new(startPoint, color), new(endPoint, color) };
            window.Draw(line, 0, 2, PrimitiveType.Lines);
        }

        public void DrawRectOutlineWithLine(RenderWindow window, Vector2f position, int width, int height, Color color)
        {
            var bottomLeftPos = new Vector2f(position.X, position.Y + height);
            var TopLeftPos = new Vector2f(position.X, position.Y);
            var TopRightPos = new Vector2f(position.X + width, position.Y);
            var BottomRightPos = new Vector2f(position.X + width, position.Y + height);

            Vertex[] line = { new(bottomLeftPos, color), new(TopLeftPos, color) };
            window.Draw(line, 0, 2, PrimitiveType.Lines);

            line = new[] { new(TopLeftPos, color), new Vertex(TopRightPos, color) };
            window.Draw(line, 0, 2, PrimitiveType.Lines);

            line = new[] { new(TopRightPos, color), new Vertex(BottomRightPos, color) };
            window.Draw(line, 0, 2, PrimitiveType.Lines);

            line = new[] { new(BottomRightPos, color), new Vertex(bottomLeftPos, color) };
            window.Draw(line, 0, 2, PrimitiveType.Lines);
        }
    }
}