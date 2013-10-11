using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace TileMapping
{
    public static class FeatureTile
    {
        private static int _height = 32;
        private static int _width = 32;

        public static Texture2D FeaturesSheet;

        private static Rectangle _downStairs;
        public static Rectangle DownStairs
        {
            get
            {
                if (_downStairs.IsEmpty)
                {
                    _downStairs = new Rectangle(4 * _height, 19 * _width, _height, _width);
                }

                return _downStairs;
            }
        }

        private static Rectangle _upStairs;
        public static Rectangle UpStairs
        {
            get
            {
                if (_upStairs.IsEmpty)
                {
                    _upStairs = new Rectangle(4 * _height, 20 * _width, _height, _width);
                }

                return _upStairs;
            }
        }
    }
}
