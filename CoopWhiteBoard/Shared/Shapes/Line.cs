using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoopWhiteBoard.Shared.Shapes
{
    public class Line : Shape
    {
        public Line() : base(2) { }

        public override void DrawSelf(IDrawer drawer)
        {
            drawer.DrawLine(nodes[0].X, nodes[0].Y, nodes[1].X, nodes[1].Y);
        }
    }
}
