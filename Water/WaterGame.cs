using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Water.Graphics;
using Water.Graphics.Screens;

namespace Water
{
    public class WaterGame : Game
    {
        public GameObjectScreen Screen { get; private set; }
        public virtual string ProjectName { get; }

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private GameObjectManager gameObjectManager;
        private double updatesPerSecond;
        private double drawsPerSecond;

        public WaterGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            _graphics.PreferredBackBufferWidth = 1600;
            _graphics.PreferredBackBufferHeight = 900;
            _graphics.SynchronizeWithVerticalRetrace = false;
            Window.AllowUserResizing = true;
            IsFixedTimeStep = true;
            TargetElapsedTime = TimeSpan.FromMilliseconds(8.33);
            _graphics.ApplyChanges();
            Screen = new();
            Screen.RelativePosition = GraphicsDevice.Viewport.Bounds;
            Window.ClientSizeChanged += Window_ClientSizeChanged;

            gameObjectManager = new(GraphicsDevice);
            Screen.ChangeScreen(new DefaultScreen());
            gameObjectManager.AddObject(Screen);
            Screen.UpdateScreenSize(new(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height));
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        private void Window_ClientSizeChanged(object sender, EventArgs e)
        {
            Screen.UpdateScreenSize(new(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height));
        }

        protected override void Initialize()
        {
            
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            gameObjectManager.Update(gameTime);
#if DEBUG
            updatesPerSecond = 1 / gameTime.ElapsedGameTime.TotalSeconds;
            Window.Title = $"{gameObjectManager.AllObjects.Count} objects | {Math.Round(updatesPerSecond, 3)}updates ps | {Math.Round(drawsPerSecond, 3)}draws ps - Water Engine running {ProjectName ?? "itself"}";
#else
            Window.Title = ProjectName ?? "Water Engine";
#endif
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            gameObjectManager.Draw(gameTime, _spriteBatch, GraphicsDevice);
            _spriteBatch.End();
#if DEBUG
            drawsPerSecond = 1 / gameTime.ElapsedGameTime.TotalSeconds;
#endif
            base.Draw(gameTime);
        }
    }
}
