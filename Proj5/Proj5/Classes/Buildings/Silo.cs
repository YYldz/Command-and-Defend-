using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;

namespace Proj5_byYakupY
{
    class Silo : Building
    {
        double credTimer;

        SoundEffectInstance crd;

        public Silo(Texture2D texture, Texture2D hpTexture,
                    Vector2 position)
            : base(texture, hpTexture, position)
        {
            spriteRec = new Rectangle(0, 0, 48, 24);
            size = new Point(50, 35);
            credTimer = 2000;
            cost = 300;
            crd = MediaHandler.CreditPlus.CreateInstance();
        }

        public override void Update(GameTime gameTime)
        {
            credTimer -= gameTime.ElapsedGameTime.Milliseconds;

            if (credTimer <= 0)
            {
                Constants.Credits += 15;
                credTimer = 2000;
                crd.Play();
            }

            base.Update(gameTime);
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, new Rectangle(
                (int)position.X, (int)position.Y,
                    size.X, size.Y), spriteRec, BuildingColor,
                    0f, Vector2.Zero,
                    SpriteEffects.None, 1f);
        }
    }
}
