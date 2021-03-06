using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ShooterGame.Game.Play.Characters;
using ShooterGame.Game.Screens.Play.Characters;
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
        public override int Speed => 100;
        public override bool IsEnemyBullet { get; set; } = false;

        //private Texture2D texture;

        public LongBullet(PlayField playField, GraphicsDevice graphicsDevice, Vector2 startPosition) : base(playField, graphicsDevice, startPosition)
        {
            //texture = Texture2D.FromFile(graphicsDevice, "Assets/Gameplay/longBullet.png");
        }

        public override void Update(GameTime gameTime)
        {
            TargetPosition = PlayField.Player.AbsolutePosition;
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(PlayField.LongBulletTexture, HitBox, null, Color.White, MathF.Atan2(TargetPosition.X, TargetPosition.Y), Vector2.Zero, SpriteEffects.None, 0.9f);
        }

        public override void Initialize()
        {

        }
    }
}
