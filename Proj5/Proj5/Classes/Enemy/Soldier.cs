using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Proj5_byYakupY
{
    class Soldier : Enemy
    {
        public Soldier(Texture2D texture, Texture2D hpTexture,
                        Vector2 position)
            : base(texture, hpTexture, position)
        {
            speed = 1f;
            spriteRec = new Rectangle(0, 0, 266, 248);
            this.health = 240;
            this.spawnHealth = health;
            val = 15;
            
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, EnemyBoundingBox,
                spriteRec, Color.White, 0f, new Vector2(
                                texture.Width / 2, texture.Height / 2),
                SpriteEffects.None, 1f);
        }
    }
}
