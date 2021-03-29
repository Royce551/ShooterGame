using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShooterGame.Game.Screens.Play.Bullets
{
    public class LongBullet : Bullet
    {
        public override int SizeX => 15;
        public override int SizeY => 15;
        public override int Speed => 500;
        public override bool IsEnemyBullet => true;

        private Texture2D texture;

        public LongBullet(PlayField playField, GraphicsDevice graphicsDevice, Vector2 startPosition) : base(playField, graphicsDevice, startPosition)
        {
            texture = Texture2D.FromFile(graphicsDevice, "Assets/Gameplay/longBullet.png");
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, HitBox, null, Color.White, 0, Vector2.Zero, SpriteEffects.None, 0.9f);
        }

        public override void Initialize()
        {
            
        }
    }
}
