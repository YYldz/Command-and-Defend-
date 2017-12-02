using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;

namespace Proj5_byYakupY
{
    class Player
    {
        public Vector2 mousePosition;
        public MouseState mouseState, oldmouseState;
        public Point mousePoint;
        
        ModeState modeState;

        SoundEffectInstance errorSnd, buildSnd, cancel, 
                                sellSnd, clickSnd;

        private Texture2D toolTip;

        GraphicsDevice graphics;

        BuildingManager tM;

        Building building = null;
        Silo silo;

        // Används för att begränsa klick till inne i spelskärmen
        public bool mouseInsideWindow;
        bool fortified;

        int upgradeCost;

        public Player(BuildingManager tM, GraphicsDevice graphics)
        {
            this.tM = tM;
            Constants.Credits = 8980;
            Constants.cYardHp = 5;
            this.graphics = graphics;
            modeState = ModeState.None;

            tM.DrawBackgroundLayer();

            errorSnd = MediaHandler.ErrorSnd.CreateInstance();
            buildSnd = MediaHandler.Build.CreateInstance();
            sellSnd = MediaHandler.Sell.CreateInstance();
            clickSnd = MediaHandler.Click.CreateInstance();
            cancel = MediaHandler.Cancel.CreateInstance();
        }



        public void Update()
        {
            oldmouseState = mouseState;
            mouseState = Mouse.GetState();

            // För att tornen ska kunna placeras på musens position
            // så skapas en vector2 som tar musens X och Y position.
            mousePosition = new Vector2(mouseState.X, mouseState.Y);
            mousePoint = new Point(mouseState.X, mouseState.Y);

            if (Constants.cYardHp == 0)
                Game1.gameState = GameState.GameOver;


            /* Om muspositionen är utanför spelfönstret är mouseInsideWindow falsk
             * Annars är den sann
             */
            if ((mousePosition.X > Constants.ScreenWidth - 40 || mousePosition.X < 40) ||
                (mousePosition.Y > Constants.ScreenHeight - 40 || mousePosition.Y < 40))
                mouseInsideWindow = false;
            else
                mouseInsideWindow = true;

            if (building != null && mouseInsideWindow)
            {
                building.Position = new Vector2(mousePosition.X - (Constants.TowerSize / 2),
                                                mousePosition.Y - (Constants.TowerSize / 2));

                if (mouseState.LeftButton == ButtonState.Pressed &&
                    oldmouseState.LeftButton == ButtonState.Released &&
                    tM.CanPlace(building) && Constants.Credits >= building.Cost)
                {
                    modeState = ModeState.None;
                    tM.DrawBackgroundLayer();
                    tM.BuildTower(building);
                    buildSnd.Play();
                    building = null;
                }
            }
            else if (building == silo && mouseInsideWindow)
            {
                
            }

            for (int i = 0; i < tM.buttonList.Count; i++)
            {
                if (tM.buttonList[0].MouseInside(mousePosition)
                    && mouseInsideWindow)
                {
                    toolTip = TextureManager.ToolTipPillbox;
                    if (mouseState.LeftButton == ButtonState.Pressed &&
                        oldmouseState.LeftButton == ButtonState.Released
                         && building == null)
                    {
                        modeState = ModeState.None;
                        tM.DrawBackgroundLayer();
                        clickSnd.Play();
                        building = new Pillbox(TextureManager.PillBoxTexture,
                            TextureManager.HealthBar,
                            new Vector2(mouseState.X -
                                (Constants.TowerSize / 2)));

                    }
                }
                else if (tM.buttonList[1].MouseInside(mousePosition)
                    && mouseInsideWindow)
                {
                    toolTip = TextureManager.ToolTipObelisk;
                    if (mouseState.LeftButton == ButtonState.Pressed &&
                        oldmouseState.LeftButton == ButtonState.Released
                         && building == null)
                    {
                        modeState = ModeState.None;
                        tM.DrawBackgroundLayer();
                        clickSnd.Play();
                        building = new Obelisk(TextureManager.ObeliskTexture,
                                                TextureManager.HealthBar,
                                new Vector2(mouseState.X -
                                    (Constants.TowerSize / 2 + 5)), graphics);
                    }
                }

                else if (tM.buttonList[2].MouseInside(mousePosition)
                    && mouseInsideWindow)
                {
                    if (mouseState.LeftButton == ButtonState.Pressed &&
                        oldmouseState.LeftButton == ButtonState.Released)
                    {
                        clickSnd.Play();
                        Game1.ExitGame = true;
                        //Game1.gameState = GameState.Menu;
                        //Constants.BuildingList.Clear();
                        //Constants.EnemyList.Clear();
                        //Constants.cYardHp = 0;
                        //Constants.Credits = 0;
                    }
                }

                else if (tM.buttonList[3].MouseInside(mousePosition)
                    && mouseInsideWindow)
                {
                    toolTip = TextureManager.ToolTipSilo;
                    if (mouseState.LeftButton == ButtonState.Pressed
                        && oldmouseState.LeftButton == ButtonState.Released
                        && building == null && Constants.siloCounter < 3)
                    {
                        modeState = ModeState.None;
                        tM.DrawBackgroundLayer();
                        clickSnd.Play();
                        building = new Silo(TextureManager.SiloTexture,
                                                TextureManager.HealthBar,
                                new Vector2(mouseState.X -
                                    (Constants.TowerSize / 2 + 5)));
                    }
                }
                
                else if (tM.buttonList[4].MouseInside(mousePosition))
                {
                    if (mouseState.LeftButton == ButtonState.Pressed &&
                        oldmouseState.LeftButton == ButtonState.Released)
                    {
                        clickSnd.Play();
                        modeState = ModeState.Sell;
                    }

                }
                else if (tM.buttonList[5].MouseInside(mousePosition))
                {
                    toolTip = TextureManager.ToolTipUpgradeOne;
                    
                    if (mouseState.LeftButton == ButtonState.Pressed &&
                        oldmouseState.LeftButton == ButtonState.Released
                        && building == null)
                    {
                        tM.DrawBackgroundLayer();
                        clickSnd.Play();
                        upgradeCost = 0;
                        modeState = ModeState.UpgradeOne;
                        upgradeCost = 1000;
                    }
                }
                else if (tM.buttonList[6].MouseInside(mousePosition))
                {
                    toolTip = TextureManager.ToolTipUpgradeTwo;

                    if (mouseState.LeftButton == ButtonState.Pressed &&
                        oldmouseState.LeftButton == ButtonState.Released
                        && building == null)
                    {
                        tM.DrawBackgroundLayer();
                        clickSnd.Play();
                        upgradeCost = 0;
                        modeState = ModeState.UpgradeTwo;
                        upgradeCost = 750;
                    }
                }
                else if (mouseState.RightButton == ButtonState.Pressed &&
                        oldmouseState.RightButton == ButtonState.Released)
                {
                    cancel.Play();
                    building = null;
                    modeState = ModeState.None;
                    upgradeCost = 0;
                }

                else if (building != null && mouseState.LeftButton == ButtonState.Pressed &&
                        oldmouseState.LeftButton == ButtonState.Released &&
                        Constants.Credits < building.Cost)
                {
                    building = null;
                    errorSnd.Play();
                }

                else
                    toolTip = null;
                
            }

            foreach (Building b in Constants.BuildingList)
            {
                if (mouseState.LeftButton == ButtonState.Pressed &&
                    oldmouseState.LeftButton == ButtonState.Released 
                    && modeState == ModeState.Sell)
                {
                    if (b.BuildingBox().Contains(mousePoint))
                    {
                        if (b is Silo)
                            Constants.siloCounter--;
                        Constants.BuildingList.Remove(b);
                        sellSnd.Play();
                        tM.DrawBackgroundLayer();
                        Constants.Credits += b.Cost / 2;
                        modeState = ModeState.None;
                        break;
                    } 
                }
                else if (mouseState.LeftButton == ButtonState.Pressed &&
                    oldmouseState.LeftButton == ButtonState.Released
                    && modeState == ModeState.UpgradeOne &&
                    b.BuildingState == BuildingState.NotUpgraded &&
                    b is Pillbox)
                {
                    if (b.BuildingBox().Contains(mousePoint)
                        && Constants.Credits >= upgradeCost)
                    {
                        buildSnd.Play();
                        b.BuildingState = BuildingState.UpgradedSpeed;
                        b.TimerValue /= 2;
                        Constants.Credits -= upgradeCost;
                        b.Cost += (upgradeCost / 2);
                        modeState = ModeState.None;
                    }
                }
                else if (mouseState.LeftButton == ButtonState.Pressed &&
                    oldmouseState.LeftButton == ButtonState.Released
                    && modeState == ModeState.UpgradeTwo &&
                    b.BuildingState == BuildingState.NotUpgraded &&
                    b is Pillbox)
                {
                    if (b.BuildingBox().Contains(mousePoint)
                        && Constants.Credits >= upgradeCost)
                    {
                        buildSnd.Play();
                        b.BuildingState = BuildingState.UpgradedDmg;
                        b.TimerValue *= 2;
                        b.Damage *= 3;
                        Constants.Credits -= upgradeCost;
                        b.Cost += (upgradeCost / 2);
                        modeState = ModeState.None;
                    }
                }
            }


        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (building != null && mouseInsideWindow && mousePosition.X <= 940
                && mousePosition.Y >= 40)
            {
                if (!tM.CanPlace(building) ||
                    Constants.Credits < building.Cost)
                    building.BuildingColor = Color.DarkRed;

                else if (tM.CanPlace(building))
                    building.BuildingColor = Color.White;

                building.Draw(spriteBatch);
            }

            if (toolTip != null)
            {
                spriteBatch.Draw(toolTip,
                            new Vector2(mouseState.X + 15, mouseState.Y + 15),
                            Color.White);
            }
        }
    }
}
enum ModeState
{
    None,
    Sell,
    UpgradeOne,
    UpgradeTwo,
    UpgradeThree,
}

