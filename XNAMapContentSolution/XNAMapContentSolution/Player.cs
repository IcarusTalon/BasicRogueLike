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

        private int _x;
        //public int X
        //{
        //    get
        //    {
        //        return _x;
        //    }
        //    set
        //    {
        //        _x = value;
        //    }
        //}

        private int _y;



        public void Initialize(int x, int y)
        {
            _bodyTexture = PlayerSprite.HumanMale;
            _x = x;
            _y = y;

            _position = new Rectangle(_x * 32, _y * 32, 32, 32);
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(PlayerSprite.SpriteSheet, _position , _bodyTexture, Color.White);
        }

        public void Update(int x, int y)
        {
            _x = x;
            _y = y;

            _position = new Rectangle(_x * 32, _y * 32, 32, 32);
        }
    }
}
