using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    public class Edge : Line
    {
        private Vertex v1, v2;
        private Point tXY;

        public Vertex Vertex1 { get => v1; set => v1 = value; }
        public Vertex Vertex2 { get => v2; set => v2 = value; }
        public bool IsDrawLength { get; set; } = false;
        
        public Edge(Vertex v1, Vertex v2)
        {
            if (v1 == null || v2 == null || v1.Equals(v2))
                throw new ArgumentException("Прередана несуществующая или не коректная вершина");
            this.v1 = v1;
            this.v2 = v2;
            pen.Width = 3;
        }
        protected void SetEdge()
        {
            //Line
            Point p1 = v1.Center;
            Point p2 = v2.Center;

            CentralOXY.SetCentralOXY(p1.X, p1.Y);
            double R = v1.Size / 2;
            CentralOXY.GetCenterXY(p2.X, p2.Y, out int x, out int y);
            double c = Math.Sqrt(x * x + y * y);
            CentralOXY.GetDisplayXY(x / c * R, y / c * R, out this.p1);

            CentralOXY.SetCentralOXY(p2.X, p2.Y);
            R = v2.Size / 2;
            CentralOXY.GetCenterXY(p1.X, p1.Y, out x, out y);
            c = Math.Sqrt(x * x + y * y);
            CentralOXY.GetDisplayXY(x / c * R, y / c * R, out this.p2);

            //Text
            if (IsDrawLength)
            {
                CentralOXY.SetCentralOXY(p1.X, p1.Y);
                CentralOXY.GetCenterXY(p2.X, p2.Y, out x, out y);
                c = Math.Sqrt(x * x + y * y);
                R = c / 2;
                CentralOXY.GetDisplayXY(x / c * R, y / c * R, out tXY);
            }
        }
        public override void Draw(Graphics graphics)
        {
            SetEdge();
            base.Draw(graphics);
            if (IsDrawLength)
                graphics.DrawString(Length.ToString(), GParams.Font, GParams.FontBrush, tXY);
        }
    }
}
