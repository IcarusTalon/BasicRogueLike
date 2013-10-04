using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace XNAMapContentSolution
{
    public class Camera
    {
        private Matrix _transform;
        public Matrix Transform
        {
            get
            {
                return _transform;
            }
        }

        private Vector2 _center;
        private Viewport _viewport;

        private float _zoom = 1;
        private float _rotation = 0;

        public float X
        {
            get
            {
                return _center.X;
            }
            set
            {
                _center.X = value;
            }
        }

        public float Y
        {
            get
            {
                return _center.Y;
            }
            set
            {
                _center.Y = value;
            }
        }

        public float Zoom
        {
            get
            {
                return _zoom;
            }
            set
            {
                _zoom = value;
                {
                    if (_zoom < 0.1f)
                    {
                        _zoom = 0.1f;
                    }
                }
            }
        }

        public float Rotation
        {
            get
            {
                return _rotation;
            }
            set
            {
                _rotation = value;
            }
        }

        public Camera(Viewport newViewPort)
        {
            _viewport = newViewPort;
        }

        public void Update(Vector2 position)
        {
            _center = new Vector2(position.X, position.Y);

            _transform = Matrix.CreateTranslation(new Vector3(-_center.X, -_center.Y, 0)) *
                Matrix.CreateRotationZ(_rotation) * 
                Matrix.CreateScale(new Vector3(Zoom, Zoom, 0)) *
                Matrix.CreateTranslation(new Vector3(_viewport.Width / 2, _viewport.Height / 2, 0));
        }

    }
}
