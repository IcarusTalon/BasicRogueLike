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
        private Point roomUpperLeftCornerReleativeToCell;
        public int[,] TileValues;

        private Point? _roomUpperLeftCorner;
        public Point RoomUpperLeftCorner
        {
            get
            {
                if (_roomUpperLeftCorner == null)
                {
                    _roomUpperLeftCorner = new Point(UpperLeftCorner.X + roomUpperLeftCornerReleativeToCell.X, UpperLeftCorner.Y + roomUpperLeftCornerReleativeToCell.Y);
                }
                return _roomUpperLeftCorner.Value; 
            }
        }
        private Point? _roomCenterPoint = null;
        public Point RoomCenterPoint
        {
            get
            {
                if (_roomCenterPoint == null)
                {
                    _roomCenterPoint = new Point(UpperLeftCorner.X + roomUpperLeftCornerReleativeToCell.X + (RoomWidth / 2), UpperLeftCorner.Y + roomUpperLeftCornerReleativeToCell.Y + (RoomHeight / 2));
                }

                return _roomCenterPoint.Value;
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
            roomUpperLeftCornerReleativeToCell.X = _random.Next(1, (Width - RoomWidth));
            roomUpperLeftCornerReleativeToCell.Y = _random.Next(1, (Height - RoomHeight));

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
                        if (w >= roomUpperLeftCornerReleativeToCell.X && w <= roomUpperLeftCornerReleativeToCell.X + RoomWidth)
                        {
                            if (h >= roomUpperLeftCornerReleativeToCell.Y && h <= roomUpperLeftCornerReleativeToCell.Y + RoomHeight)
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
