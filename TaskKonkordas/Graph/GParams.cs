using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Graph
{
    public static class GParams
    {
        public static int WidthLines { get; set; } = 3;
        public static int ModeLoops { get; set; } = 0;
        public static List<Shape> Graph { get; }
        public static Font Font { get; set; } = new Font("Microsoft Sans Serif", 10, FontStyle.Regular, GraphicsUnit.Point, 0);
        public static SolidBrush FontBrush { get; } = new SolidBrush(Color.Black);

    }
}
