﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace XNAMapContentSolution
{
    public static class WallTiles
    {
        public static Texture2D WallSheet;

        private static int _height = 32;
        private static int _width = 32;

        private static Rectangle[] _greenWalls;
        public static Rectangle[]  GreentWalls
        {
            get
            {
                if (_greenWalls == null)
                {
                    int row = 0;
                    _greenWalls = new Rectangle[20];
                    for (int column = 0; column < 20; column++)
                    {
                        _greenWalls[column] = new Rectangle(_width * column, row, _height, _width);
                    }
                }

                return _greenWalls;
            }

        }
    }
}
