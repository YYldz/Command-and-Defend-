using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Proj5_byYakupY
{
    public class ParticleEngine
    {
        private Random random;
        public Vector2 EmitterLocation { get; set; }
        private List<Particle> particleList;
        private List<Texture2D> textureList;

        public ParticleEngine(List<Texture2D> textureList, Vector2 location)
        {
            EmitterLocation = location;
            this.textureList = textureList;
            this.particleList = new List<Particle>();
            random = new Random();
        }

        private Particle GenerateNewParticle()
        {
            Texture2D texture = textureList[random.Next(textureList.Count)];
            Vector2 position = EmitterLocation;
            Vector2 velocity = new Vector2(
                    1f * (float)(random.NextDouble() * 2 - 1),
                    1f * (float)(random.NextDouble() * 2 - 1));

            float angle = 0;
            float angularVelocity = 0.1f * (float)(random.NextDouble() * 2 - 1);
            Color color = new Color(
                    (float)random.NextDouble(),
                    (float)random.NextDouble(),
                    (float)random.NextDouble());

            float size = (float)random.NextDouble();
            int liveTimer = 20 + random.Next(40);

            return new Particle(texture, position, velocity, angle, angularVelocity,
                            Color.Gray, size, liveTimer);
        }

        public void Update()
        {
            int total = 1;

            for (int i = 0; i < total; i++)
                particleList.Add(GenerateNewParticle());

            for (int particle = 0; particle < particleList.Count; particle++)
            {
                particleList[particle].Update();

                if (particleList[particle].LiveTimer <= 0)
                {
                    particleList.RemoveAt(particle);
                    particle--;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            for (int index = 0; index < particleList.Count; index++)
                particleList[index].Draw(spriteBatch);
        }
    }
}
