using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Graph
{
    public class Line : Shape
    {
        protected Point p1, p2;
        public Point PositionStart { get => p1; set => p1 = value; }
        public Point PositionEnd { get => p2; set => p2 = value; }
        public int Width { get => (int)pen.Width; set => pen.Width = value; }
        public int Length { get; set; }
        public Line()
        {
            Width = GParams.WidthLines;
        }
        public Line(Point pStart, Point pEnd) : this()
        {
            p1 = pStart;
            p2 = pEnd;
        }
        public override void Draw(Graphics graphics)
        {
            graphics.DrawLine(pen, p1, p2);
        }
    }
}
