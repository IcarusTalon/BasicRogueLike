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
        private int _maximumMapDimension = 200;

        private int _chanceToSplit = 10;

        public int Height;
        public int Width;

        private Random _random;

        private List<MapCell> _mapCells;
        public int[,] CellValues;

        public ProceduralMap()
        {
            _random = new Random();

            Height = _random.Next(_minimumMapDimension, _maximumMapDimension);
            Width = _random.Next(_minimumMapDimension, _maximumMapDimension);

            _mapCells = new List<MapCell>();
            _mapCells.Add(new MapCell { Height = Height, Width = Width, UpperLeftCorner = new Point(0, 0) });

            GenerateMap();
        }

        private void GenerateMap()
        {
            int previousNumberOfCells = 0;

            //TODO: Change loop to split cells based on width(recursively?)
            while (previousNumberOfCells != _maximumMapDimension / 20)
            {
                previousNumberOfCells++;

                for (int i = _mapCells.Count - 1; i >= 0; i--)
                {
                    SplitCell(i);
                }
            }

            CellValues = new int[Width, Height];

            foreach (MapCell currentMapCell in _mapCells)
            {
                currentMapCell.GenerateRoom();

                for (int w = 0; w < currentMapCell.Width; w++)
                {
                    for (int h = 0; h < currentMapCell.Height; h++)
                    {
                        CellValues[currentMapCell.UpperLeftCorner.X + w, currentMapCell.UpperLeftCorner.Y + h] = currentMapCell.TileValues[w, h];
                    }
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
                int randomChanceToSplit = _random.Next(_mapCells[indexOfMapCellToSplit].Width);
                if (randomChanceToSplit > _chanceToSplit)
                {
                    //Calculate width of the old cell and new cell

                    int oldCellWidth = _mapCells[indexOfMapCellToSplit].Width;
                    int newCellWidth = _random.Next(5, oldCellWidth - 5);
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
                    int newCellHeight = _random.Next(5, oldCellHeight - 5);
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
