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
        public int[,] TileValues;

        private Point _centerPoint;
        public Point CenterPoint
        {
            get
            {
                if (_centerPoint == null)
                {
                    _centerPoint = new Point(UpperLeftCorner.X + ((RoomUpperLeftCorner.X + RoomWidth) / 2), UpperLeftCorner.Y + ((RoomUpperLeftCorner.Y + RoomHeight) / 2));
                }

                return _centerPoint;
            }
        }

        private Random _random;

        internal void GenerateRoom()
        {
            _random = new Random();
            RoomWidth = _random.Next(3, Width - 2);
            RoomHeight = _random.Next(3, Height - 2);
            RoomUpperLeftCorner.X = _random.Next(1, (Width - RoomWidth) / 2);
            RoomUpperLeftCorner.Y = _random.Next(1, (Height - RoomHeight) / 2);

            TileValues = new int[Width, Height];

            for (int w = 0; w < Width; w++)
            {
                for (int h = 0; h < Height; h++)
                {
                    if (w > RoomUpperLeftCorner.X && w < RoomUpperLeftCorner.X + RoomWidth)
                    {
                        if (h > RoomUpperLeftCorner.Y && h < RoomUpperLeftCorner.Y + RoomHeight)
                        {
                            //Floor of room...
                            TileValues[w, h] = 1;
                        }
                        else
                        {
                            TileValues[w, h] = 100;
                        }
                    }
 
                }
            }
        }
    }
}
