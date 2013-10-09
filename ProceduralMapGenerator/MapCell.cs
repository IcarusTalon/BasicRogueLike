using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace ProceduralMapGenerator
{

    class MapCell
    {
        public Point UpperLeftCorner;
        public int Width;
        public int Height;
        public int RoomWidth;
        public int RoomHeight;
        public Point RoomUpperLeftCorner;
        public int Value;

        private Random _random;

        internal void GenerateRoom()
        {
            _random = new Random();
            RoomWidth = _random.Next(3, Width - 2);
            RoomHeight = _random.Next(3, Height - 2);
            RoomUpperLeftCorner.X = _random.Next(1, (Width - RoomWidth) / 2);
            RoomUpperLeftCorner.Y = _random.Next(1, (Height - RoomHeight) / 2);

            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    if (i > RoomUpperLeftCorner.X && i < RoomUpperLeftCorner.X + RoomWidth)
                    {
                        if (j > RoomUpperLeftCorner.Y && j < RoomUpperLeftCorner.Y + RoomHeight)
                        {
                            //Floor of room...
                            Value = 1;
                        }
                        else
                        {
                            Value = 100;
                        }
                    }
 
                }
            }
        }
    }
}
