using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Water.Graphics;
using Water.Graphics.Controls;
using Water.Graphics.Screens;

namespace UntitledDanmakuGame.Screens.Play
{
    public class PlayScreen : Screen
    {
        private GameObjectManager game;
        private GameWindow window;

        public PlayScreen(GameObjectManager game, GameObjectScreen screen, GameWindow window)
        {
            var background = new Sprite(new(0, 0, 0, 0), "Assets/UI/[ Pink Dreams ].png")
            {
                Layout = Layout.Fill
            };
            screen.AddChild(game.AddObject(background));
            background.AddChild(game.AddObject(new Sprite(new(0, 0, 0, 0), "Assets/UI/playfieldDefaultBackground.png")
            {
                Layout = Layout.AspectRatioMaintainingFill
            }));
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch, GraphicsDevice graphicsDevice)
        {
            
        }

        public override void Update(GameTime gameTime)
        {
            
        }
    }
}
