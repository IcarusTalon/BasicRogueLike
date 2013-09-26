using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace XNAMapContentSolution
{
    public enum MapType
    {
        Wall = 1,
        Floor
    }

    public class MapTile
    {
        public MapType MapType;
        public Rectangle DestinationRectangle; 
    }


    public class Map
    {
        private MapTile[,] _mapTiles;
        int _rowNumber = 3;
        int _columnNumber = 3;

        public void Initialize()
        {
            
            _mapTiles = new MapTile[_rowNumber, _columnNumber];

            for (int row = 0; row < _rowNumber; row++)
            {
                for (int column = 0; column < _columnNumber; column++)
                {
                    _mapTiles[row, column] = new MapTile();
                    if (row == 1 && column == 1)
                    {

                        _mapTiles[row, column].MapType = MapType.Floor;
                        _mapTiles[row, column].DestinationRectangle = new Rectangle(column * 32, row * 32, 32, 32);
                    }
                    else
                    {

                        _mapTiles[row, column].MapType = MapType.Wall;
                        _mapTiles[row, column].DestinationRectangle = new Rectangle(column * 32, row * 32, 32, 32);
                    }

                }

            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {


            for (int row = 0; row < _rowNumber; row++)
            {
                for (int column = 0; column < _columnNumber; column++)
                {
                    switch (_mapTiles[row, column].MapType)
                    {
                        case MapType.Wall:
                            spriteBatch.Draw(WallTiles.WallSheet, _mapTiles[row, column].DestinationRectangle, WallTiles.GreentWalls[0], Color.White);
                            break;
                        case MapType.Floor:
                            spriteBatch.Draw(FloorTiles.FloorSheet, _mapTiles[row, column].DestinationRectangle, FloorTiles.GreentTile, Color.White);
                            break;
                    }
                }
            }

            
 
        }
    }
}
