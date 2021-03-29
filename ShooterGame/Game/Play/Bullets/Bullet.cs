using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ShooterGame.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShooterGame.Game.Play.Bullets
{
    public abstract class Bullet : GameObject
    {
        public Vector2 currentPosition; // TODO: might be committing sins here
        public Vector2 CurrentPosition { get => currentPosition; private set => currentPosition = value; }
        public bool IsEnemyBullet { get; init; } = true;

        public override void Update(GameTime gameTime)
        {

        }
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            
        }
    }
}
