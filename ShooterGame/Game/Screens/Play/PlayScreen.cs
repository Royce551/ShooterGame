using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ShooterGame.Framework;
using ShooterGame.Framework.Screens;
using ShooterGame.Game.Play;
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

        private Texture2D background;

        private readonly GraphicsDevice graphicsDevice;
        public PlayScreen(GraphicsDevice graphicsDevice, GameWindow window)
        {
            this.graphicsDevice = graphicsDevice;
            background = Texture2D.FromFile(graphicsDevice, "Assets/UI/playscreenOverlay.png");
            game = new GameObjectManager(graphicsDevice);
            PlayField = new PlayField(new Rectangle(282, 0, 1036, 900));
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
            spriteBatch.Draw(background, graphicsDevice.Viewport.Bounds, null, Color.White, 0, Vector2.Zero, SpriteEffects.None, 0f);
            game.Draw(gameTime, spriteBatch);
        }
    }
}
