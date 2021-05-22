using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SpriteFontPlus;
using System;
using System.IO;
using Water;
using Water.Graphics;
using Water.Graphics.Containers;
using Water.Graphics.Controls;

namespace Panels
{
    public class PanelGame : WaterGame
    {
        public override string ProjectName => "Panels.NET!";

        public PanelGame() : base()
        {
            //var xcontainer = new StackContainer();
            //xcontainer.RelativePosition = new(0, 0, 100, 100);
            //xcontainer.Layout = Layout.Fill;
            //xcontainer.Margin = 10;
            //xcontainer.Orientation = Orientation.Vertical;
            //Screen.AddChild(xcontainer);
            //for (int i = 0; i <= 4; i++)
            //{
            //    var objx = new Sprite(new(10, 10, 256, 144), "Assets/[ Pink Dreams ].png");
            //    objx.Layout = Layout.Fill;
            //    Screen.Game.AddObject(objx);
            //    xcontainer.AddChild(objx);

            //    var container = new GridContainer();
            //    container.RelativePosition = new(0, 0, 100, 100);
            //    container.Layout = Layout.Fill;
            //    xcontainer.AddChild(container);
            //    container.Children = new IContainer[5, 5];
            //    for (int s = 0; s <= 4; s++)
            //    {
            //        for (int y = 0; y <= 4; y++)
            //        {
            //            var obj4 = new Sprite(new(100, 0, 250, 250), @"C:\Users\poohw\OneDrive\Assets\blobsadcat.png");
            //            obj4.Layout = Layout.Fill;
            //            obj4.Margin = 75;
            //            Screen.Game.AddObject(obj4);
            //            container.AddChild(obj4);
            //            container.Children[s, y] = obj4;

            //        }
            //    }
            //}

            //var obj = new Sprite(new(10, 10, 250, 50), "Assets/Gameplay/Player.png");
            //obj.Layout = Layout.Fill;
            //obj.Margin = 75;
            //Screen.Game.AddObject(obj);
            //Screen.AddChild(obj);
            //var obj2 = new Sprite(new(10, 50, 50, 50), "Assets/Gameplay/Enemy.png");
            //obj2.Layout = Layout.Fill;
            //obj2.Margin = 75;
            //obj.Game.AddObject(obj2);
            //obj.AddChild(obj2);
            //var obj3 = new Sprite(new(10, 10, 256, 250), "Assets/[ Pink Dreams ].png");
            //obj3.Layout = Layout.DockRight;
            //obj3.Margin = 10;
            //Screen.Game.AddObject(obj3);
            //obj2.AddChild(obj3);

            var container = new StackContainer();
            container.RelativePosition = new(0, 0, 100, 100);
            container.Layout = Layout.Fill;
            container.Orientation = Orientation.Vertical;
            Screen.AddChild(container);

            var font = DynamicSpriteFont.FromTtf(File.ReadAllBytes("Assets/GENJYUUGOTHICX-MEDIUM.TTF"), 25);
            var text1 = new TextBlock(new(10, 10, 600, 600), font, $"The quick brown fox jumps over the lazy dog and word wraps", Color.White);
            text1.Layout = Layout.Fill;
            text1.TextWrapping = TextWrapMode.WordWrap;
            text1.TextAlignment = TextAlignment.Left;
            Screen.Game.AddObject(text1);
            container.AddChild(text1);

            var text2 = new TextBlock(new(10, 10, 600, 600), font, $"The quick brown fox jumps over the lazy dog and letter wraps", Color.White);
            text2.Layout = Layout.Fill;
            text2.TextWrapping = TextWrapMode.LetterWrap;
            text2.TextAlignment = TextAlignment.Left;
            Screen.Game.AddObject(text2);
            container.AddChild(text2);

            var text3 = new TextBlock(new(10, 10, 600, 600), font, $"The quick brown fox jumps over the lazy dog and is center aligned.", Color.White);
            text3.Layout = Layout.Fill;
            text3.TextWrapping = TextWrapMode.LetterWrap;
            text3.TextAlignment = TextAlignment.Center;
            Screen.Game.AddObject(text3);
            container.AddChild(text3);

            var text4 = new TextBlock(new(10, 10, 600, 600), font, $"The quick brown fox jumps over the lazy dog and is right aligned.", Color.White);
            text4.Layout = Layout.Fill;
            text4.TextWrapping = TextWrapMode.LetterWrap;
            text4.TextAlignment = TextAlignment.Right;
            Screen.Game.AddObject(text4);
            container.AddChild(text4);
        }

        protected override void Initialize()
        {
            
            // TODO: Add your initialization logic here
            base.Initialize();
        }

        protected override void LoadContent()
        {
            
            base.LoadContent();
        }

        protected override void Update(GameTime gameTime)
        {

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            
            base.Draw(gameTime);
        }
    }
}
