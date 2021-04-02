using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShooterGame.Framework
{
    public interface ICollideableThing
    {
        public Rectangle HitBox { get; set; }

        public void OnCollision(ICollideableThing collided);
    }
}
