using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ShooterGame.Framework;
using ShooterGame.Game.Screens.Play.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShooterGame.Game.Screens.Play
{
    public class PlayField : GameObject
    {
        public Rectangle Position { get; init; }
        public double GameSpeed { get; private set; }
        public Player Player { get; private set; }

        private Texture2D texture;
        public PlayField(Rectangle position)
        {
            Position = position;
        }

        public override void Initialize()
        {
            texture = Texture2D.FromFile(Game.GraphicsDevice, "Assets/[ Pink Dreams ].png");
            Player = new Player();
            Player.PlayField = this;
            Game.AddObject(Player);
        }

        public override void Update(GameTime gameTime)
        {
           
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, Position, null, Color.White, 0, Vector2.Zero, SpriteEffects.None, 1f);
        }
    }
}
