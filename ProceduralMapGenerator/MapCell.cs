using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace ProceduralMapGenerator
{

    public class MapCell
    {
        public int Width;
        public int Height;
        public int RoomWidth;
        public int RoomHeight;
        public Point UpperLeftCorner;

        private Random _random;

        internal void GenerateRoom()
        {
            _random = new Random();
            RoomWidth = _random.Next(3, Width - 2);
            RoomHeight = _random.Next(3, Height - 2);
            UpperLeftCorner.X = _random.Next(1, (Width - 2 - RoomWidth) / 2);
            UpperLeftCorner.Y = _random.Next(1, (Height - 2 - RoomHeight) / 2);
        }
    }
}
