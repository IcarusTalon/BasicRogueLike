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

        private Point? _centerPoint = null;
        public Point CenterPoint
        {
            get
            {
                if (_centerPoint == null)
                {
                    _centerPoint = new Point(UpperLeftCorner.X + ((RoomUpperLeftCorner.X + RoomWidth) / 2), UpperLeftCorner.Y + ((RoomUpperLeftCorner.Y + RoomHeight) / 2));
                }

                return _centerPoint.Value;
            }
        }

        //private Random _random;

        public MapCell()
        {
            //_random = new Random(); 
        }

        internal void GenerateRoom(Random _random)
        {
            RoomWidth = _random.Next(3, Width - 2 + 1);
            RoomHeight = _random.Next(3, Height - 2 + 1);
            RoomUpperLeftCorner.X = _random.Next(1, (Width - RoomWidth));
            RoomUpperLeftCorner.Y = _random.Next(1, (Height - RoomHeight));

            TileValues = new int[Width, Height];

            for (int w = 0; w < Width; w++)
            {
                for (int h = 0; h < Height; h++)
                {

                    //TODO: Take out - draw outline for testing purpose...
                    //if (w == 0 || h == 0 || w == Width - 1 || h == Height - 1)
                    //{
                    //    TileValues[w, h] = 101;

                    //}
                    if (1 == 0)
                    { }
                    else
                    {
                        if (w >= RoomUpperLeftCorner.X && w <= RoomUpperLeftCorner.X + RoomWidth)
                        {
                            if (h >= RoomUpperLeftCorner.Y && h <= RoomUpperLeftCorner.Y + RoomHeight)
                            {
                                //Floor of room...
                                TileValues[w, h] = 1;
                            }
                        }


                        if (TileValues[w, h] == 0)
                        {
                            TileValues[w, h] = 100;
                        }
                    }
                }
            }
        }
    }
}
