using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace XNAMapContentSolution
{

    public class MapTile
    {
        private Rectangle _floorTile;
        private Rectangle _wallTile;
        private Rectangle _featureTile;
        private Rectangle[] _floorItems;

        private Rectangle _position;

        private bool _isBlocked;
        public bool IsBlocked
        {
            get
            {
                return _isBlocked;
            }
        }

        private void Initialize(Rectangle floorTile, Rectangle wallTile, Rectangle featureTile, Rectangle[] floorItems, Rectangle position)
        {
            _floorTile = floorTile;
            _wallTile = wallTile;
            _featureTile = featureTile;
            _floorItems = floorItems;
            _position = position; 
        }

        public void Initialize(Rectangle wallTile, Rectangle position)
        {
            _wallTile = wallTile;
            _position = position;
            _isBlocked = true;
        }

        public void Initialize(Rectangle floorTile, Rectangle featureTile, Rectangle[] floorItems, Rectangle position)
        {
            _floorTile = floorTile;
            _featureTile = featureTile;
            _floorItems = floorItems;
            _position = position;
            _isBlocked = false;
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (!_floorTile.IsEmpty)
            {
                spriteBatch.Draw(FloorTiles.FloorSheet, _position, _floorTile, Color.White);
            }
            else if (!_wallTile.IsEmpty)
            {
                spriteBatch.Draw(WallTiles.WallSheet, _position, _wallTile, Color.White);
            }
        }
    }
}
