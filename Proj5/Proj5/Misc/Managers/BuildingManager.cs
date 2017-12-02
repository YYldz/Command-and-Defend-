using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Proj5_byYakupY
{
    /*
     * Denna handler hanterar tornen. Tornens resurser,
     * bygge av torn samt borttagning av torn.
     */
    class BuildingManager
    {
        RenderTarget2D backgroundLayer;
        GraphicsDevice graphics;
        public List<Button> buttonList;

        public static Texture2D Blank { get; private set; }

        public BuildingManager(GraphicsDevice graphics)
        {
            buttonList = new List<Button>();
            buttonList.Add(new Button(new Vector2(1000, 431),
                   TextureManager.PillboxButton, new Point(130, 100)));
            buttonList.Add(new Button(new Vector2(1000, 531),
                   TextureManager.ObeliskButton, new Point(130, 100)));
            buttonList.Add(new Button(new Vector2(1183, 385), 
                   TextureManager.Button, new Point(90,36)));
            buttonList.Add(new Button(new Vector2(1000, 631),
                   TextureManager.SiloButton, new Point(130, 100)));
            buttonList.Add(new Button(new Vector2(1077,385),
                   TextureManager.Button, new Point(90, 36)));
            buttonList.Add(new Button(new Vector2(1142, 431),
                   TextureManager.PillboxUpOne, new Point(130, 100)));
            buttonList.Add(new Button(new Vector2(1142, 531),
                   TextureManager.PillboxUpTwo, new Point(130, 100)));
            backgroundLayer = new RenderTarget2D(graphics,
                        1280, 960);
            this.graphics = graphics;
        }

        public void Update(GameTime gameTime)
        {

            foreach (Building b in Constants.BuildingList)
            {
                 b.Update(gameTime);
            }
            foreach (Button btn in buttonList)
            {
                btn.Update(gameTime);
            }
        
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Building b in Constants.BuildingList)
            {
                b.Draw(spriteBatch);
            }
            foreach (Button btn in buttonList)
            {
                btn.Draw(spriteBatch);
            }
        }

        public bool CanPlace(Building building)
        {

            Color[] pixels = new Color
                            [building.size.X * building.size.Y];

            backgroundLayer.GetData(0, new Rectangle(
                             (int)building.Position.X, (int)building.Position.Y,
                             building.size.X, building.size.Y), pixels, 0,
                             pixels.Length);

            foreach (Color pixel in pixels)
            {
                if (pixel.A != 0)
                    return false;
            }
            return true;
        }

        /* Skapar en metod som kollar om det går att placera ett
         * torn på platsen. Den kontrollerar om platsen där tornet
         * placeras är giltig genom att kolla efter transparent färg.
         * Om det inte finns något mer än transparent färg på området
         * placeras ett torn ut. */
        public void DrawBackgroundLayer()
        {
            SpriteBatch sb = new SpriteBatch(graphics);
            graphics.SetRenderTarget(backgroundLayer);

            graphics.Clear(Color.Transparent);
            sb.Begin();

            sb.Draw(TextureManager.RtBackground, Vector2.Zero, Color.White);
            foreach (Building t in Constants.BuildingList)
            {
                t.Draw(sb);
            }

            sb.End();

            graphics.SetRenderTarget(null);
        }

        public void BuildTower(Building b)
        {
            DrawBackgroundLayer();
            
            if (CanPlace(b))
            {
                Constants.BuildingList.Add(b);
                if (b is Silo)
                    Constants.siloCounter++;
                Constants.Credits -= b.Cost;
            }
        }
    }
}
