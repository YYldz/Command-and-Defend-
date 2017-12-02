using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Proj5_byYakupY
{
    class Button
    {
        Vector2 position;
        Texture2D texture;
        Point size;
        Rectangle buttonRectangle;

        public Button(Vector2 position, Texture2D texture, Point size)
        {
            this.position = position;
            this.texture = texture;
            this.size = size;
            buttonRectangle = new Rectangle(
                (int)position.X, (int)position.Y, size.X, size.Y);
        }

        public void Update(GameTime gameTime) { }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, buttonRectangle, Color.White);
        }

        public bool MouseInside(Vector2 mousePosition)
        {
            if (buttonRectangle.Contains((int)mousePosition.X, (int)mousePosition.Y))
            {
                return true;
            }
            return false;
        }
    }
}
