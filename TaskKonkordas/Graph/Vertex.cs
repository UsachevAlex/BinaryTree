using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    public enum TypeConnect { None, DigraphOwn, DigraphSon, Edge, Loop, Diloop }
    public class Vertex : Shape
    {
        protected int x, y, size;
        private object name;
        private List<GConnect> connects = new List<GConnect>();

        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }
        public object Name { get => name; set => name = value; }
        public Point Center { get => new Point(x + size / 2, y + size / 2); }
        public int Size
        {
            get
            {
                return size;
            }
            set
            {
                size = value;
            } 
        }

        public Vertex()
        {
            pen.Width = 3;
        } 
        
        public override void Draw(Graphics graphics)
        {
            graphics.FillEllipse(brush, x, y, size, size);
            graphics.DrawEllipse(pen, x, y, size, size);
            graphics.DrawString(name.ToString(), GParams.Font, GParams.FontBrush, (float)(x + size * 0.26), (float)(y + size * 0.18));
        }
        public Line SetConnect(Vertex vertex, TypeConnect type, int length = 1, Line line = null)
        {
            if (IsConnect(vertex))
            {
                var list = GetAllConnects(vertex);
                foreach (var item in list)
                    if (item.Type == type)
                        return null;
            }
            var c = new GConnect(vertex, this, null, type, length);
            connects.Add(c);
            return c.Edge;
        }
        public void DisConnect(Vertex vertex)
        {
            var rmlist = new List<GConnect>();
            foreach (var item in connects)
                if (item.Vertex.Equals(vertex))
                    rmlist.Add(item);
            foreach (var item in rmlist)
                connects.Remove(item);
        }
        public bool IsConnect(Vertex vertex)
        {
            foreach (var item in connects)
                if (item.Vertex.Equals(vertex))
                    return true;
            return false;
        }
        public List<GConnect> GetAllConnects(Vertex vertex)
        {
            var list = new List<GConnect>();
            foreach (var item in connects)
                if (item.Vertex.Equals(vertex))
                    list.Add(item);
            return list;
        }
        public override string ToString()
        {
            return Name.ToString();
        }
    }
}
