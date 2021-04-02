using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ShooterGame.Framework;

namespace ShooterGame.Game.Screens.Play.Bullets
{
    public abstract class Bullet : GameObject, ICollideableThing
    {
        public PlayField PlayField { get; set; }

        public Vector2 relativePosition;
        public Vector2 RelativePosition
        {
            get => relativePosition;
            private set => relativePosition = value;
        }
        public Rectangle HitBox { get; set; }

        public Vector2 TargetPosition { get; set; }

        public abstract int SizeX { get; }
        public abstract int SizeY { get; }
        public abstract bool IsEnemyBullet { get; set; }
        public abstract int Speed { get; }

        private readonly GraphicsDevice graphicsDevice;
        public Bullet(PlayField playField, GraphicsDevice graphicsDevice, Vector2 startPosition)
        {
            PlayField = playField;
            this.graphicsDevice = graphicsDevice;
            RelativePosition = startPosition;
        }

        public override void Update(GameTime gameTime)
        {
            var direction = TargetPosition - RelativePosition;
            direction.Normalize();
            relativePosition += direction * Speed * PlayField.GameSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            //if (!IsEnemyBullet)
            //    relativePosition.Y -= Speed * PlayField.GameSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            //else
            //    relativePosition.Y += Speed * PlayField.GameSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            HitBox = new Rectangle((int)relativePosition.X, (int)relativePosition.Y, SizeX, SizeY);

            //foreach (var obj in GameManager.AllObjects)
            //{
            //    if (obj is ICollideable collideableObj)
            //    {
            //        if (HitBox.Intersects(collideableObj.HitBox))
            //            collideableObj.OnCollision(this);
            //    }
            //}
            if (!PlayField.Position.Intersects(HitBox))
                Game.RemoveObject(this);
        }

        public void OnCollision(ICollideableThing collided)
        {
            //throw new System.NotImplementedException();
        }
    }
}
