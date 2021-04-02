using Microsoft.Xna.Framework;
using ShooterGame.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShooterGame.Game.Screens.Play.Characters
{
    public abstract class Character : GameObject, ICollideableThing
    {
        public PlayField PlayField { get; set; }

        public Vector2 relativePosition; // TODO: figure out what to do with this
        public Vector2 RelativePosition { get => relativePosition; init => relativePosition = value; }
        public Vector2 AbsolutePosition
        {
            get => new(RelativePosition.X + PlayField.Position.X, RelativePosition.Y + PlayField.Position.Y);
        }


        public abstract int Health { get; set; }
        public Rectangle HitBox { get; set; }

        public void OnCollision(ICollideableThing collided)
        {
            
        }
    }
}
