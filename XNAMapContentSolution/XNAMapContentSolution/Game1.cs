using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.Diagnostics;
using ProceduralMapGenerator;

namespace XNAMapContentSolution
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager _graphics;
        SpriteBatch _spriteBatch;

        private KeyboardState _currentKeyboardState;
        private KeyboardState _previousKeyboardState;

        private MouseState _mouseState;

        private List<Keys> keysPressed;
        private Keys _lastKeyPressed;

        private bool _canPressKey;

        private Queue<Keys> keysQueue;

        private TimeSpan _lastPlayerUpdate;
        private TimeSpan _lastKeyPress;

        private Map _map;

        Player _player;
        Camera _camera;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            _graphics.IsFullScreen = false;
            _graphics.PreferredBackBufferHeight = 768;
            _graphics.PreferredBackBufferWidth = 1024;

            Content.RootDirectory = "Content";

            keysPressed = new List<Keys>();
            keysQueue = new Queue<Keys>();


            _map = new Map();
            _player = new Player();
            _lastPlayerUpdate = TimeSpan.FromMilliseconds(0);
            _lastKeyPress = TimeSpan.FromMilliseconds(0);
            _canPressKey = true;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            _map.Initialize();
            _player.Initialize(_map.MapDimensions.X / 2, _map.MapDimensions.Y / 2);
            
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            PlayerSprite.SpriteSheet = Content.Load<Texture2D>("player");
            WallTiles.WallSheet = Content.Load<Texture2D>("wall");
            FloorTiles.FloorSheet = Content.Load<Texture2D>("floor");

            _camera = new Camera(GraphicsDevice.Viewport);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
             _mouseState = Mouse.GetState();
             _camera.Zoom = ((float) _mouseState.ScrollWheelValue * .001f) + 1.0f;

            _previousKeyboardState = _currentKeyboardState;
            _currentKeyboardState = Keyboard.GetState();

            PlayerUpdate(gameTime);
            _camera.Update(_player.CameraPosition);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, null, null, null, null, _camera.Transform);

          
            _map.Draw(gameTime, _spriteBatch);

            _player.Draw(gameTime, _spriteBatch);
            _spriteBatch.End();

            base.Draw(gameTime);
        }

        private void PlayerUpdate(GameTime gameTime)
        {
            //_player.Update(gameTime);
            //if (gameTime.TotalGameTime > _lastPlayerUpdate.Add(TimeSpan.FromMilliseconds(300)))
            //{
                //if (_previousKeyboardState.IsKeyDown(Keys.L) && _currentKeyboardState.IsKeyUp(Keys.L))
                //{
                //    _player.Move(Direction.Right);
                //    _lastPlayerUpdate = gameTime.TotalGameTime; 
                //}
                //else if (_previousKeyboardState.IsKeyDown(Keys.K) && (_currentKeyboardState.IsKeyUp(Keys.K) ||gameTime.TotalGameTime > _lastPlayerUpdate.Add(TimeSpan.FromMilliseconds(500))))
                //{
                //    _player.Move(Direction.Left);
                //    _lastPlayerUpdate = gameTime.TotalGameTime; 
                //}



                if ((IsKeyPressed(Keys.W) || IsKeyPressed(Keys.NumPad8)) && !_map.IsBlocked(_player.CurrentPosition, Direction.Up))
                {
                    _player.Move(Direction.Up);
                }
                else if (IsKeyPressed(Keys.NumPad9) && !_map.IsBlocked(_player.CurrentPosition, Direction.UpRight))
                {
                    _player.Move(Direction.UpRight);
                }
                else if ((IsKeyPressed(Keys.D) || IsKeyPressed(Keys.NumPad6)) && !_map.IsBlocked(_player.CurrentPosition, Direction.Right))
                {
                    _player.Move(Direction.Right);
                }
                else if (IsKeyPressed(Keys.NumPad3) && !_map.IsBlocked(_player.CurrentPosition, Direction.DownRight))
                {
                    _player.Move(Direction.DownRight);
                }
                else if ((IsKeyPressed(Keys.S) || IsKeyPressed(Keys.NumPad2)) && !_map.IsBlocked(_player.CurrentPosition, Direction.Down))
                {
                    _player.Move(Direction.Down);
                }
                else if (IsKeyPressed(Keys.NumPad1) && !_map.IsBlocked(_player.CurrentPosition, Direction.DownLeft))
                {
                    _player.Move(Direction.DownLeft);
                }
                else if ((IsKeyPressed(Keys.A) || IsKeyPressed(Keys.NumPad4)) && !_map.IsBlocked(_player.CurrentPosition, Direction.Left))
                {
                    _player.Move(Direction.Left);
                }
                else if (IsKeyPressed(Keys.NumPad7) && !_map.IsBlocked(_player.CurrentPosition, Direction.UpLeft))
                {
                    _player.Move(Direction.UpLeft);
                }

                
            //}
            

        }

        private bool IsKeyPressed(Keys keyCheck)
        {
            bool returnValue = false;
            if (_previousKeyboardState.IsKeyDown(keyCheck) && _currentKeyboardState.IsKeyUp(keyCheck))
            {
                returnValue = true;
            }
            return returnValue;
        }
    }
}
