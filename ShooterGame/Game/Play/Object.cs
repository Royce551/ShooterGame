using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ShooterGame.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShooterGame.Game.Play
{
    public abstract class Object : IDrawableThing
    {
        public GameManager GameManager { get; set; }
        public abstract void Update(GameTime gameTime);
        public abstract void Draw(GameTime gameTime, SpriteBatch spriteBatch);
    }
}
