using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Proj5_byYakupY
{
    public class MenuManager
    {
        List<Button> menuList;

        // skapa en vector2 som erhåller musens position m.h.a. Mousestate

        public Vector2 mousePosition;
        public MouseState mouseState, oldmouseState;

        public MenuManager(GraphicsDevice graphics)
        {
            menuList = new List<Button>();
            menuList.Add(new Button(new Vector2(512, 300), TextureManager.MenuButtonOne, new Point(255, 40)));
            menuList.Add(new Button(new Vector2(512, 375), TextureManager.MenuButtonTwo, new Point(255, 40)));

        }

        public void Update(GameTime gameTime)
        {
            oldmouseState = mouseState;
            mouseState = Mouse.GetState();

            mousePosition.X = mouseState.X;
            mousePosition.Y = mouseState.Y;

            for (int i = 0; i < menuList.Count; i++)
            {
                // Om musen är innanför survivalmode knappen & vänster musknapp trycks ner,
                // byt gamestate till playing
                if (menuList[0].MouseInside(mousePosition))
                {
                    if (mouseState.LeftButton == ButtonState.Pressed &&
                        oldmouseState.LeftButton == ButtonState.Released)
                    {
                        Game1.gameState = GameState.Playing;
                    }
                }

                // Om musen är innanför exitknappen & vänster musknapp trycks ner
                // stäng av spelet
                else if (menuList[1].MouseInside(mousePosition))
                {
                    if (mouseState.LeftButton == ButtonState.Pressed &&
                        oldmouseState.LeftButton == ButtonState.Released)
                            Game1.ExitGame = true;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (Game1.gameState == GameState.Menu)
            {
                spriteBatch.Draw(TextureManager.MenuBackground, Vector2.Zero, Color.White);
                foreach (Button btn in menuList)
                {
                    btn.Draw(spriteBatch);
                } 
            }
            if (Game1.gameState == GameState.GameOver)
            {
                string gameOver = "Mission Failed";
                spriteBatch.GraphicsDevice.Clear(Color.Black);
                spriteBatch.DrawString(MediaHandler.myFont, gameOver, 
                    new Vector2(500, Constants.ScreenHeight / 2), Color.Silver);
            }
        }
    }
}
