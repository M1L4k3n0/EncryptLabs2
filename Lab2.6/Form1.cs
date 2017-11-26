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

namespace PR2_6
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
        
        string IVA = "IVA";

        string Gamma1 = "YUL"; //TEST
        string Gamma2 = "ACK";
        string Gamma3 = "XYZ";

        string Gamma_1 = "IVA"; //TEST1
        string Gamma_2 = "NYU";
        string Gamma_3 = "SER";
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
             }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            string alphabet = Convert.ToString(textBox5.Text);
            Encrypt.SecretMultyEncrypt(new int[] { alphabet.IndexOf(IVA[0]) + 1, alphabet.IndexOf(IVA[1]) + 1, alphabet.IndexOf(IVA[2]) + 1 });
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            string alphabet = Convert.ToString(textBox5.Text);
            Encrypt.GammaCipher(IVA, Gamma_1, Gamma_2, Gamma_3);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            string alphabet = Convert.ToString(textBox5.Text);
            int m = 3, n = 5, s_num = alphabet.IndexOf(IVA[0]);            
            Encrypt.SchamirCipher(s_num, m, n);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            string alphabet = Convert.ToString(textBox5.Text);
            int m = 3, n = 5, s_num = alphabet.IndexOf(IVA[0]);
            Encrypt.BlumSecretCipher(s_num, m, n);
        }
    }
}
