using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShooterGame.Game.Play.Bullets
{
    public class SimpleBullet : Bullet
    {
        public int Health { get; private set; }

        private Texture2D texture;
        private readonly GraphicsDevice graphicsDevice;
        public SimpleBullet(GraphicsDevice graphicsDevice, Vector2 startPosition)
        {
            this.graphicsDevice = graphicsDevice;
            currentPosition = startPosition;
            texture = Texture2D.FromFile(graphicsDevice, "Assets/Gameplay/SimpleBullet.png");
        }
        public override void Initialize()
        {
            
        }
        public override void Update(GameTime gameTime)
        {
            if (IsEnemyBullet)
                currentPosition.Y -= 10 * Game.GameSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            else
                currentPosition.Y += 10 * Game.GameSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (!graphicsDevice.Viewport.Bounds.Intersects(new Rectangle((int)currentPosition.X, (int)currentPosition.Y, 50, 50)))
                Game.RemoveObject(this);
        }
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, new Rectangle((int)currentPosition.X, (int)currentPosition.Y, 50, 50), Color.White);
        }
    }
}
