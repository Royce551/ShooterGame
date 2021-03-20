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
        
        public SimpleBullet(GraphicsDevice graphicsDevice, Vector2 startPosition) : base(graphicsDevice, startPosition)
        {
            texture = Texture2D.FromFile(graphicsDevice, "Assets/Gameplay/SimpleBullet.png");
        }
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            
        }
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            base.Draw(gameTime, spriteBatch);
            spriteBatch.Draw(texture, HitBox, Color.White);
        }
    }
}
