using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BinaryTree;

namespace TaskKonkordas
{
    public partial class Form1 : Form
    {
        //BinaryTree<string> tree = new BinaryTree<string>();
        BinaryTreeGraphics<string> tree = new BinaryTreeGraphics<string>();
        char[] znaks = { ' ', '.', '?', '!', ',', '\n', '\r' };
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] str = textBox1.Text.Split(znaks);
            foreach (var s in str)
                if (s != "")
                    tree.Add(s.ToLower());
            tree.Draw(panel1);
            textBox2.Text = tree.LeftNodeRight();
        }

        private string DeleteZnak(string s)
        {
            //char[] znaks = { '.', '?', '!', ',', '\n', '\r' };
            int i = 0;
            while (i < s.Length)
            {
                for (int j = 0; j < znaks.Length; j++)
                    if (s[i] == znaks[j])
                        s.Remove(i, 1);
                i++;
            }
            return s;
        }
    }
}
