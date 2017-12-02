using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Proj5_byYakupY
{
    class Commando: Enemy
    {
        public Commando(Texture2D texture, Texture2D hpTexture,
                        Vector2 position)
            : base(texture, hpTexture, position)
        {
            speed = 1.5f;
            spriteRec = new Rectangle(0, 0, 500, 500);
            this.health = 540;
            this.spawnHealth = health;
            //val = 100;
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
