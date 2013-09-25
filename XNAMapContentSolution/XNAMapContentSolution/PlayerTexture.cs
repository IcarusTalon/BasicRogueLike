using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace XNAMapContentSolution
{
    public static class PlayerTexture
    {

        public static Texture2D SpriteSheet;

        private static int _tileHeight = 32;
        private static int _tileWidth = 32;
        

        private static Rectangle _humanMale;
        public static Rectangle HumanMale
        {
            get
            {
                if (_humanMale.IsEmpty)
                {
                    _humanMale = new Rectangle(278, 922, 22, 32);
                }

                return _humanMale;
            }
        }
    }
}
