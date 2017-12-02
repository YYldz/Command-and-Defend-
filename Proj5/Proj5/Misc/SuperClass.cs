using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Proj5_byYakupY
{
    /*
     * Som namnet uttrycker, denna klass är huvudklassen för
     * alla subklasser i spelet (fiender, torn...)
     */
    abstract class SuperClass
    {
        #region Variables
        protected Texture2D texture, hpTexture;
        
        protected float health, spawnHealth;
        public float Health
        {
            get { return health; }
            set { health = value; }
        }
        // Dessa variabler används för att ange hur mycket liv
        // en fiende har.
        protected float currentHealth;
        public float HpPercent
        {
            get { return currentHealth / spawnHealth; }
        }
        
        protected Vector2 position;
        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }
        protected Vector2 center;
        public Vector2 Center { get { return center; } }

        public Point size;
        public Rectangle spriteRec;

       

        
        #endregion

        public SuperClass(Texture2D texture, Texture2D hpTexture, 
                            Vector2 position)
        {
            this.texture = texture;
            this.position = position;
            center = new Vector2(position.X + size.X / 2,
                                 position.Y + size.Y / 2);
            //center = new Vector2(position.X + texture.Width / 2,
            //                     position.Y + texture.Height / 2);

            this.hpTexture = TextureManager.HealthBar;

            
        }

        #region SpelLoopen

        public abstract void Update(GameTime gameTime);

        public abstract void Draw(SpriteBatch spriteBatch);

        #endregion


    }
}
