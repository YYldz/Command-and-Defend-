using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Proj5_byYakupY
{
    class ExplosionManager
    {
        public static void CreateExplosions(Vector2 position)
        {
            Explosion tempExplosion = new Explosion(position);

            Constants.ExplosionList.Add(tempExplosion);
        }

        public void Update(GameTime gameTime)
        {
            CheckIfDead();
            foreach (Explosion e in Constants.ExplosionList)
            {
                e.Update(gameTime);  

            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Explosion e in Constants.ExplosionList)
            {
                e.Draw(spriteBatch);
            }
        }

        void CheckIfDead()
        {
            foreach (Explosion e in Constants.ExplosionList)
            {
                if (e.IsDead)
                {
                    Constants.ExplosionList.Remove(e);
                    break;
                }
            }
        }
    }
}
