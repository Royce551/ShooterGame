using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ShooterGame.Framework;
using ShooterGame.Framework.Screens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShooterGame.Game.Screens.Play
{
    public class PlayScreen : Screen
    {
        public GameObjectManager game;
        public PlayField PlayField;

        private readonly GraphicsDevice graphicsDevice;
        public PlayScreen(GraphicsDevice graphicsDevice, GameWindow window)
        {
            this.graphicsDevice = graphicsDevice;
            game = new GameObjectManager(graphicsDevice);
            PlayField = new PlayField(new Rectangle(20, 20, 854, 480));
            game.AddObject(PlayField);
        }
        public override void Update(GameTime gameTime)
        {
            //var state = Keyboard.GetState();
            //if (state.IsKeyDown(Keys.B))
                //game.AddObject(new Cursor(graphicsDevice));
            game.Update(gameTime);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(background, graphicsDevice.Viewport.Bounds, Color.White);
            game.Draw(gameTime, spriteBatch);
        }
    }
}
