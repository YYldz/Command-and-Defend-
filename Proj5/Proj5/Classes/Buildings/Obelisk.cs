using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Proj5_byYakupY
{
    class Obelisk : Building
    {
        GraphicsDevice graphics;
        public Obelisk(Texture2D texture, Texture2D hpTexture,
                        Vector2 position, GraphicsDevice graphics)
            : base(texture, hpTexture, position)
        {
            this.damage = 2000;
            range = 500;
            timerValue = 3000;
            spriteRec = new Rectangle(0, 0, 154, 215);
            cost = 1500;
            this.graphics = graphics;
        }

        public override void Update(GameTime gameTime)
        {
            shootTimer -= gameTime.ElapsedGameTime.Milliseconds;

            center.X = position.X;
            center.Y = position.Y;


            if (shootTimer <= 0)
                Attack();
                
            base.Update(gameTime);
        }

        // 550, 400, 660, 500

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, new Rectangle(
                (int)position.X, (int)position.Y,
                    size.X, size.Y), spriteRec, BuildingColor,
                    0f, Vector2.Zero,
                    SpriteEffects.None, 1f);
        }



        public void DrawLine(SpriteBatch spriteBatch, Vector2 start, Vector2 end)
        {
            spriteBatch = new SpriteBatch(graphics);
            Vector2 edge = end - start;

            float angle =
                (float)Math.Atan2(edge.X, edge.Y);
            spriteBatch.Begin();
            spriteBatch.Draw(TextureManager.Dot,
                new Rectangle((int)start.X - TextureManager.Dot.Width / 2,
                              (int)start.Y,
                              (int)edge.Length(), 1),
                              null, Color.Red,
                              angle, new Vector2(0, 0),
                              SpriteEffects.None, 1);
            spriteBatch.End();
        }
    }
}
