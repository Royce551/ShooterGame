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

        private const int initialplayerSpeed = 250;
        private int playerSpeed = initialplayerSpeed;

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

            if (keyboardState.IsKeyDown(Keys.LeftShift))
                playerSpeed = initialplayerSpeed - 100;
            else
                playerSpeed = initialplayerSpeed;

            var newRelativePosition = relativePosition;
            if (keyboardState.IsKeyDown(Keys.Up))
                newRelativePosition.Y -= playerSpeed * PlayField.GameSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (keyboardState.IsKeyDown(Keys.Down))
                newRelativePosition.Y += playerSpeed * PlayField.GameSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (keyboardState.IsKeyDown(Keys.Left))
                newRelativePosition.X -= playerSpeed * PlayField.GameSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (keyboardState.IsKeyDown(Keys.Right))
                newRelativePosition.X += playerSpeed * PlayField.GameSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (new Rectangle((int)(newRelativePosition.X + PlayField.Position.X), (int)(newRelativePosition.Y + PlayField.Position.Y), 20, 20).Intersects(PlayField.Position))
                relativePosition = newRelativePosition;
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, new Rectangle((int)(RelativePosition.X + PlayField.Position.X), (int)(RelativePosition.Y + PlayField.Position.Y), 20, 20), null, Color.White, 0, Vector2.Zero, SpriteEffects.None, 0.9f);
        }
    }
}
