using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Water.Graphics
{
    public abstract class GameObject : IDrawableThing, IContainer
    {
        public GameObjectManager Game { get; set; }
        public Rectangle ActualPosition
        { 
            get
            {
                if (Parent is not null)
                    return new(Parent.ActualPosition.X + RelativePosition.X, Parent.ActualPosition.Y + RelativePosition.Y, RelativePosition.Width, RelativePosition.Height);
                else return RelativePosition;
            }
        }
        public Rectangle RelativePosition { get; set; }
        public IContainer Parent { get; set; }

        public abstract void Initialize();

        public abstract void Update(GameTime gameTime);
        public abstract void Draw(GameTime gameTime, SpriteBatch spriteBatch, GraphicsDevice graphicsDevice);

        public void AddChild(IContainer child) => child.Parent = this;
    }
}
