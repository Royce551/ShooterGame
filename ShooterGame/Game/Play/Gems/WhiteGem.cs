using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShooterGame.Game.Play.Gems
{
    public class WhiteGem : Gem
    {
        public override GemType Type => GemType.WhiteGem;
        public override string texturePath => "Assets/Gameplay/whiteGem.png";

        public WhiteGem(GraphicsDevice graphicsDevice) : base(graphicsDevice)
        {

        }
    }
}
