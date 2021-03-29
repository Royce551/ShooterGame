using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ShooterGame.Framework;
using ShooterGame.Game.Play.Bullets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShooterGame.Game.Play.Characters
{
    public class Player : GameObject, ICollideable
    {
        private Vector2 currentPosition;
        public Vector2 CurrentPosition { get => currentPosition; private set => currentPosition = value; }
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
            Game.AddObject(new SimpleBullet(graphicsDevice, CurrentPosition));
        }
        public override void Initialize()
        {
            
        }
        public override void Update(GameTime gameTime)
        {
            var state = Keyboard.GetState();
            var state2 = Mouse.GetState();
            currentPosition.X = state2.X;
            currentPosition.Y = state2.Y;
            //if (state.IsKeyDown(Keys.Left))
            //    currentPosition.X -= playerSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            //if (state.IsKeyDown(Keys.Right))
            //    currentPosition.X += playerSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            //if (state.IsKeyDown(Keys.Up))
            //    currentPosition.Y -= playerSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            //if (state.IsKeyDown(Keys.Down))
            //    currentPosition.Y += playerSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (state.IsKeyDown(Keys.Z) /*&& !previousState.IsKeyDown(Keys.Z)*/)
                Fire();
            previousState = state;
        }
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, new Rectangle((int)currentPosition.X, (int)currentPosition.Y, 50, 50), Color.White);
        }

        
    }
}
