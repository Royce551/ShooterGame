using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShooterGame.Game.Play.Gems
{
    public class YellowGem : Gem
    {
        public override GemType Type => GemType.YellowGem;
        public override string texturePath => "Assets/Gameplay/yellowGem.png";

        public YellowGem(GraphicsDevice graphicsDevice) : base(graphicsDevice)
        {

        }
    }
}
