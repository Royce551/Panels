using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Water.Graphics;
using Water.Graphics.Containers;
using Water.Graphics.Controls;
using Water.Graphics.Screens;

namespace Water.Screens
{
    public class DebugOverlay : Screen
    {
        private GameObjectManager game;

        private double updatesPerSecond;
        private double drawsPerSecond;

        private TextBlock updateText;

        public DebugOverlay(GameObjectManager game, GameObjectScreen screen)
        {
            this.game = game;
            var container = new StackContainer
            {
                RelativePosition = new(0, 0, 500, 100),
                Layout = Layout.AnchorTop,
                Orientation = Orientation.Vertical,
            };
            updateText = new(new(0, 0, 10, 10), game.Fonts.Get("Assets/IBMPLEXSANS-MEDIUM.TTF", 15), "updates per second", Color.Gray)
            {
                Layout = Layout.Fill,
                TextWrapping = TextWrapMode.WordWrap,
                HorizontalTextAlignment = HorizontalTextAlignment.Center,
                VerticalTextAlignment = VerticalTextAlignment.Top
            };
            screen.AddChild(container);
            game.AddObject(updateText);
            container.AddChild(updateText);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch, GraphicsDevice graphicsDevice)
        {
            drawsPerSecond = 1 / gameTime.ElapsedGameTime.TotalSeconds;
        }

        public override void Update(GameTime gameTime)
        {
            updatesPerSecond = 1 / gameTime.ElapsedGameTime.TotalSeconds;
            updateText.Text = $"{Math.Round(updatesPerSecond, 2)} updates per second|n{Math.Round(drawsPerSecond, 2)} draws per second|n{game.AllObjects.Count} objects";
        }
    }
}
