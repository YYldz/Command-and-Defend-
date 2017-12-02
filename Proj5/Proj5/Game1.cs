using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Spline;

namespace Proj5_byYakupY
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;

        SpriteBatch spriteBatch;

        LevelManager LevelManager;
        BuildingManager TowerManager;
        Player player;
        EnemyManager enemyHandler;
        ExplosionManager explosionManager;
        MenuManager menuManager;

        public static bool ExitGame;


        public static GameState gameState = new GameState();

        public Game1()
        {
            Content.RootDirectory = "Content";
            graphics = new GraphicsDeviceManager(this);
        }

        protected override void Initialize()
        {
            gameState = GameState.Menu;
            IsMouseVisible = true;
            base.Initialize();
        }


        protected override void LoadContent()
        {

            graphics.PreferredBackBufferWidth = Constants.ScreenWidth;
            graphics.PreferredBackBufferHeight = Constants.ScreenHeight;
            graphics.ApplyChanges();

            TextureManager.LoadContent(Content);
            MediaHandler.LoadContent(Content);
            TowerManager = new BuildingManager(GraphicsDevice);
            LevelManager = new LevelManager(GraphicsDevice);
            player = new Player(TowerManager, GraphicsDevice);
            enemyHandler = new EnemyManager();
            explosionManager = new ExplosionManager();
            menuManager = new MenuManager(GraphicsDevice);


            spriteBatch = new SpriteBatch(GraphicsDevice);

        }


        protected override void UnloadContent()
        {

        }


        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (ExitGame)
                this.Exit();


            switch (gameState)
            {
                case GameState.Menu:
                    menuManager.Update(gameTime);
                    break;

                case GameState.Playing:
                    player.Update();
                    TowerManager.Update(gameTime);
                    LevelManager.Update(gameTime);
                    enemyHandler.Update(gameTime);
                    explosionManager.Update(gameTime);
                    break;

                case GameState.GameOver:
                    break;
            }


            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        public void Quit()
        {
            this.Exit();
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Transparent);

            spriteBatch.Begin();
            switch (gameState)
            {
                case GameState.Menu:
                    menuManager.Draw(spriteBatch);
                    break;

                case GameState.Playing:
                    LevelManager.Draw(spriteBatch);
                    enemyHandler.Draw(spriteBatch);
                    TowerManager.Draw(spriteBatch);
                    explosionManager.Draw(spriteBatch);
                    player.Draw(spriteBatch);
                    break;

                case GameState.GameOver:
                    menuManager.Draw(spriteBatch);
                    break;

            }


            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}

public enum GameState
{
    Menu,
    Playing,
    GameOver
}
