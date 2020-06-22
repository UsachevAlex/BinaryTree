using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Graph
{
    public abstract class Shape
    {
        protected Pen pen = new Pen(Color.Black);
        protected SolidBrush brush = new SolidBrush(Color.FromArgb(0, 0, 0, 0));
        
        public Color ColorPen { get => pen.Color; set => pen.Color = value; }
        public Color ColorBrush { get => brush.Color; set => brush.Color = value; }

        public Shape()
        {
            
        }
        public abstract void Draw(Graphics graphics);
        protected virtual void Init()
        {

        }
    }
}
