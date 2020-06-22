using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    public class Digraph : Edge
    {
        Pointer pointer;
        public Digraph(Vertex v1, Vertex v2) : base(v1, v2)
        {

        }
        protected void SetDigraph()
        {
            SetEdge();
            CentralOXY.SetCentralOXY(PositionEnd);
            CentralOXY.GetCenterXY(PositionStart, out int x, out int y);
            double c = Math.Sqrt(x * x + y * y);
            double u = Math.Acos(x / c);
            if (p1.Y > p2.Y)
                u = -u;
            pointer = new Pointer(PositionEnd, u, 25);
        }
        public override void Draw( Graphics graphics)
        {
            SetDigraph();
            base.Draw(graphics);
            pointer.Draw(graphics);
        }
    }
}
