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

        private int _height;
        private int _width;

        private Random _random;

        private List<MapCell> _mapCells;
        private int[,] _cellValues;

        public ProceduralMap()
        {
            _random = new Random();

            _height = _random.Next(_minimumMapDimension, _maximumMapDimension);
            _width = _random.Next(_minimumMapDimension, _maximumMapDimension);

            _mapCells = new List<MapCell>();
            _mapCells.Add(new MapCell { Height = _height, Width = _width }); 
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

            _cellValues = new int[_height, _width];

            int currentX = 0;
            int currentY = 0;

            foreach (MapCell currentMapCell in _mapCells)
            {
                currentMapCell.GenerateRoom();

            //for (int i = 0; i < currentMapCell.Width; i++)
            //{
            //    for (int j = 0; j < _width; j++)
            //    {

 
            //    }
            //}




            }

        }

        private void SplitCell(int indexOfMapCellToSplit)
        {
            SplitX(indexOfMapCellToSplit);
            SplitY(indexOfMapCellToSplit);
        }

        private bool SplitX(int indexOfMapCellToSplit)
        {
            bool returnValue = false;

            //if the width can be split into to cells large enough to hold a room (at least 10 wide)
            if (_mapCells[indexOfMapCellToSplit].Width - 10 > 0)
            {
                if (_random.Next(_mapCells[indexOfMapCellToSplit].Width) > _chanceToSplit)
                {
                    //Calculate width of the old cell and new cell

                    int oldCellWidth = _mapCells[indexOfMapCellToSplit].Width;
                    int newCellWidth = _random.Next(5, oldCellWidth - 5);
                    oldCellWidth = oldCellWidth - newCellWidth;

                    //change width of old cell

                    _mapCells[indexOfMapCellToSplit].Width = oldCellWidth;


                    //Create new cell at index of old with new width

                    _mapCells.Insert(indexOfMapCellToSplit, new MapCell { Height = _mapCells[indexOfMapCellToSplit].Height, Width = newCellWidth });
                    returnValue = true;
                }
            }

            return returnValue;

        }

        private bool SplitY(int indexOfMapCellToSplit)
        {
            bool returnValue = false;

            //if the width can be split into to cells large enough to hold a room (at least 10 wide)
            if (_mapCells[indexOfMapCellToSplit].Height - 10 > 0)
            {
                if (_random.Next(_mapCells[indexOfMapCellToSplit].Height) > _chanceToSplit)
                {
                    //Calculate width of the old cell and new cell

                    int oldCellHeight = _mapCells[indexOfMapCellToSplit].Height;
                    int newCellHeight = _random.Next(5, oldCellHeight - 5);
                    oldCellHeight = oldCellHeight - newCellHeight;

                    //change width of old cell

                    _mapCells[indexOfMapCellToSplit].Height = oldCellHeight;


                    //Create new cell at index of old with new width

                    _mapCells.Insert(indexOfMapCellToSplit, new MapCell { Height = newCellHeight, Width = _mapCells[indexOfMapCellToSplit].Width });
                    returnValue = true;
                }
            }

            return returnValue;
        }

    }
}
