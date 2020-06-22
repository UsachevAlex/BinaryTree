using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    public class Painter : Shape
    {
        private List<Shape> graph;


        public Painter(List<Shape> shapes, int size)
        {
            GParams.Font = new Font("Microsoft Sans Serif", (int)(size / 3.1), FontStyle.Regular, GraphicsUnit.Point, 0);
            graph = shapes;
        }

        public Painter(List<Shape> shapes, int sizeblock, object[,] paintMatrix, string nElem = "0")
        {
            foreach (var item in shapes)
                if (item is Vertex)
                {
                    GParams.Font = new Font("Microsoft Sans Serif", (int)(sizeblock / 4), FontStyle.Regular, GraphicsUnit.Point, 0);
                    Vertex v = (Vertex)item;
                    FindInMatrix(paintMatrix, v.Name, out int i, out int j);
                    v.X = j * sizeblock + (int)(sizeblock / 1.5);
                    v.Y = i * sizeblock + (int)(sizeblock / 1.5);
                    v.Size = (int)(sizeblock / 1.5); 
                }
            graph = shapes;
        }
        public override void Draw(Graphics graphics)
        {
            foreach (var item in graph)
                item.Draw(graphics);
        }
        private void FindInMatrix(object[,] matrix, object x, out int i, out int j)
        {
            i = 0; j = 0;
            for (i = 0; i < matrix.GetLength(0); i++)
                for (j = 0; j < matrix.GetLength(1); j++)
                    if (x.ToString() == matrix[i, j].ToString())
                        return;
        }
        public void Dispose()
        {
            graph.Clear();
        }
    }
}
