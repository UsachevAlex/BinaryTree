using System.Drawing;

namespace Graph
{
    public static class CentralOXY
    {
        public static int OX { get; set; }
        public static int OY { get;  set; }

        private static int tempOX, tempOY;

        public static void SetCentralOXY(int x, int y)
        {
            OX = x;
            OY = y;
        }
        public static void SetCentralOXY(Point p)
        {
            OX = p.X;
            OY = p.Y;
        }
        public static void GetDisplayXY(double x, double y, out int xe, out int ye)
        {
            x += OX;
            y += OY; y = OY * 2 - y;
            xe = (int)(x);
            ye = (int)(y);
        }

        public static void GetDisplayXY(double x, double y, out Point point)
        {
            x += OX;
            y += OY; y = OY * 2 - y;
            point = new Point((int)x, (int)y);
        }
        public static void GetDisplayXY(Point point, out Point _point)
        {
            point.X += OX;
            point.Y += OY; point.Y = OY * 2 - point.Y;
            _point = new Point(point.X, point.Y);
        }

        public static void GetCenterXY(int xe, int ye, out int x, out int y)
        {
            xe -= OX;
            ye = OY * 2 - ye;
            ye -= OY;
            x = xe;
            y = ye;
        }
        public static void GetCenterXY(int xe, int ye, out Point point)
        {
            xe -= OX;
            ye = OY * 2 - ye;
            ye -= OY;
            point = new Point(xe, ye);
        }
        public static void GetCenterXY(Point point, out int x, out int y)
        {
            point.X -= OX;
            point.Y = OY * 2 - point.Y;
            point.Y -= OY;
            x = point.X;
            y = point.Y;
        }
        public static void GetCenterXY(Point point, out Point _point)
        {
            point.X -= OX;
            point.Y = OY * 2 - point.Y;
            point.Y -= OY;
            _point = new Point(point.X, point.Y);
        }

        public static void SaveOXY()
        {
            tempOX = OX;
            tempOY = OY;
        }
        public static void LoadOXY()
        {
            OX = tempOX;
            OY = tempOY;
        }
    }
}
