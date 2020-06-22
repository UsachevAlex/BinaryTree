using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    public class GConnect
    {
        public Line Edge { get; set; }
        public Vertex Vertex { get; set; }
        public Vertex Own { get; set; } 
        public TypeConnect Type { get; set; }
        public GConnect(Vertex v, Vertex own, Line g, TypeConnect type, int length = 1)
        {
            if (g == null)
            {
                switch (type)
                {
                    case TypeConnect.None:
                        break;
                    case TypeConnect.DigraphOwn:
                        g = new Digraph(own, v) { Length = length };
                        break;
                    case TypeConnect.DigraphSon:
                        g = new Digraph(v, own) { Length = length };
                        break;
                    case TypeConnect.Edge:
                        g = new Edge(own, v) { Length = length };
                        break;
                    case TypeConnect.Loop:
                        g = new Loop(v) { Length = length };
                        break;
                    case TypeConnect.Diloop:
                        g = new Diloop(v) { Length = length };
                        break;
                    default:
                        break;
                }
            }
            Edge = g;
            Vertex = v;
            Own = own;
            Type = type;
        }
    }
}
