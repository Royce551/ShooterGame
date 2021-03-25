using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ShooterGame.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShooterGame.Game.Screens.Play.Characters
{
    public class Player : Character
    {
        public override int Health { get; set; } = 100;

        private Texture2D texture;
        public Player()
        {
            
        }

        public override void Initialize()
        {
            texture = Texture2D.FromFile(Game.GraphicsDevice, "Assets/Gameplay/Player.png");
        }

        public override void Update(GameTime gameTime)
        {
            var keyboardState = Keyboard.GetState();
            if (keyboardState.IsKeyDown(Keys.Up))
                relativePosition.Y -= PlayField.GameSpeed * gameTime.ElapsedGameTime.TotalSeconds;
            if (keyboardState.IsKeyDown(Keys.Down))
                relativePosition.Y++;
            if (keyboardState.IsKeyDown(Keys.Left))
                relativePosition.X--;
            if (keyboardState.IsKeyDown(Keys.Right))
                relativePosition.X++;
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, new Rectangle((int)(RelativePosition.X + PlayField.Position.X), (int)(RelativePosition.Y + PlayField.Position.Y), 20, 20), null, Color.White, 0, Vector2.Zero, SpriteEffects.None, 0.1f);
        }
    }
}
