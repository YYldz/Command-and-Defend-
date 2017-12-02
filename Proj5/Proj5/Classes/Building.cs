using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;

namespace Proj5_byYakupY
{
    abstract class Building : SuperClass
    {
        protected bool isHit;
        public bool IsHit
        {
            get { return isHit; }
            set { isHit = value; }
        }
        protected BuildingState buildingState = new BuildingState();
        public BuildingState BuildingState
        {
            get { return buildingState; }
            set { buildingState = value; }
        }

        protected float range;

        protected int cost;
        public int Cost
        {
            get { return cost; }
            set { cost = value; }
        }

        protected int damage;
        public int Damage { 
            get { return damage; } 
            set { damage = value; } 
        }
        protected float timerValue;
        public float TimerValue
        {
            get { return timerValue; }
            set { timerValue = value; }
        }

        protected double shootTimer;


        public Color BuildingColor { get; set; }

        protected Enemy target;
        public Enemy Target { get { return target; } }

        public Building(Texture2D texture, Texture2D hpTexture,
                            Vector2 position)
            : base(texture, hpTexture, position)
        {
            shootTimer = timerValue;

            size = new Point(Constants.TowerSize, Constants.TowerSize);
            BuildingColor = Color.White;
            BuildingState = BuildingState.NotUpgraded;
        }

        public override void Update(GameTime gameTime) { }

        public override void Draw(SpriteBatch spriteBatch) { }

        public void Attack()
        {
            this.target = null;

            SoundEffectInstance miniGun =
                MediaHandler.mGun.CreateInstance();
            SoundEffectInstance obelRay =
                MediaHandler.ObeliskBeamSound.CreateInstance();
            SoundEffectInstance sniperGun =
                MediaHandler.sGun.CreateInstance();
            miniGun.Volume = 0.45f;
            sniperGun.Volume = 0.5f;
            obelRay.Volume = 0.75f;

            foreach (Enemy enemy in Constants.EnemyList)
            {
                float inRange = Vector2.Distance(this.Center, enemy.Center);

                if (inRange <= this.range)
                {
                    isHit = true;
                    if (this is Pillbox && 
                        this.buildingState != BuildingState.UpgradedDmg)
                    {
                        miniGun.Play();
                        ExplosionManager.CreateExplosions(enemy.Position);
                    }
                    if (this is Pillbox && 
                        this.buildingState == BuildingState.UpgradedDmg)
                        sniperGun.Play();

                    if (this is Obelisk)
                        obelRay.Play();
                    
                    enemy.Health -= this.damage;
                    this.shootTimer = this.timerValue;
                    break;
                }
            }
        }

        public Rectangle BuildingBox()
        {
            return new Rectangle(
                (int)position.X, (int)position.Y,
                    size.X, size.Y);
        }
    }
}
public enum BuildingState
{
    NotUpgraded,
    UpgradedSpeed,
    UpgradedDmg,
    ObeliskSpeed,
}
