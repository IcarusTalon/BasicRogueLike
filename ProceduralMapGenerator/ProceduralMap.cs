using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace ProceduralMapGenerator
{
    public class ProceduralMap
    {
        private int _minimumMapDimension = 20;
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

            Height = _random.Next(_minimumMapDimension, _maximumMapDimension);
            Width = _random.Next(_minimumMapDimension, _maximumMapDimension);

            _mapCells = new List<MapCell>();
            _mapCells.Add(new MapCell { Height = Height, Width = Width });

            GenerateMap();
        }

        private void GenerateMap()
        {
            int previousNumberOfCells = 0;

            while (previousNumberOfCells != _mapCells.Count)
            {
                previousNumberOfCells = _mapCells.Count;

                for (int i = _mapCells.Count - 1; i >= 0; i--)
                {
                    SplitCell(i);
                }
            }

            CellValues = new int[Height, Width];

            int currentCellX = 0;
            int currentCellY = 0;

            int currentX = 0;
            int currentY = 0;

            foreach (MapCell currentMapCell in _mapCells)
            {
                currentMapCell.GenerateRoom();
                currentX =  currentCellX;
                for (int i = 0; i < currentMapCell.Height; i++)
                {
                    for (int j = 0; j < currentMapCell.Width; j++)
                    {
                        CellValues[currentY, currentX] = currentMapCell.Value;
                        currentY++;
                    }
                    currentY = currentCellY;
                    currentX++;
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

                    _mapCells.Insert(indexOfMapCellToSplit + 1, new MapCell { Height = _mapCells[indexOfMapCellToSplit].Height, Width = newCellWidth });
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

                    _mapCells.Insert(indexOfMapCellToSplit + 1, new MapCell { Height = newCellHeight, Width = _mapCells[indexOfMapCellToSplit].Width });
                }
            }
        }

    }
}
