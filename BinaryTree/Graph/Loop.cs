using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    public class Loop : Line
    {
        protected Vertex v;

        private int mod;       
        private Point[] points;
        private Point tXY;
        public Vertex V { get => v; }
        public int Mod { get => mod; set => mod = Math.Abs(value) % 4; }
        public Loop(Vertex v)
        {
            this.v = v ?? throw new ArgumentException("Прередана несуществующая или не коректная вершина");
            mod = Math.Abs(GParams.ModeLoops) % 4;
        }
        public Loop(Vertex v, int mod)
        {
            this.v = v ?? throw new ArgumentException("Прередана несуществующая или не коректная вершина");
            this.mod = Math.Abs(mod) % 4;
        }
        protected void SetLoop()
        {
            List<Point> points = null;
            double d = 0.8;
            switch (mod)
            {
                case 0:
                    CentralOXY.SetCentralOXY(v.X, v.Y + v.Size);
                    points = (GetPart4(v.Size / 2, d)).Concat(GetPart3(v.Size / 2, d)).Concat(GetPart2(v.Size / 2, d)).ToList();
                    break;
                case 1:
                    CentralOXY.SetCentralOXY(v.X + v.Size, v.Y + v.Size);
                    points = (GetPart1(v.Size / 2, d)).Concat(GetPart4(v.Size / 2, d)).Concat(GetPart3(v.Size / 2, d)).ToList();
                    break;
                case 2:          
                    CentralOXY.SetCentralOXY(v.X + v.Size, v.Y);
                    points = (GetPart2(v.Size / 2, d)).Concat(GetPart1(v.Size / 2, d)).Concat(GetPart4(v.Size / 2, d)).ToList();
                   break;
                case 3:
                    CentralOXY.SetCentralOXY(v.X, v.Y);
                    points = (GetPart3(v.Size / 2, d)).Concat(GetPart2(v.Size / 2, d)).Concat(GetPart1(v.Size / 2, d)).ToList();
                    break;
                default: break;
            }
            if (points != null)
            {
                while ((points.Count - 1) % 3 != 0)
                    points.RemoveAt(points.Count / 2);
            }
            tXY = points[points.Count / 2];
            tXY.X -= (int)GParams.Font.Size;
            this.points = points.ToArray();
        }
        public override void Draw(Graphics graphics)
        {
            SetLoop();
            graphics.DrawBeziers(pen, points);
            graphics.DrawString(Length.ToString(), GParams.Font, GParams.FontBrush, tXY);
        }
        private List<Point> GetPart1(double R, double d)
        {
            List<Point> points = new List<Point>();
            double y = R;
            Point p;
            double c;
            for (double x = 0; x <= R; x += d)
            {
                c = Math.Sqrt(x * x + y * y);
                CentralOXY.GetDisplayXY(x / c * R, y / c * R, out p);
                points.Add(p);
                y -= d;
            }
            
            return points;
        }
        private List<Point> GetPart2(double R, double d)
        {
            List<Point> points = new List<Point>();
            double y = 0;
            Point p;
            double c;
            for (double x = -R; x <= 0; x += d)
            {
                c = Math.Sqrt(x * x + y * y);
                CentralOXY.GetDisplayXY(x / c * R, y / c * R, out p);
                points.Add(p);
                y += d;
            }
            return points;
        }
        private Point[] GetPart3(double R, double d)
        {
            List<Point> points = new List<Point>();
            double y = -R;
            Point p;
            double c;
            for (double x = 0; x >= -R; x -= d)
            {
                c = Math.Sqrt(x * x + y * y);
                CentralOXY.GetDisplayXY(x / c * R, y / c * R, out p);
                points.Add(p);
                y += d;
            }
            while ((points.Count - 1) % 3 != 0)
                points.RemoveAt(points.Count / 2);
            return points.ToArray();
        }
        private Point[] GetPart4(double R, double d)
        {
            List<Point> points = new List<Point>();
            double y = 0;
            Point p;
            double c;
            for (double x = R; x >= 0; x -= d)
            {
                c = Math.Sqrt(x * x + y * y);
                CentralOXY.GetDisplayXY(x / c * R, y / c * R, out p);
                points.Add(p);
                y -= d;
            }
            while ((points.Count - 1) % 3 != 0)
                points.RemoveAt(points.Count / 2);
            return points.ToArray();
        }
    }
}
