using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Water;
using Water.Graphics;

namespace Panels
{
    public class PanelGame : WaterGame
    {
        public override string ProjectName => "Panels.NET!";

        public PanelGame() : base()
        {
            var obj = new Sprite(new(100, 0, 500, 500), "Assets/Gameplay/Player.png");
            Screen.Game.AddObject(obj);
            Screen.AddChild(obj);
            var obj2 = new Sprite(new(10, 10, 200, 200), "Assets/Gameplay/Enemy.png");
            Screen.Game.AddObject(obj2);
            obj.AddChild(obj2);
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
