using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Water;
using Water.Graphics;
using Water.Graphics.Containers;

namespace Panels
{
    public class PanelGame : WaterGame
    {
        public override string ProjectName => "Panels.NET!";

        public PanelGame() : base()
        {
            var obj = new Sprite(new(10, 10, 250, 50), "Assets/Gameplay/Player.png");
            obj.Tag = "Object 1";
            obj.Layout = Layout.Fill;
            obj.Margin = 10;
            Screen.Game.AddObject(obj);
            Screen.AddChild(obj);
            var obj2 = new Sprite(new(10, 50, 50, 50), "Assets/Gameplay/Enemy.png");
            obj2.Tag = "Object 2";
            obj2.Layout = Layout.Fill;
            obj2.Margin = 75;
            obj.Game.AddObject(obj2);
            obj.AddChild(obj2);
            var obj3 = new Sprite(new(10, 10, 256, 500), "Assets/[ Pink Dreams ].png");
            obj3.Tag = "Object 3";
            obj3.Layout = Layout.DockBottom;
            obj3.Margin = 10;
            Screen.Game.AddObject(obj3);
            obj2.AddChild(obj3);


            var xcontainer = new StackContainer();
            xcontainer.RelativePosition = new(0, 0, 100, 100);
            xcontainer.Layout = Layout.Fill;
            xcontainer.Margin = 10;
            xcontainer.Orientation = Orientation.Vertical;
            obj3.AddChild(xcontainer);
            for (int i = 0; i <= 4; i++)
            {
                var objx = new Sprite(new(10, 10, 256, 144), "Assets/[ Pink Dreams ].png");
                objx.Layout = Layout.Fill;
                Screen.Game.AddObject(objx);
                xcontainer.AddChild(objx);

                var container = new GridContainer();
                container.RelativePosition = new(0, 0, 100, 100);
                container.Layout = Layout.Fill;
                xcontainer.AddChild(container);
                container.Children = new IContainer[5, 5];
                for (int s = 0; s <= 4; s++)
                {
                    for (int y = 0; y <= 4; y++)
                    {
                        var obj4 = new Sprite(new(100, 0, 250, 250), @"C:\Users\poohw\OneDrive\Assets\blobsadcat.png");
                        obj4.Tag = $"Object 4 {s},{y}";
                        obj4.Layout = Layout.Fill;
                        obj4.Margin = 75;
                        Screen.Game.AddObject(obj4);
                        container.AddChild(obj4);
                        container.Children[s, y] = obj4;

                    }
                }
            }
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
