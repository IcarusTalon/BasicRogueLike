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

        public int X
        {
            get
            {
                return _position.X;
            }
            set
            {
                _position.X += value * 32;
            }
        }

        public int Y
        {
            get
            {
                return _position.Y;
            }
            set
            {
                _position.Y += value * 32;
            }
        }



        public void Initialize(int x, int y)
        {
            _bodyTexture = PlayerSprite.HumanMale;

            _position = new Rectangle((x * 32) + ((32 - _bodyTexture.Width) / 2), y * 32 + ((32 - _bodyTexture.Height) / 2), _bodyTexture.Width, _bodyTexture.Height);
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
