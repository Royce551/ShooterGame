using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ShooterGame.Framework.Screens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShooterGame.Game.Screens
{
    public class TestScreen : Screen
    {
        private Texture2D texture;
        private Vector2 position;

        private readonly GraphicsDevice graphicsDevice;
        public TestScreen(GraphicsDevice graphicsDevice, GameWindow window)
        {
            this.graphicsDevice = graphicsDevice;
            texture = Texture2D.FromFile(graphicsDevice, "Assets/test.png");
        }
        public override void Update(GameTime gameTime)
        {
            var state = Keyboard.GetState();
            if (state.IsKeyDown(Keys.Left))
                position.X -= 100 * (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (state.IsKeyDown(Keys.Right))
                position.X += 100 * (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (state.IsKeyDown(Keys.Up))
                position.Y -= 100 * (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (state.IsKeyDown(Keys.Down))
                position.Y += 100 * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (position.X < graphicsDevice.Viewport.Bounds.Left) position.X++;
            if (position.X > graphicsDevice.Viewport.Bounds.Right) position.X--;
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, new Rectangle((int)position.X, (int)position.Y, 100, 100), Color.White);
        }
    }
}
