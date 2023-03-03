using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoopWhiteBoard.Shared.Shapes
{
    public class Circle : Shape
    {
        public Circle() : base(2) { }

        public override void DrawSelf(IDrawer drawer)
        {
            int radius = nodes[0].DistanceTo(nodes[1]);

            drawer.DrawCircle(nodes[0].X, nodes[0].Y, radius);
            drawer.DrawLine(nodes[0].X, nodes[0].Y, nodes[1].X, nodes[1].Y, true);
        }
    }
}
