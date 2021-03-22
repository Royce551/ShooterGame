using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShooterGame.Game.Play.Gems
{
    public class OrangeGem : Gem
    {
        public override GemType Type => GemType.OrangeGem;
        public override string texturePath => "Assets/Gameplay/orangeGem.png";

        public OrangeGem(GraphicsDevice graphicsDevice) : base(graphicsDevice)
        {

        }
    }
}
