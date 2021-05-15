using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Water.Graphics;

namespace Water.Containers
{
    public class GridContainer : Container
    {
        public new IContainer[,] Children { get; set; }

        public void AddChild(IContainer child, int x, int y)
        {
            child.Parent = this;
            Children[x, y] = child;
        }

        public override void CalculateChildrenPositions()
        {
            var currentX = 0;
            var currentY = 0;
            for (int x = 0; x < Children.GetLength(0); x++)
            {
                for (int y = 0; y < Children.GetLength(1); y++)
                {
                    var child = Children[x, y];
                    var newX = child.RelativePosition.Width * x;
                    var newY = child.RelativePosition.Width * y;
                    child.ActualPosition = new(newX, newY, child.RelativePosition.Width, child.RelativePosition.Height);
                    currentX += child.RelativePosition.Width;
                    currentY += child.RelativePosition.Height;
                    child.CalculateChildrenPositions();
                }
            }
        }
    }
}