using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace BinaryTree
{
    public class BinaryTree<T> where T : IComparable
    {
        protected BinaryTreeNode<T> root = null;
        private int deep = 0;
        private int leafCount = 0;
        private string lnr, rnl, nlr;

        public int Deep
        {
            get
            {
                return GetDeepTree(ref root);
            }
        }
        public int LeadCount
        {
            get
            {
                leafCount = 0;
                LeafTreeCount(ref root);
                return leafCount;
            }
        }

        public BinaryTree()
        {

        }

        public void Add(T value)
        {
            AddNode(new BinaryTreeNode<T>(value, null, null), ref root);
        }
        public bool Remove(T value)
        {
            return RemoveNode(value, ref root);
        }
        public string LeftNodeRight()
        {
            lnr = string.Empty;
            LNR(ref root);
            return lnr;
        }
        public string RightNodeLeft()
        {
            rnl = string.Empty;
            RNL(ref root);
            return rnl;
        }
        public string NodeLeftRight()
        {
            nlr = string.Empty;
            NLR(ref root);
            return nlr;
        }
        

        private void AddNode(BinaryTreeNode<T> node, ref BinaryTreeNode<T> root)
        {
            if (root == null)
                root = node;
            //root = new BinaryTreeNode<T>(value, null, null);
            else if (node.Value.CompareTo(root.Value) < 0)
                AddNode(node, ref root.Left);
            else if (node.Value.CompareTo(root.Value) > 0)
                AddNode(node, ref root.Right);
            else
                root.CountValue++;
            root = Balance(ref root);
        }
        
        private bool RemoveNode(T value, ref BinaryTreeNode<T> root)
        {
            if (root != null)
            {
                if (root.Value.CompareTo(value) == 0)
                {
                    BinaryTreeNode<T> l = root.Left, r = root.Right;
                    root = null;
                    if (l != null || r != null)
                    {
                        if (l != null && r == null)
                            AddNode(l, ref this.root);
                        else if (l == null && r != null)
                            AddNode(r, ref this.root);
                        else
                        {
                            AddNode(l, ref this.root);
                            AddNode(r, ref this.root);
                        }                    }
                    return true;
                }
                else if (value.CompareTo(root.Value) < 0)
                    return RemoveNode(value, ref root.Left);
                else
                    return RemoveNode(value, ref root.Right);
            }
            else
                return false;
        }
        private void DeepTree(ref BinaryTreeNode<T> root, int deep)
        {
            if (root != null)
            {
                if (deep > this.deep)
                    this.deep = deep;
                DeepTree(ref root.Left, deep + 1);
                DeepTree(ref root.Right, deep + 1);
            }
        }
        private int GetDeepTree(ref BinaryTreeNode<T> root)
        {
            deep = 0;
            DeepTree(ref root, 1);
            return deep;
        }
        private void LeafTreeCount(ref BinaryTreeNode<T> root)
        {
            if (root != null)
            {
                leafCount++;
                LeafTreeCount(ref root.Left);
                LeafTreeCount(ref root.Right);
            }
        }
        private BinaryTreeNode<T> Balance(ref BinaryTreeNode<T> root)
        {
            int z = BFactor(ref root);
            if (z >= 2)
            {
                if (BFactor(ref root.Right) < 0)
                    root.Right = RotateRight(ref root.Right);
                return RotateLeft(ref root);
            }
            if (z <= -2)
            {
                if (BFactor(ref root.Left) > 0)
                    root.Left = RotateLeft(ref root.Left);
                return RotateRight(ref root);
            }
            else
                return root;
        }
        private BinaryTreeNode<T> RotateLeft(ref BinaryTreeNode<T> root)
        {
            //BinaryTreeNode<T> node = root.Right;
            //root.Right = root.Left;
            //node.Left = root;
            //return node;
            BinaryTreeNode<T> node = root.Right;
            BinaryTreeNode<T> temp = node.Left;
            node.Left = root;
            root.Right = temp;
            return node;
        }
        private BinaryTreeNode<T> RotateRight(ref BinaryTreeNode<T> root)
        {
            //BinaryTreeNode<T> node = root.Left;
            //root.Left = root.Right;
            //node.Right = root;
            //return node;
            BinaryTreeNode<T> node = root.Left;
            BinaryTreeNode<T> temp = node.Right;
            node.Right = root;
            root.Left = temp;
            return node;
        }
        private int BFactor(ref BinaryTreeNode<T> root)
        {
            return GetDeepTree(ref root.Right) - GetDeepTree(ref root.Left);   
        }
        private void LNR(ref BinaryTreeNode<T> root)
        {
            if (root != null)
            {
                LNR(ref root.Left);
                lnr += root.Value + " : " + root.CountValue.ToString() + Environment.NewLine;
                LNR(ref root.Right);
            }
        }
        private void RNL(ref BinaryTreeNode<T> root)
        {
            if (root != null)
            {
                RNL(ref root.Right);
                rnl += root.Value + "; ";
                RNL(ref root.Left);
            }
        }
        private void NLR(ref BinaryTreeNode<T> root)
        {
            if (root != null)
            {
                nlr += root.Value + "; ";
                NLR(ref root.Left);
                NLR(ref root.Right);
            }
        }
       
    }

}
