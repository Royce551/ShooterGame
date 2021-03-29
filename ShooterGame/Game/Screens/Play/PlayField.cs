using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ShooterGame.Framework;
using ShooterGame.Game.Screens.Play.Bullets;
using ShooterGame.Game.Screens.Play.Characters;
using ShooterGame.Game.Screens.Play.Characters.Enemies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShooterGame.Game.Screens.Play
{
    public class PlayField : GameObject
    {
        public Rectangle Position { get; set; }
        public float GameSpeed { get; private set; } = 1;
        public Player Player { get; private set; }

        public Texture2D LongBulletTexture { get; private set; }
        public Texture2D PelletBulletTexture { get; private set; }

        private Texture2D backgroundTexture;
        public PlayField(Rectangle position)
        {
            Position = position;
        }

        public override void Initialize()
        {
            backgroundTexture = Texture2D.FromFile(Game.GraphicsDevice, "Assets/UI/playfieldDefaultBackground.png");
            LongBulletTexture = Texture2D.FromFile(Game.GraphicsDevice, "Assets/Gameplay/longBullet.png");
            Player = new Player
            {
                RelativePosition = new(518, Position.Bottom - 50),
                PlayField = this
            };
            Game.AddObject(Player);
            var random = new Random();
            for (int i = 0; i < 5; i++)
            {
                var enemy = new Enemy(new(random.Next(Position.Right + 1), random.Next(Position.Bottom + 1)));
                enemy.PlayField = this;
                Game.AddObject(enemy);
            }
        }

        public override void Update(GameTime gameTime)
        {
           
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(backgroundTexture, Position, null, Color.White, 0, Vector2.Zero, SpriteEffects.None, 1f);
        }
    }
}
