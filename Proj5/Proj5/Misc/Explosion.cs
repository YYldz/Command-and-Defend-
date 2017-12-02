using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Proj5_byYakupY
{
    class Explosion
    {
        private ParticleEngine pEngine;
        private double timer;
        public bool IsDead { get; private set; }

        public Explosion(Vector2 position)
        {
            pEngine = new ParticleEngine(Constants.TextureList, position);

            timer = 500;
        }

        public void Update(GameTime gameTime)
        {
            timer -= gameTime.ElapsedGameTime.Milliseconds;
            if (timer <= 0)
            {
                IsDead = true;
            }
            pEngine.Update();

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            pEngine.Draw(spriteBatch);
        }


            
    }
}
