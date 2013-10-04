﻿using System;
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

        private int X
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

        private int Y
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

        public Point CurrentPosition
        {
            get
            {
                return new Point(X, Y);
            }
        }

        public void Move(Direction direction)
        {
            switch (direction)
            {
                case Direction.Up:
                    Y += -1;
                    break;
                case Direction.UpRight:
                    Y += -1;
                    X += 1;
                    break;
                case Direction.Right:
                    X += 1;
                    break;
                case Direction.DownRight:
                    Y += 1;
                    X += 1;
                    break;
                case Direction.Down:
                    Y += 1;
                    break;
                case Direction.DownLeft:
                    Y += 1;
                    X += -1;
                    break;
                case Direction.Left:
                    X += -1;
                    break;
                case Direction.UpLeft:
                    Y += -1;
                    X += -1;
                    break;
            }
        }

        //public void MoveUp()
        //{
        //    Y += -1;
        //}

        //public void MoveUpRight()
        //{
        //    Y += -1;
        //    X += 1; 
        //}

        //public void MoveRight()
        //{
        //    X += 1;
        //}

        //public void MoveDownRight()
        //{
        //    Y += 1;
        //    X += 1; 
        //}

        //public void MoveDown()
        //{
        //    Y += 1;
        //}

        //public void MoveDownLeft()
        //{
        //    Y += 1;
        //    X += -1;
        //}

        //public void MoveLeft()
        //{
        //    X += -1;
        //}

        //public void MoveUpLeft()
        //{
        //    Y += -1;
        //    X += -1; 
        //}



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
