using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShooterGame.Game.Play.Gems
{
    public class GreenGem : Gem
    {
        public override GemType Type => GemType.GreenGem;
        public override string texturePath => "Assets/Gameplay/greenGem.png";

        public GreenGem(GraphicsDevice graphicsDevice) : base(graphicsDevice)
        {

        }
    }
}

