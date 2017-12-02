using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;

namespace Proj5_byYakupY
{
    class Pillbox : Building    
    {
        
        public Pillbox(Texture2D texture, Texture2D hpTexture,
                        Vector2 position)
                        : base(texture,hpTexture ,position)
        {
            this.damage = 40;
            range = 175;
            timerValue = 500;
            spriteRec = new Rectangle(0, 0, 55, 44);
            cost = 500;
            
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

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture,new Rectangle(
                (int)position.X, (int)position.Y,
                    size.X, size.Y), spriteRec, BuildingColor,
                    0f, Vector2.Zero, 
                    SpriteEffects.None, 1f);
        }

    }
}