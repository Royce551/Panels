using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using UntitledDanmakuGame.Screens.Play;
using Water;

namespace UntitledDanmakuGame
{
    public class UntitledDanmakuGame : WaterGame
    {
        public override string ProjectName => "Untitled Danmaku Game";

        public UntitledDanmakuGame() : base()
        {
            
        }

        protected override void Initialize()
        {
            Screen.ChangeScreen(new PlayScreen(Screen.Game, Screen, Window));
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
