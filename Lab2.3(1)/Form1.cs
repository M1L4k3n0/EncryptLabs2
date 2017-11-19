using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RSA
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public int fun(int p, int a, int b)
        {
            int s = 1;
            for (int i = 1; i <= b; i++)
            {
               
                s = (s * a) % p;
            }
            return s;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string str1, str2;
            Random myrandom = new Random();
            int p = 79, q = 23, n, f,a, b=1,s,y,w;
            //Label A;
            n = p * q;
            f=(p-1)*(q-1);

            //a-ga keri san b esepteu
        A:
            b = 1;
            a = myrandom.Next(f);
            while (b < f)
            {
                if ((b * a) % f == 1)
                    break;
                b = b + 1;
            }
            if (b == f) goto A;
            //
            //
            //
            str1 = textBox1.Text;
            textBox2.Text = "";
            textBox3.Text = "";
          //  for (int i = 0; i < str1.Length; i++)
          //  {
               // k = (int)str1[i];
                //koltanba jasau
                y = Math.Abs(textBox1.Text.GetHashCode());
                y = y % n;
                s = fun(n,y,a);
                textBox2.Text = y.ToString();
                textBox3.Text = s.ToString();

                
                //koltanbany tekseru
                w = fun(n,s,b);
                textBox4.Text = w.ToString();
                if (y == w)
                {
                    label1.Text = "Қолтаңба ақиқат";
                }
                else
                {
                    label1.Text = "Қолтаңба ақиқат емес";
                }
             
           // }

        }
    }
}
