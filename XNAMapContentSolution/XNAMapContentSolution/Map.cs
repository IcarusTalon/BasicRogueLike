using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.IO;

namespace XNAMapContentSolution
{


    public class Map
    {
        private MapTile[,] _mapTiles;
        int _rowNumber = 3;
        int _columnNumber = 3;

        public MapTile this[float X, float Y]
        {
            get
            {
                return _mapTiles[(int)X, (int)Y];
            }
        }


        public void Initialize()
        {

            _mapTiles = new MapTile[_rowNumber, _columnNumber];


            string mapTemp = string.Empty;
            string[] mapRowsTemp;
            string[] mapColumnTemp;

            MapTileType currentTile;
            using (StreamReader streamReader = new StreamReader("MapTest1.txt"))
            {
                mapTemp = streamReader.ReadToEnd();
                mapRowsTemp = mapTemp.Split('\n');
                mapColumnTemp = mapRowsTemp[0].Split(',');


                _mapTiles = new MapTile[mapColumnTemp.Count(), mapRowsTemp.Count()];
                Random random = new Random();

                for (int i = mapRowsTemp.Count() - 1; i >= 0; i--)
                {
                    mapColumnTemp = mapRowsTemp[i].Split(',');
                    for (int j = mapColumnTemp.Count() - 1; j >= 0; j--)
                    {
                        currentTile = (MapTileType)int.Parse(mapColumnTemp[j].Trim());
                        Rectangle positionRectangle = new Rectangle(j * 32, i * 32, 32, 32);
                        _mapTiles[j, i] = new MapTile();

                        switch (currentTile)
                        {
                            //Walls
                            case MapTileType.GreenWall:
                                if (random.Next(0, 10) == 0)
                                {
                                    _mapTiles[j, i].Initialize(WallTiles.GreentWalls[random.Next(0, 20)], positionRectangle);
                                }
                                else
                                {
                                    _mapTiles[j, i].Initialize(WallTiles.GreentWalls[0], positionRectangle);
                                }
                                break;


                            //Floors
                            case MapTileType.GreenFloor:
                                _mapTiles[j, i].Initialize(FloorTiles.GreentTile, new Rectangle(), new Rectangle[] { new Rectangle() }, positionRectangle);
                                break;

                        }

                    }

                }
            }
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            for (int row = 0; row < _mapTiles.GetLength(0); row++)
            {
                for (int column = 0; column < _mapTiles.GetLength(1); column++)
                {
                    _mapTiles[row, column].Draw(gameTime, spriteBatch);
                }
            }
        }

        public bool IsBlocked(Vector2 startPoint, Direction direction)
        {
            bool isBlocked = false;

            switch (direction)
            {
                case Direction.Up:
                    if (this[startPoint.X, startPoint.Y - 1].IsBlocked)
                    {
                        isBlocked = true;
                    }
                    break;
                case Direction.UpRight:
                    if (this[startPoint.X + 1, startPoint.Y - 1].IsBlocked)
                    {
                        isBlocked = true;
                    }
                    break;
                case Direction.Right:
                    if (this[startPoint.X + 1, startPoint.Y].IsBlocked)
                    {
                        isBlocked = true;
                    }
                    break;
                case Direction.DownRight:
                    if (this[startPoint.X + 1, startPoint.Y + 1].IsBlocked)
                    {
                        isBlocked = true;
                    }
                    break;
                case Direction.Down:
                    if (this[startPoint.X, startPoint.Y + 1].IsBlocked)
                    {
                        isBlocked = true;
                    }
                    break;
                case Direction.DownLeft:
                    if (this[startPoint.X - 1, startPoint.Y + 1].IsBlocked)
                    {
                        isBlocked = true;
                    }
                    break;
                case Direction.Left:
                    if (this[startPoint.X - 1, startPoint.Y].IsBlocked)
                    {
                        isBlocked = true;
                    }
                    break;
                case Direction.UpLeft:
                    if (this[startPoint.X - 1, startPoint.Y - 1].IsBlocked)
                    {
                        isBlocked = true;
                    }
                    break;
            }

            return isBlocked;
        }
    }
}
