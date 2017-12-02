using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Proj5_byYakupY
{
    class Enemy : SuperClass
    {
        float ePos;
        public float EPos { get { return ePos; } }
        protected float speed;

        public Vector2 EnemyPos
        {
            get { return position; }
            set { position = value; }
        }
        protected int val;
        public int Val
        {
            get { return val; }
            set { val = value; }
        }

        public Rectangle EnemyBoundingBox { get; private set; }



        public Enemy(Texture2D texture, Texture2D hpTexture,
                        Vector2 position)
            : base(texture, hpTexture, position)
        {
            ePos = LevelManager.path.beginT;
            this.position = position;
            size = new Point(Constants.EnemySize, Constants.EnemySize);
        }



        public override void Update(GameTime gameTime)
        {
            ePos += speed;
            position = LevelManager.path.GetPos(ePos);
            EnemyBoundingBox = new Rectangle((int)position.X, (int)position.Y,
                                                Constants.EnemySize, Constants.EnemySize);
            currentHealth = health;
            center.X = EnemyBoundingBox.X;
            center.Y = EnemyBoundingBox.Y;
        }

        public override void Draw(SpriteBatch spriteBatch) { }
    }
}