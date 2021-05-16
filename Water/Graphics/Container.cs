using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Water.Graphics
{
    public class Container : IContainer
    {
        public Rectangle ActualPosition { get; set; }

        public Rectangle RelativePosition { get; set; }
        public IContainer Parent { get; set; }
        public List<IContainer> Children { get; private set; } = new();

        public Layout Layout { get; set; } = Layout.Manual;
        public int Margin { get; set; } = 0;

        public virtual void AddChild(IContainer child)
        {
            child.Parent = this;
            Children.Add(child);
        }

        public virtual void CalculateChildrenPositions()
        {
            foreach (var child in Children)
            {
                if (child is Sprite x)
                    if (x.Tag == "Object 1")
                        Console.WriteLine("it's true!");
                var parentPosition = Parent?.ActualPosition ?? RelativePosition; // can be null for the root object
                child.ActualPosition = child.Layout switch
                {
                    Layout.AnchorLeft => new
                    (
                        parentPosition.X + child.Margin,
                        parentPosition.Y + ((parentPosition.Height - child.RelativePosition.Height) / 2),
                        RelativePosition.Width,
                        RelativePosition.Height
                    ),
                    Layout.AnchorTopLeft => new
                    (
                        parentPosition.X + child.Margin,
                        parentPosition.Y + child.Margin,
                        RelativePosition.Width,
                        RelativePosition.Height
                    ),
                    Layout.AnchorTop => new
                    (
                        parentPosition.X + ((parentPosition.Width - child.RelativePosition.Width) / 2),
                        parentPosition.Y + child.Margin,
                        RelativePosition.Width,
                        RelativePosition.Height
                    ),
                    Layout.AnchorTopRight => new
                    (
                        parentPosition.Right - RelativePosition.Width - child.Margin,
                        parentPosition.Y + child.Margin,
                        RelativePosition.Width,
                        RelativePosition.Height
                    ),
                    Layout.AnchorRight => new
                    (
                        parentPosition.Right - RelativePosition.Width - child.Margin,
                        parentPosition.Y + ((parentPosition.Height - RelativePosition.Height) / 2),
                        RelativePosition.Width,
                        RelativePosition.Height
                    ),
                    Layout.AnchorBottomRight => new
                    (
                        parentPosition.Right - RelativePosition.Width - child.Margin,
                        parentPosition.Bottom - RelativePosition.Height - child.Margin,
                        RelativePosition.Width,
                        RelativePosition.Height
                    ),
                    Layout.AnchorBottom => new
                    (
                        parentPosition.X + ((parentPosition.Width - RelativePosition.Width) / 2),
                        parentPosition.Bottom - RelativePosition.Height - child.Margin,
                        RelativePosition.Width,
                        RelativePosition.Height
                    ),
                    Layout.AnchorBottomLeft => new
                    (
                        parentPosition.X + child.Margin,
                        parentPosition.Bottom - RelativePosition.Height - child.Margin,
                        RelativePosition.Width,
                        RelativePosition.Height
                    ),
                    Layout.Center => new
                    (
                        parentPosition.X + ((parentPosition.Width - RelativePosition.Width) / 2),
                        parentPosition.Y + ((parentPosition.Height - RelativePosition.Height) / 2),
                        RelativePosition.Width,
                        RelativePosition.Height
                    ),
                    Layout.Fill => new
                    (
                        parentPosition.X + child.Margin,
                        parentPosition.Y + child.Margin,
                        parentPosition.Width - (child.Margin * 2),
                        parentPosition.Height - (child.Margin * 2)
                    ),
                    Layout.DockLeft => new
                    (
                        parentPosition.X + child.Margin,
                        parentPosition.Y + child.Margin,
                        RelativePosition.Width,
                        parentPosition.Height - (child.Margin * 2)
                    ),
                    Layout.DockTop => new
                    (
                        parentPosition.X + child.Margin,
                        parentPosition.Y + child.Margin,
                        parentPosition.Width - (child.Margin * 2),
                        RelativePosition.Height
                    ),
                    Layout.DockRight => new
                    (
                        parentPosition.Right - RelativePosition.Width - child.Margin,
                        parentPosition.Y + child.Margin,
                        RelativePosition.Width,
                        parentPosition.Height - (child.Margin * 2)
                    ),
                    Layout.DockBottom => new
                    (
                        parentPosition.X + child.Margin,
                        parentPosition.Bottom - RelativePosition.Height - child.Margin,
                        parentPosition.Width - (child.Margin * 2),
                        RelativePosition.Height
                    ),
                    Layout.Manual or _ => new
                    (
                        parentPosition.X + RelativePosition.X,
                        parentPosition.Y + RelativePosition.Y,
                        RelativePosition.Width,
                        RelativePosition.Height
                    )

                };
                child.CalculateChildrenPositions();
            }
        } 
    }
}
