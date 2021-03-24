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
        public int XPositionInBoard { get; set; }
        public int YPositionInBoard { get; set; }
        public abstract GemType Type { get; }
        public abstract string texturePath { get; }
        public bool IsSelected { get; set; }

        private MouseState lastMouseState;
        private Rectangle area;
        private Texture2D sprite;
        private Texture2D selectorSprite;
        private readonly GraphicsDevice graphicsDevice;

        public Gem(GraphicsDevice graphicsDevice)
        {
            this.graphicsDevice = graphicsDevice;
            sprite = Texture2D.FromFile(graphicsDevice, texturePath);
            selectorSprite = Texture2D.FromFile(graphicsDevice, "Assets/Gameplay/selectionBox.png");
        }

        public override void Update(GameTime gameTime)
        {
            var mouseState = Mouse.GetState();
            if (lastMouseState.LeftButton == ButtonState.Released && mouseState.LeftButton == ButtonState.Pressed && area.Intersects(new Rectangle(mouseState.Position, new Point(20))))
            {
                if (IsSelected)
                {
                    Board.DeselectGem(this);
                }
                else
                {
                    if (Board.LastSelected is null)
                    {
                        Board.SelectGem(this);
                    }
                    else
                    {
                        
                        Board.SwapGems(this, Board.LastSelected);
                        Board.DeselectGem(Board.LastSelected);
                    }
                }
            }
            lastMouseState = mouseState;
            area = new Rectangle((int)Position.X, (int)Position.Y, 50, 50);
        }
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite, area, Color.White);
            if (IsSelected)
                spriteBatch.Draw(selectorSprite, area, Color.White);
        }

    }
}
