using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    public class BinaryTreeNode<T>
    {
        public T Value { get; set; }
        public BinaryTreeNode<T> Right;
        public BinaryTreeNode<T> Left;
        public int CountValue { get; set; } = 1;

        public BinaryTreeNode()
        {
        }

        public BinaryTreeNode(T value, BinaryTreeNode<T> right, BinaryTreeNode<T> left)
        {
            Value = value;
            Right = right;
            Left = left;
        }
    }
}
