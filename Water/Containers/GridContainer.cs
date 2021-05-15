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
    public class GridContainer : GameObject
    {
        public IContainer[,] Children { get; set; } = new IContainer[5, 5];

        public override Rectangle CalculateLayout()
        {
            var currentX = 0;
            var currentY = 0;
            for (int x = 0; x < Children.GetLength(0); x++)
            {
                for (int y = 0; y < Children.GetLength(1); y++)
                {
                    Children[x, y].RelativePosition = new(currentX, currentY, Children[x, y].RelativePosition.Width, Children[x, y].RelativePosition.Height);
                    currentX += Children[x, y].RelativePosition.Width;
                    currentY += Children[x, y].RelativePosition.Height;
                }
            }

            return base.CalculateLayout();
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch, GraphicsDevice graphicsDevice)
        {
           
        }

        public override void Initialize()
        {
           
        }

        public override void Update(GameTime gameTime)
        {
            CalculateLayout();
        }
    }
}