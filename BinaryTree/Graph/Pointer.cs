using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    public class Pointer : Shape
    {
        private double ugl = 0;
        private int size;
        private Point p;

        public double Ugl { get => ugl; set => ugl = value; }
        public Point Position { get => p; set => p = value; }
        public int Size { get => size; set => size = value; }

        public Pointer(Point p, double ugl, int size)
        {
            this.p = p;
            this.size = size;
            this.ugl = ugl;
            pen.Width = 3;
        }

        public override void Draw(Graphics graphics)
        {
            CentralOXY.SetCentralOXY(p.X, p.Y);
            CentralOXY.GetDisplayXY(Math.Cos(ugl - Math.PI / 10) * size, Math.Sin(ugl - Math.PI / 10) * size, out Point p1);
            CentralOXY.GetDisplayXY(Math.Cos(ugl + Math.PI / 10) * size, Math.Sin(ugl + Math.PI / 10) * size, out Point p2);
            graphics.DrawLine(pen, p, p1);
            graphics.DrawLine(pen, p, p2);
        }
    }
}
