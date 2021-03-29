using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ShooterGame.Game.Screens.Play.Bullets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShooterGame.Game.Screens.Play.Characters.Enemies
{
    public class Enemy : Character
    {
        public override int Health { get; set; } = 100;

        private float millisecondsBetweenFires = 150;
        private Texture2D texture;
        private GraphicsDevice graphicsDevice;
        public Enemy(Vector2 initialPosition)
        {
            RelativePosition = initialPosition;
        }

        public void Fire()
        {
            var bullet = new LongBullet(PlayField, graphicsDevice, new(RelativePosition.X + PlayField.Position.X, RelativePosition.Y + PlayField.Position.Y));
            bullet.IsEnemyBullet = true;
            Game.AddObject(bullet);
        }

        public override void Initialize()
        {
            texture = Texture2D.FromFile(Game.GraphicsDevice, "Assets/Gameplay/Enemy.png");
            graphicsDevice = Game.GraphicsDevice;
        }

        public override void Update(GameTime gameTime)
        {
            if (millisecondsBetweenFires <= 0)
            {
                Fire();
                millisecondsBetweenFires = 150;
            }
            else
            {
                millisecondsBetweenFires -= 1 * (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            }
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, new Rectangle((int)(RelativePosition.X + PlayField.Position.X), (int)(RelativePosition.Y + PlayField.Position.Y), 20, 20), null, Color.White, 0, Vector2.Zero, SpriteEffects.None, 0.9f);
        }
    }
}
