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

        public MapTile this[int X, int Y]
        {
            get
            {
                return _mapTiles[X, Y]; 
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

                for (int i = mapRowsTemp.Count() - 1; i >= 0 ; i--)
                {
                    mapColumnTemp = mapRowsTemp[i].Split(',');
                    for (int j = mapColumnTemp.Count() - 1; j >= 0; j--)
                    {
                        currentTile = (MapTileType)int.Parse(mapColumnTemp[j].Trim());
                        Rectangle positionRectangle = new Rectangle(j * 32, i * 32, 32, 32);
                        _mapTiles[j, i] = new MapTile();

                        switch(currentTile)                        
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

            //for (int row = 0; row < _rowNumber; row++)
            //{
            //    for (int column = 0; column < _columnNumber; column++)
            //    {
            //        _mapTiles[row, column] = new MapTile();
            //        if (row == 1 && column == 1)
            //        {
            //            _mapTiles[row, column].Initialize(FloorTiles.GreentTile, new Rectangle(), new Rectangle[]{new Rectangle()}, new Rectangle(row * 32, column * 32, 32, 32));
            //        }
            //        else
            //        {
            //            _mapTiles[row, column].Initialize(WallTiles.GreentWalls[0], new Rectangle(column * 32, row * 32, 32, 32));
            //        }

            //    }

            //}
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {


            for (int row = 0; row < _mapTiles.GetLength(0); row++)
            {
                for (int column = 0; column < _mapTiles.GetLength(1); column++)
                {
                    //switch (_mapTiles[row, column].MapType)
                    //{
                    //    case MapType.Wall:
                    //        spriteBatch.Draw(WallTiles.WallSheet, _mapTiles[row, column].DestinationRectangle, WallTiles.GreentWalls[0], Color.White);
                    //        break;
                    //    case MapType.Floor:
                    //        spriteBatch.Draw(FloorTiles.FloorSheet, _mapTiles[row, column].DestinationRectangle, FloorTiles.GreentTile, Color.White);
                    //        break;
                    //}

                    _mapTiles[row, column].Draw(gameTime, spriteBatch);
                }
            }

            
 
        }
    }
}
