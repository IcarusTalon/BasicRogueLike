using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace XNAMapContentSolution
{
    public static class FloorTiles
    {
        private static int _height = 32;
        private static int _width = 32;

        private static Rectangle _greentTile;
        public static Rectangle GreentTile
        {
            get
            {
                if (_greentTile.IsEmpty)
                {
                    _greentTile = new Rectangle(0, _height * 3, _height, _width);
                }

                return _greentTile;
            }
 
        }

        
    }
}
