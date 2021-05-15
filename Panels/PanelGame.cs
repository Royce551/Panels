using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Water;
using Water.Containers;
using Water.Graphics;

namespace Panels
{
    public class PanelGame : WaterGame
    {
        public override string ProjectName => "Panels.NET!";

        public PanelGame() : base()
        {
            var obj = new Sprite(new(100, 0, 250, 250), "Assets/Gameplay/Player.png");
            obj.Layout = Layout.Fill;
            obj.Margin = 10;
            Screen.Game.AddObject(obj);
            Screen.AddChild(obj);
            var obj2 = new Sprite(new(10, 50, 50, 50), "Assets/Gameplay/Enemy.png");
            obj2.Layout = Layout.Fill;
            obj2.Margin = 10;
            Screen.Game.AddObject(obj2);
            obj.AddChild(obj2);
            var obj3 = new Sprite(new(10, 10, 256, 144), "Assets/[ Pink Dreams ].png");
            obj3.Layout = Layout.Fill;
            obj3.Margin = 10;
            Screen.Game.AddObject(obj3);
            obj.AddChild(obj3);

            var container = new GridContainer();
            Screen.AddChild(container);
            Screen.Game.AddObject(container);
            for (int i = 0; i <= 4; i++)
            {
                for (int y = 0; y <= 4; y++)
                {
                    var obj4 = new Sprite(new(100, 0, 250, 250), "Assets/Gameplay/Player.png");
                    obj4.Layout = Layout.Fill;
                    obj4.Margin = 10;
                    container.AddChild(obj4);
                    container.Children[i, y] = obj4;
                    if (obj.Game is null) throw new System.Exception("HUH");
                    if (obj.Game is null) throw new System.Exception("HOW IS THIS POSSIBLE");
                    obj.Game.AddObject(obj4);
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
