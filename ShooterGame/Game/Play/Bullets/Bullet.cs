using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ShooterGame.Game.Play.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShooterGame.Game.Play.Bullets
{
    public abstract class Bullet : Object, ICollideable
    {
        public Vector2 currentPosition;
        public Vector2 CurrentPosition { get => currentPosition; private set => currentPosition = value; }
        public Rectangle HitBox { get; set; }

        public bool IsEnemyBullet { get; init; } = true;

        private const int bulletSpeed = 500;

        private GraphicsDevice graphicsDevice;
        public Bullet(GraphicsDevice graphicsDevice, Vector2 startPosition)
        {
            this.graphicsDevice = graphicsDevice;
            currentPosition = startPosition;
        }
        public override void Update(GameTime gameTime)
        {
            if (IsEnemyBullet)
                currentPosition.Y -= bulletSpeed * GameManager.GameSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            else
                currentPosition.Y += bulletSpeed * GameManager.GameSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            HitBox = new Rectangle((int)currentPosition.X, (int)currentPosition.Y, 50, 50);

            foreach (var obj in GameManager.AllObjects)
            {
                if (obj is ICollideable collideableObj)
                {
                    if (HitBox.Intersects(collideableObj.HitBox))
                        collideableObj.OnCollision(this);
                }
            }
            if (!graphicsDevice.Viewport.Bounds.Intersects(HitBox))
                GameManager.RemoveObject(this);
        }
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            
        }

        public void OnCollision(Object collidedObject)
        {
            // do nothing
        }
    }
}
