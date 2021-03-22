using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ShooterGame.Framework.Screens;
using ShooterGame.Game.Screens;
using System.IO;

namespace ShooterGame
{
    public class ShooterGame : Microsoft.Xna.Framework.Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private ScreenManager screenManager = new();
        
        public ShooterGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            screenManager.ChangeScreen(new PlayScreen(GraphicsDevice, Window));
            _graphics.PreferredBackBufferWidth = 1600;
            _graphics.PreferredBackBufferHeight = 900;
            _graphics.ApplyChanges();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                screenManager.AddScreen(new PlayScreen(GraphicsDevice, Window));
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.A))
                _graphics.ToggleFullScreen();

            screenManager.Update(gameTime);
            Window.Title = $"{(screenManager.Screens.Peek() as PlayScreen)?.game.AllObjects.Count} objects | {1 / gameTime.ElapsedGameTime.TotalSeconds}fps - world's worst match3 game";

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();

            screenManager.Draw(gameTime, _spriteBatch);

            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
