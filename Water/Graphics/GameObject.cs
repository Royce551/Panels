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
                    return CalculateLayout(); // TODO: don't calculate EVERY frame
                else return RelativePosition;
            }
        }
        public Rectangle RelativePosition { get; set; }
        public IContainer Parent { get; set; }
        public Layout Layout { get; set; } = Layout.Manual;
        public int Margin { get; set; } = 0;

        public abstract void Initialize();

        public abstract void Update(GameTime gameTime);
        public abstract void Draw(GameTime gameTime, SpriteBatch spriteBatch, GraphicsDevice graphicsDevice);

        public void AddChild(IContainer child) => child.Parent = this;

        public Rectangle CalculateLayout() => Layout switch
        {
            Layout.AnchorLeft => new
            (
                Parent.ActualPosition.X + Margin,
                Parent.ActualPosition.Y + ((Parent.ActualPosition.Height - RelativePosition.Height) / 2),
                RelativePosition.Width,
                RelativePosition.Height
            ),
            Layout.AnchorTopLeft => new
            (
                Parent.ActualPosition.X + Margin,
                Parent.ActualPosition.Y + Margin,
                RelativePosition.Width,
                RelativePosition.Height
            ),
            Layout.AnchorTop => new
            (
                Parent.ActualPosition.X + ((Parent.ActualPosition.Width - RelativePosition.Width) / 2),
                Parent.ActualPosition.Y + Margin,
                RelativePosition.Width,
                RelativePosition.Height
            ),
            Layout.AnchorTopRight => new
            (
                Parent.ActualPosition.Right - RelativePosition.Width - Margin,
                Parent.ActualPosition.Y + Margin,
                RelativePosition.Width,
                RelativePosition.Height
            ),
            Layout.AnchorRight => new
            (
                Parent.ActualPosition.Right - RelativePosition.Width - Margin,
                Parent.ActualPosition.Y + ((Parent.ActualPosition.Height - RelativePosition.Height) / 2),
                RelativePosition.Width,
                RelativePosition.Height
            ),
            Layout.AnchorBottomRight => new
            (
                Parent.ActualPosition.Right - RelativePosition.Width - Margin,
                Parent.ActualPosition.Bottom - RelativePosition.Height - Margin,
                RelativePosition.Width,
                RelativePosition.Height
            ),
            Layout.AnchorBottom => new
            (
                Parent.ActualPosition.X + ((Parent.ActualPosition.Width - RelativePosition.Width) / 2),
                Parent.ActualPosition.Bottom - RelativePosition.Height - Margin,
                RelativePosition.Width,
                RelativePosition.Height
            ),
            Layout.AnchorBottomLeft => new
            (
                Parent.ActualPosition.X + Margin,
                Parent.ActualPosition.Bottom - RelativePosition.Height - Margin,
                RelativePosition.Width,
                RelativePosition.Height
            ),
            Layout.Center => new
            (
                Parent.ActualPosition.X + ((Parent.ActualPosition.Width - RelativePosition.Width) / 2),
                Parent.ActualPosition.Y + ((Parent.ActualPosition.Height - RelativePosition.Height) / 2),
                RelativePosition.Width,
                RelativePosition.Height
            ),
            Layout.Fill => new
            (
                Parent.ActualPosition.X + Margin,
                Parent.ActualPosition.Y + Margin,
                Parent.ActualPosition.Width - (Margin * 2),
                Parent.ActualPosition.Height - (Margin * 2)
            ),
            Layout.DockLeft => new
            (
                Parent.ActualPosition.X + Margin,
                Parent.ActualPosition.Y + Margin,
                RelativePosition.Width,
                Parent.ActualPosition.Height - (Margin * 2)
            ),
            Layout.DockTop => new
            (
                Parent.ActualPosition.X + Margin,
                Parent.ActualPosition.Y + Margin,
                Parent.ActualPosition.Width - (Margin * 2),
                RelativePosition.Height
            ),
            Layout.DockRight => new
            (
                Parent.ActualPosition.Right - RelativePosition.Width - Margin,
                Parent.ActualPosition.Y + Margin,
                RelativePosition.Width,
                Parent.ActualPosition.Height - (Margin * 2)
            ),
            Layout.DockBottom => new
            (
                Parent.ActualPosition.X + Margin,
                Parent.ActualPosition.Bottom - RelativePosition.Height - Margin,
                Parent.ActualPosition.Width - (Margin * 2),
                RelativePosition.Height
            ),
            Layout.Manual or _ => new
            (
                Parent.ActualPosition.X + RelativePosition.X,
                Parent.ActualPosition.Y + RelativePosition.Y,
                RelativePosition.Width,
                RelativePosition.Height
            )
            
        };
        
    }
}
