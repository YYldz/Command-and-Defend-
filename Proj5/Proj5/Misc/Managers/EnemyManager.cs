using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Proj5_byYakupY
{
    /*
     * Denna handler hanterar fienden. Lägger till statiska
     * metoder i denna handler som ger en viss fiende en unik
     * förmåga.
     */
    class EnemyManager
    {
        double lossTimer = 3000;

        public void Update(GameTime gameTime)
        {
            lossTimer -= gameTime.ElapsedGameTime.Milliseconds;
            foreach (Enemy e in Constants.EnemyList)
            {
                // Om fienden når sitt mål förlorar spelaren
                // 1 hp och credits;
                if (e.EPos > LevelManager.path.endT)
                {
                    Constants.EnemyList.Remove(e);
                    Constants.cYardHp--;
                    if (lossTimer <= 0)
                    {
                        Constants.Credits -= 10;
                        lossTimer = 3000;
                    }
                    break;
                }
                // Om fienden blir dödad ge spelaren credits
                if (e.Health <= 0)
                {
                    Constants.EnemyList.Remove(e);
                    Constants.BountyCounter--;

                    if (Constants.BountyCounter == 0)
                    {
                        Constants.WaveKilled++;
                        Constants.BountyCounter += (2 * Constants.WaveKilled);
                        Constants.Credits += (25 * (Constants.BountyCounter - 1));
                    }
                    break;
                }
                e.Update(gameTime);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Enemy e in Constants.EnemyList)
            {
                Rectangle hpRectangle =
                    new Rectangle((int)e.Position.X - 15,
                                  (int)e.Position.Y - 20,
                                    TextureManager.HealthBar.Width,
                                    TextureManager.HealthBar.Height);
                spriteBatch.Draw(TextureManager.HealthBar,
                                hpRectangle, Color.Black);

                float healthPercentage = e.HpPercent;
                float visibleWidth =
                    TextureManager.HealthBar.Width *
                    healthPercentage;

                hpRectangle = new Rectangle((int)e.Position.X - 15,
                                            (int)e.Position.Y - 20,
                                            (int)(visibleWidth),
                                            TextureManager.HealthBar.Height);

                float red = (healthPercentage < 0.5 ? 1 : 1 - (2 * healthPercentage - 1));
                float green = (healthPercentage > 0.5 ? 1 : (2 * healthPercentage));

                Color healthColor = new Color(red, green, 0);

                spriteBatch.Draw(TextureManager.HealthBar,
                                hpRectangle, healthColor);

                e.Draw(spriteBatch);
            }


        }

        public static void SpawnEnemies()
        {

            if (!LevelManager.SpawnC)  
            {
                Soldier soldier = new Soldier(TextureManager.Soldier,
                                        TextureManager.HealthBar,
                                        Vector2.Zero);

                Constants.EnemyList.Add(soldier); 
            }
            if (LevelManager.SpawnC)
            {
                Commando commando = new Commando(TextureManager.Commando,
                                                TextureManager.HealthBar,
                                                Vector2.Zero);

                Constants.EnemyList.Add(commando);
            }
        }
    }
}
