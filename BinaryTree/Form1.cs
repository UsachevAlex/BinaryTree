using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BinaryTree
{
    public partial class Form1 : Form
    {
        BinaryTreeGraphics<int> binaryTree = new BinaryTreeGraphics<int>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //binaryTree.Add(textBox1.Text);
            //label3.Text = "Deep = " + binaryTree.Deep;
            //label4.Text = "Leaf Count = " + binaryTree.LeadCount;
            //binaryTree.Draw(panel1);
            if (int.TryParse(textBox1.Text, out int value))
            {
                if (value == 25)
                    binaryTree.Add(value);
                else
                    binaryTree.Add(value);
                label3.Text = "Deep = " + binaryTree.Deep;
                label4.Text = "Leaf Count = " + binaryTree.LeadCount;
                binaryTree.Draw(panel1);
            }
            else
                MessageBox.Show("Input ERROR!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //if (binaryTree.Remove(textBox2.Text))
            //{
            //    label3.Text = "Deep = " + binaryTree.Deep;
            //    label4.Text = "Leaf Count = " + binaryTree.LeadCount;
            //    binaryTree.Draw(panel1);
            //}
            //else
            //    MessageBox.Show("Value not found");
            if (int.TryParse(textBox2.Text, out int value))
            {
                if (binaryTree.Remove(value))
                {
                    label3.Text = "Deep = " + binaryTree.Deep;
                    label4.Text = "Leaf Count = " + binaryTree.LeadCount;
                    binaryTree.Draw(panel1);
                }
                else
                    MessageBox.Show("Value not found");
            }
            else
                MessageBox.Show("Input ERROR!");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox3.Text = "LNR: " + binaryTree.LeftNodeRight();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox3.Text = "RNL: " + binaryTree.RightNodeLeft();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox3.Text = "NLR: " + binaryTree.NodeLeftRight();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
