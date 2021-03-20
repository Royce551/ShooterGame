using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ShooterGame.Game.Play.Bullets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShooterGame.Game.Play.Characters
{
    public class Player : Object, ICollideable
    {
        private Vector2 currentPosition;
        public Vector2 CurrentPosition { get => currentPosition; private set => currentPosition = value; }
        public Rectangle HitBox { get; set; }
        public int Health { get; private set; }

        private Texture2D texture;

        private const int playerSpeed = 1;

        private KeyboardState previousState;

        private readonly GraphicsDevice graphicsDevice;
        public Player(GraphicsDevice graphicsDevice)
        {
            this.graphicsDevice = graphicsDevice;
            texture = Texture2D.FromFile(graphicsDevice, "Assets/Gameplay/Player.png");
        }
        public void Fire()
        {
            GameManager.AddObject(new SimpleBullet(graphicsDevice, new(currentPosition.X, currentPosition.Y += 500)));
        }
        public override void Update(GameTime gameTime)
        {
            var state = Keyboard.GetState();
            var state2 = Mouse.GetState();
            currentPosition.X = state2.X;
            currentPosition.Y = state2.Y;
            HitBox = new Rectangle((int)currentPosition.X, (int)currentPosition.Y, 50, 50);

            if (state.IsKeyDown(Keys.Z) && !previousState.IsKeyDown(Keys.Z))
                Fire();

            previousState = state;
        }
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, HitBox, Color.White);
        }

        public void OnCollision(Object collidedObject)
        {
            if (collidedObject is Bullet)
                GameManager.RemoveObject(this);
        }
    }
}
