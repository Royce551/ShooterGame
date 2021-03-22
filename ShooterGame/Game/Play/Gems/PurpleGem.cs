using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShooterGame.Game.Play.Gems
{
    public class PurpleGem : Gem
    {
        public override GemType Type => GemType.PurpleGem;
        public override string texturePath => "Assets/Gameplay/purpleGem.png";

        public PurpleGem(GraphicsDevice graphicsDevice) : base(graphicsDevice)
        {

        }
    }
}

