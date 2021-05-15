using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Water.Graphics.Screens
{
    public class GameObjectScreen : GameObject
    {
        public Stack<Screen> Screens { get; } = new();
        public bool HasScreens { get => Screens.Count > 0; }

        public void AddScreen(Screen screen)
        {
            Screens.Push(screen);
        }

        public void RemoveScreen()
        {
            Screens.Pop();
        }
        public void RemoveAllScreens()
        {
            while (HasScreens)
                RemoveScreen();

        }

        //public override void AddChild(IContainer child)  // TODO: figure out how to get this working
        //{
        //    base.AddChild(child);
        //    CalculateChildrenPositions();
        //}

        public override void Initialize()
        {

        }

        public void ChangeScreen(Screen screen)
        {
            RemoveAllScreens();
            AddScreen(screen);
        }

        public override void Update(GameTime gameTime)
        {
            if (!HasScreens) return;
            Screens.Peek().Update(gameTime);
            CalculateChildrenPositions();
        }
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch, GraphicsDevice graphicsDevice)
        {
            if (!HasScreens) return;
            Screens.Peek().Draw(gameTime, spriteBatch, graphicsDevice);
        }

        public void UpdateScreenSize(Rectangle newSize)
        {
            ActualPosition = newSize;
            RelativePosition = newSize;
            foreach (var child in Children)
                child.CalculateChildrenPositions();
        }
    }
}
