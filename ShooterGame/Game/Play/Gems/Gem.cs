using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShooterGame.Game.Play.Gems
{
    public abstract class Gem : Object
    {
        public Board Board { get; set; }
     
        public Vector2 Position { get; set; }
        public abstract GemType Type { get; }
        public abstract string texturePath { get; }
        public bool IsSelected { get; set; }

        private MouseState lastMouseState;
        private Rectangle area;
        private Texture2D texture;
        private readonly GraphicsDevice graphicsDevice;

        public Gem(GraphicsDevice graphicsDevice)
        {
            this.graphicsDevice = graphicsDevice;
            texture = Texture2D.FromFile(graphicsDevice, texturePath);
        }

        public override void Update(GameTime gameTime)
        {
            var mouseState = Mouse.GetState();
            if (lastMouseState.LeftButton == ButtonState.Released && mouseState.LeftButton == ButtonState.Pressed)
            {
                if (IsSelected)
                {
                    IsSelected = false;
                }
                else
                {
                    if (Board.LastSelected is null)
                    {
                        IsSelected = true;
                        Board.LastSelected = this;
                    }
                    else Board.LastSelected.IsSelected = false;
                }
            }
            lastMouseState = mouseState;
            area = new Rectangle((int)Position.X, (int)Position.Y, 50, 50);
        }
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, area, Color.White);
            if (IsSelected)
            {
                spriteBatch.Draw(texture, new Rectangle(area.X + 50, area.Y + 50, area.Width, area.Height), Color.White);
            }
        }
    }
}
