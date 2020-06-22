using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Graph
{
    public class Diloop : Loop
    {
        private Pointer pointer;
        public Diloop(Vertex v) : base(v)
        {

        }
        public Diloop(Vertex v, int mod) : base(v, mod)
        {

        }
        protected void SetDiloop()
        {
            switch (Mod)
            {
                case 0:
                    pointer = new Pointer(new Point(v.X + v.Size / 2, v.Y + v.Size), (Math.PI * 3 / 2) * 15 / 16, v.Size / 3);
                    break;
                case 1:
                    pointer = new Pointer(new Point(v.X + v.Size, v.Y + v.Size / 2), (Math.PI * 2) * 20 / 21, v.Size / 3);
                    break;
                case 2:
                    pointer = new Pointer(new Point(v.X + v.Size / 2, v.Y), (Math.PI / 2) * 20 / 22, v.Size / 3);
                    break;
                case 3:
                    pointer = new Pointer(new Point(v.X, v.Y + v.Size / 2), Math.PI * 12 / 13, v.Size / 3);
                    break;
                default: break;
            }
        }
        public override void Draw(Graphics graphics)
        {
            base.Draw(graphics);
            SetDiloop();
            pointer.Draw(graphics);
        }
    }
}
