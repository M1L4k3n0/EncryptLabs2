using ConsoleRedirection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab2._2
{
    public partial class Form1 : Form
    {
        TextWriter _writer = null;
        public Form1()
        {
            InitializeComponent();
            _writer = new TextBoxStreamWriter(textBox2);
            // Redirect the out Console stream
            Console.SetOut(_writer);
        }

        private void button1_Click(object sender, EventArgs e)
        {

            textBox2.Text = "";
            Cyphers.RSA(int.Parse(textBox1.Text));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            Cyphers.ClausShnor(int.Parse(textBox1.Text));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            Cyphers.Feyge(int.Parse(textBox1.Text));
        }
    }
}
