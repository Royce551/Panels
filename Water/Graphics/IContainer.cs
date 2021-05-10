using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Water.Graphics
{
    public interface IContainer
    {
        public Rectangle ActualPosition { get; }
        public Rectangle RelativePosition { get; set; }

        public IContainer Parent { get; set; }

        public void AddChild(IContainer child);
    }
}
