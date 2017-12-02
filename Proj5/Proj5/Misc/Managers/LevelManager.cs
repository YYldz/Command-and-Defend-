using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Spline;
using System.IO;
using Microsoft.Xna.Framework.Media;

namespace Proj5_byYakupY
{
    /*
     * Här hanteras nivån och nivåbyte.
     * Då nivåerna ser likadana ut så kommer nya torn/uppgraderingar
     * tillkomma samt nya fiender.
     */
    class LevelManager
    {
        // En array av vektorer för levelns spline.
        Vector2[] vecArr = new Vector2[22];

        Soldier soldier;
        Commando commando;
        GraphicsDevice graphics;

        public static bool SpawnC;

        // Räknare för antalet waves och antalet spawnade fiender per wave
        private int waveCount, spawnedThisWave;
        // Int för antalet enemies per wave & int som kollar om wave + "värde"
        // är uppnått för att öka fiender per wave
        private int amountOfEnemies, limitCount;
        // Timers till enemyspawning.
        // SpawnRate bestämmer hur ofta en fiende får spawna.
        // WaveTimer avgör när nästa våg av fiender ska spawna.
        private double enemySpawnRate, enemyWaveTimer;

        public static SimplePath path;
        public LevelManager(GraphicsDevice graphics)
        {
            this.graphics = graphics;
            path = new SimplePath(graphics);
            path.Clean();

            ReadPathFromFile();
            enemySpawnRate = 500;
            enemyWaveTimer = 500;
            amountOfEnemies = 2;
            waveCount = 0;
            limitCount = 8;
        }

        public void LoadContent()
        {

            soldier = new Soldier(TextureManager.Soldier,
                                    TextureManager.HealthBar,
                                    soldier.EnemyPos);
            commando = new Commando(TextureManager.Commando,
                                        TextureManager.HealthBar,
                                        commando.EnemyPos);

            MediaPlayer.IsRepeating = true;
            MediaPlayer.Volume = 0.8f;

        }

        public void Update(GameTime gameTime)
        {
            if (MediaPlayer.State.Equals(MediaState.Stopped) 
                && Game1.gameState == GameState.Playing)
            {
                MediaPlayer.Play(MediaHandler.Aoi);
            }

            enemySpawnRate -= gameTime.ElapsedGameTime.Milliseconds;
            enemyWaveTimer -= gameTime.ElapsedGameTime.Milliseconds;


            if (enemyWaveTimer <= 0 && enemySpawnRate <= 0)
            {
                EnemyManager.SpawnEnemies();
                enemySpawnRate = 500;
                spawnedThisWave++;
                if (spawnedThisWave == amountOfEnemies)
                {
                    // Resetta timers
                    enemySpawnRate = 500;
                    enemyWaveTimer = 3000;

                    waveCount++;
                    spawnedThisWave = 0;

                }

                if (waveCount == limitCount)
                {
                    limitCount = waveCount + 2;
                    amountOfEnemies += 1;
                    Constants.cYardHp++;
                }
            }

            if (waveCount == 30)
            {
                SpawnC = true;
                amountOfEnemies = 2;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(TextureManager.Background, Vector2.Zero,
                             Color.White);
            string creds = "$ " + Constants.Credits;
            string waves = "Kill " + Constants.BountyCounter + " for next bounty!";
            string yardHp = "Power: " + Constants.cYardHp;
            spriteBatch.DrawString(MediaHandler.myFont, creds, new Vector2(765, 5), Color.Goldenrod);
            spriteBatch.DrawString(MediaHandler.myFont, waves, new Vector2(75, 5), Color.Goldenrod);
            spriteBatch.DrawString(MediaHandler.myFont, yardHp, new Vector2(1075, 5), Color.Green);



            //path.Draw(spriteBatch);
            //path.DrawPoints(spriteBatch);


        }

        #region SplineCreator
        void CreatePath()
        {
            Vector2 vec;
            for (int i = 0; i < 22; i++)
            {
                vec = new Vector2(20, 30 * i);
                path.AddPoint(vec);
                vecArr[i] = vec;
            }
            vec = new Vector2(100, 30 * 20);
            path.AddPoint(vec);
            vecArr[22] = vec;

        }

        // Denna metod läser av en "spline" från en fil.
        // Detta görs genom att man anger namnet på filen, och sedan läser
        // alla rader. Sedan så ger man höger värde (om ":") till mapVecs.X
        // och vänster värde till mapVecs.Y. Sist så lägger man till 
        void ReadPathFromFile()
        {
            string[] splitArr;
            int i = 0;
            StreamReader reader = new StreamReader(@"myPath.txt");
            do
            {

                string lines;
                lines = reader.ReadLine();
                splitArr = lines.Split(':');

                Vector2 mapVecs;
                mapVecs.X = Convert.ToInt32(splitArr[0]);
                mapVecs.Y = Convert.ToInt32(splitArr[1]);

                path.AddPoint(mapVecs);

                i++;

            } while (!reader.EndOfStream);

            reader.Close();
        }
        #endregion
    }
    // Använder en enum då det ska ske saker på olika nivåer och
    // då skulle för många bool-värden behövas...
    enum Levels
    {

    }
}
