using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace XNAMapContentSolution
{
    public class Player
    {
        private Rectangle _bodyTexture;

        private Rectangle _position;

        //public Rectangle Position
        //{
        //    get
        //    {
        //        return _position;
        //    }
        //}

        private int _x;
        private int _y;

        public int X
        {
            get
            {
                return _x;
            }
            set
            {
                _x = value;
                _position.X = (_x * 32) + ((32 - _bodyTexture.Width) / 2);
            }
        }

        public int Y
        {
            get
            {
                return _y;
            }
            set
            {
                _y = value;
                _position.Y = _y * 32 + ((32 - _bodyTexture.Height) / 2);
            }
        }



        public void Initialize(int x, int y)
        {
            _bodyTexture = PlayerSprite.HumanMale;
            _position = new Rectangle((x * 32) + ((32 - _bodyTexture.Width) / 2), y * 32 + ((32 - _bodyTexture.Height) / 2), _bodyTexture.Width, _bodyTexture.Height);

            _x = x;
            _y = y;

        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(PlayerSprite.SpriteSheet, _position , _bodyTexture, Color.White);
        }

        //public void Update(GameTime gameTime)
        //{
        //    _position.X += _position.X;
        //    _position.Y += _position.Y;
        //}


    }
}
