using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShooterGame.Game.Play.Characters
{
    public class Cursor : Object
    {
        private Vector2 currentPosition;
        public Vector2 CurrentPosition { get => currentPosition; private set => currentPosition = value; }
        public Rectangle HitBox { get; set; }
        public int Health { get; private set; }

        private Texture2D texture;

        private const int playerSpeed = 1;

        private KeyboardState previousState;

        private readonly GraphicsDevice graphicsDevice;
        public Cursor(GraphicsDevice graphicsDevice)
        {
            this.graphicsDevice = graphicsDevice;
            texture = Texture2D.FromFile(graphicsDevice, "Assets/Gameplay/Player.png");
        }
        public override void Update(GameTime gameTime)
        {
            var state = Keyboard.GetState();
            var state2 = Mouse.GetState();
            currentPosition.X = state2.X;
            currentPosition.Y = state2.Y;
            HitBox = new Rectangle((int)currentPosition.X, (int)currentPosition.Y, 50, 50);

            previousState = state;
        }
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, HitBox, Color.White);
        }
    }
}
