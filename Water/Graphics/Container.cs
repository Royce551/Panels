using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Water.Graphics
{
    public class Container : IContainer
    {
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

        public void AddChild(IContainer child) => child.Parent = this;

        public virtual Rectangle CalculateLayout() => Layout switch
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
