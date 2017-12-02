using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Proj5_byYakupY
{
    public class Particle
    {
        // Partikeltexturen
        public Texture2D Texture { get; set; } 

        // Position och fart för partikeln/instansen
        public Vector2 Position { get; set; }
        public Vector2 Velocity { get; set; }

        // En float för storlek, två för vinkel
        public float Angle { get; set; }
        public float AngularVelocity { get; set; }
        public float Size { get; set; }
        // Partikelns färg
        public Color Color { get; set; }
        // Timer för hur länge partikeln ska synas
        public int LiveTimer { get; set; }

        public Particle(Texture2D texture, Vector2 position, Vector2 velocity,
                    float angle, float angularVelocity, Color color, float size,
                    int liveTimer)
        {
            Texture = texture;
            Position = position;
            Velocity = velocity;
            Angle = angle;
            AngularVelocity = angularVelocity;
            Color = color;
            Size = size;
            LiveTimer = liveTimer;
        }

        public void Update()
        {
            LiveTimer--;
            Position += Velocity;
            Angle += AngularVelocity;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle sourceRectangle = new Rectangle(0, 0, Texture.Width, Texture.Height);
            Vector2 origin = new Vector2(Texture.Width / 2, Texture.Height / 2);

            spriteBatch.Draw(Texture, Position, sourceRectangle, Color,
                        Angle, origin, Size, SpriteEffects.None, 0f);
        }

    }
}
