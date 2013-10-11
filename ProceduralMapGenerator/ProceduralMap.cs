using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace ProceduralMapGenerator
{
    public class ProceduralMap
    {
        private int _minimumMapDimension = 50;
        private int _maximumMapDimension = 100;

        private int _chanceToSplit = 10;

        public int Height;
        public int Width;

        private Random _random;

        private List<MapCell> _mapCells;
        public int[,] CellValues;

        public ProceduralMap()
        {
            _random = new Random();

            Height = _random.Next(_minimumMapDimension, _maximumMapDimension + 1);
            Width = _random.Next(_minimumMapDimension, _maximumMapDimension + 1);

            _mapCells = new List<MapCell>();
            _mapCells.Add(new MapCell { Height = Height, Width = Width, UpperLeftCorner = new Point(0, 0) });

            GenerateMap();
        }

        private void GenerateMap()
        {
            int previousNumberOfCells = 0;

            //TODO: Change loop to split cells based on width(recursively?)
            while (previousNumberOfCells != _maximumMapDimension / 30)
            {
                previousNumberOfCells++;

                for (int i = _mapCells.Count - 1; i >= 0; i--)
                {
                    SplitCell(i);
                }
            }

            CellValues = new int[Width, Height];

            for(int i = 0; i < _mapCells.Count; i++)
            {
                MapCell currentMapCell = _mapCells[i];
                //MapCell nextMapCell;
                //if (i == _mapCells.Count - 1)
                //{
                //    nextMapCell = _mapCells[0];
                //}
                //else
                //{
                //    nextMapCell = _mapCells[i + 1];
                //}

                currentMapCell.GenerateRoom(_random);

                for (int w = 0; w < currentMapCell.Width; w++)
                {
                    for (int h = 0; h < currentMapCell.Height; h++)
                    {
                        CellValues[currentMapCell.UpperLeftCorner.X + w, currentMapCell.UpperLeftCorner.Y + h] = currentMapCell.TileValues[w, h];
                    }
                }
            }


            for (int i = 0; i < _mapCells.Count; i++)
            {
                MapCell currentMapCell = _mapCells[i];
                MapCell nextMapCell;
                if (i == _mapCells.Count - 1)
                {
                    nextMapCell = _mapCells[0];
                }
                else
                {
                    nextMapCell = _mapCells[i + 1];
                }

                GeneratePath(currentMapCell, nextMapCell);
            }

            int numberOfRooms = _mapCells.Count;
            int numberOfStairs = 0;
            int chanceToCreateStair = 0;

            for (int i = 0; i < _mapCells.Count; i++)
            {
                chanceToCreateStair = _random.Next(numberOfRooms - numberOfStairs, numberOfRooms + 1);

                if (chanceToCreateStair == numberOfRooms)
                {
                    CreateStairCaseDown();
                    numberOfStairs++;
                }
            }
        }

        private void CreateStairCaseDown()
        {
            int cellToGenerateIn = _random.Next(0, _mapCells.Count);
            MapCell currentMapCell = _mapCells[cellToGenerateIn];
            Point coordinatesOfStairs = new Point(_random.Next(currentMapCell.RoomUpperLeftCorner.X, currentMapCell.RoomUpperLeftCorner.X + currentMapCell.RoomWidth), _random.Next(currentMapCell.RoomUpperLeftCorner.Y, currentMapCell.RoomUpperLeftCorner.Y + currentMapCell.RoomHeight));
            CellValues[coordinatesOfStairs.X, coordinatesOfStairs.Y] = 101;
        }

        private void GeneratePath(MapCell currentMapCell, MapCell nextMapCell)
        {
            //CellValues[currentMapCell.RoomCenterPoint.X, currentMapCell.RoomCenterPoint.Y] = 101;
            //CellValues[nextMapCell.RoomCenterPoint.X, nextMapCell.RoomCenterPoint.Y] = 101;

           //CellValues[currentMapCell.UpperLeftCorner.X, currentMapCell.UpperLeftCorner.Y] = 101;
            //CellValues[nextMapCell.UpperLeftCorner.X, nextMapCell.UpperLeftCorner.Y] = 101;

            //CellValues[currentMapCell.RoomUpperLeftCorner.X, currentMapCell.RoomUpperLeftCorner.Y] = 101;
            //CellValues[nextMapCell.RoomUpperLeftCorner.X, nextMapCell.RoomUpperLeftCorner.Y] = 101;
            //return;

            Point currentLocation = currentMapCell.RoomCenterPoint;
            int spacesToMoveX = Math.Abs(currentLocation.X - nextMapCell.RoomCenterPoint.X);
            int spacesToMoveY = Math.Abs(currentLocation.Y - nextMapCell.RoomCenterPoint.Y);
            int totalSpacesToMove = spacesToMoveX + spacesToMoveY;

            //int firstMove = _random.Next(1, totalSpacesToMove + 1);

            //bool LastMovedX = false;
            bool MoveX = false;

            if (_random.Next(1, totalSpacesToMove + 1) < spacesToMoveX && spacesToMoveX > 0)
            {
                MoveX = true;
            }
            else
            {
                MoveX = false;
            }




            while (currentLocation != nextMapCell.RoomCenterPoint)
            {
                if (MoveX)
                {
                    if (currentLocation.X > nextMapCell.RoomCenterPoint.X)
                    {
                        currentLocation.X--;
                    }
                    else
                    {
                        currentLocation.X++;
                    }
                    spacesToMoveX--;
                }
                else
                {
                    if (currentLocation.Y > nextMapCell.RoomCenterPoint.Y)
                    {
                        currentLocation.Y--;
                    }
                    else
                    {
                        currentLocation.Y++;
                    }
                    spacesToMoveY--;
                }
                //if (currentLocation == currentMapCell.RoomCenterPoint || currentLocation == nextMapCell.RoomCenterPoint)
                //{
                //    CellValues[currentLocation.X, currentLocation.Y] = 101;
                //}
                //else
                //{
                    CellValues[currentLocation.X, currentLocation.Y] = 1;
                //}

                //LastMovedX = MoveX;

                //TODO: Broken!!!
                //if last move X, 1 in spacesToMoveY to switch
                //if (MoveX)
                //{
                //    if (spacesToMoveX > 0 && _random.Next(1, spacesToMoveX + 1) == 1)
                //    {
                //        MoveX = false;
                //    }
                //}
                //else
                //{
                //    if (spacesToMoveY > 0 && _random.Next(1, spacesToMoveY + 1) == 1)
                //    {
                //        MoveX = true;
                //    }
                //}
                //if last move Y, 1 in spacesToMoveX to switch 

                if (MoveX && spacesToMoveX == 0)
                {
                    MoveX = false;
                }
                if (!MoveX && spacesToMoveY == 0)
                {
                    MoveX = true;
                }
            }
        }

        private void SplitCell(int indexOfMapCellToSplit)
        {
            SplitX(indexOfMapCellToSplit);
            SplitY(indexOfMapCellToSplit);
        }

        private void SplitX(int indexOfMapCellToSplit)
        {

            //if the width can be split into to cells large enough to hold a room (at least 10 wide)
            if (_mapCells[indexOfMapCellToSplit].Width > 10)
            {
                //TODO: this random calculation sucks. make it so the rooms tend to be larger?
                int randomChanceToSplit = _random.Next(_mapCells[indexOfMapCellToSplit].Width);
                if (randomChanceToSplit > _chanceToSplit)
                {
                    //Calculate width of the old cell and new cell

                    int oldCellWidth = _mapCells[indexOfMapCellToSplit].Width;

                    int newCellWidth = _random.Next(5, oldCellWidth - 5 + 1);
                    oldCellWidth = oldCellWidth - newCellWidth;

                    //change width of old cell

                    _mapCells[indexOfMapCellToSplit].Width = oldCellWidth;


                    //Create new cell at index of old with new width
                    int newUpperLeftCornerX = _mapCells[indexOfMapCellToSplit].UpperLeftCorner.X + oldCellWidth;
                    _mapCells.Insert(indexOfMapCellToSplit + 1, new MapCell { Height = _mapCells[indexOfMapCellToSplit].Height, Width = newCellWidth, UpperLeftCorner = new Point(newUpperLeftCornerX, _mapCells[indexOfMapCellToSplit].UpperLeftCorner.Y) });
                }
            }
        }

        private void SplitY(int indexOfMapCellToSplit)
        {

            //if the width can be split into to cells large enough to hold a room (at least 10 wide)
            if (_mapCells[indexOfMapCellToSplit].Height > 10)
            {
                int randomChanceToSplit = _random.Next(_mapCells[indexOfMapCellToSplit].Height);
                if (randomChanceToSplit > _chanceToSplit)
                {
                    //Calculate width of the old cell and new cell

                    int oldCellHeight = _mapCells[indexOfMapCellToSplit].Height;
                    int newCellHeight = _random.Next(5, oldCellHeight - 5 + 1);
                    oldCellHeight = oldCellHeight - newCellHeight;

                    //change width of old cell

                    _mapCells[indexOfMapCellToSplit].Height = oldCellHeight;


                    //Create new cell at index of old with new width
                    int newUpperLeftCornerY = _mapCells[indexOfMapCellToSplit].UpperLeftCorner.Y + oldCellHeight;
                    _mapCells.Insert(indexOfMapCellToSplit + 1, new MapCell { Height = newCellHeight, Width = _mapCells[indexOfMapCellToSplit].Width, UpperLeftCorner = new Point(_mapCells[indexOfMapCellToSplit].UpperLeftCorner.X, newUpperLeftCornerY) });
                }
            }
        }
    }
}
