using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Graph;
using System.Windows.Forms;

namespace BinaryTree
{
    public class BinaryTreeGraphics<T> : BinaryTree<T> where T : IComparable
    {
        public void Draw(Panel panel)
        {
            panel.Refresh();
            List<Shape> ls = new List<Shape>();
            DrawNode(root, ls, null, 0, panel.Width, 20);
            Painter painter = new Painter(ls, 60);
            painter.Draw(panel.CreateGraphics());
        }
        private void DrawNode(BinaryTreeNode<T> root, List<Shape> vr, Vertex owner, int nleft, int eleft, int heigth)
        {
            if (root != null)
            {
                Vertex vertex = new Vertex()
                {
                    X = nleft + (eleft - nleft) / 2,
                    Y = heigth,
                    Name = root.Value.ToString(),
                    Size = 60
                };
                vr.Add(vertex);
                if (owner != null)
                    vr.Add(vertex.SetConnect(owner, TypeConnect.DigraphSon));
                DrawNode(root.Left, vr, vertex, vertex.X - (eleft - nleft) / 2, vertex.X, heigth + 90);
                DrawNode(root.Right, vr, vertex, vertex.X, vertex.X + (eleft - nleft) / 2, heigth + 90);
            }
        }
    }
}
