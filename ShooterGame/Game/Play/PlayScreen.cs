using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ShooterGame.Framework.Screens;
using ShooterGame.Game.Play;
using ShooterGame.Game.Play.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShooterGame.Game.Screens
{
    public class PlayScreen : Screen
    {
        private Texture2D background;
        public GameManager game = new();

        private readonly GraphicsDevice graphicsDevice;
        public PlayScreen(GraphicsDevice graphicsDevice, GameWindow window)
        {
            this.graphicsDevice = graphicsDevice;
            background = Texture2D.FromFile(graphicsDevice, "Assets/[ Pink Dreams ].png");
            game.AddObject(new Player(graphicsDevice));
        }
        public override void Update(GameTime gameTime)
        {
            var state = Keyboard.GetState();
            if (state.IsKeyDown(Keys.B))
                game.AddObject(new Player(graphicsDevice));
            game.Update(gameTime);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            //spriteBatch.Draw(background, graphicsDevice.Viewport.Bounds, Color.White);
            game.Draw(gameTime, spriteBatch);
        }
    }
}
