using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShooterGame.Game.Play.Gems
{
    public class BlueGem : Gem
    {
        public override GemType Type => GemType.BlueGem;
        public override string texturePath => "Assets/Gameplay/blueGem.png";

        public BlueGem(GraphicsDevice graphicsDevice) : base(graphicsDevice)
        {

        }
    }
}
