using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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

namespace Lab4
{
    public partial class Form1 : Form
    {
        TextWriter _writer = null;
        string alphabet = "ABCDEFGHIJKLMNOPQRSTUWXYZ";

        string lastName = "ILYINMAKSY";

        string full = "ILYINVASILENKOVOLODYM";


        
    public Form1()
        {
            InitializeComponent();
            _writer = new TextBoxStreamWriter(textBox4);
            Console.SetOut(_writer);

            int[] positions = new int[full.Length];

            for (int i = 0; i < positions.Length; i++)
            {
                positions[i] = alphabet.IndexOf(full[i]) + 1;
            }





           
        }

      

        private void button1_Click(object sender, EventArgs e)
        {
            textBox4.Text = " ";
            CRC(new int[] { 23, 19, 17 });
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox4.Text = " ";            
            Bits(lastName);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            textBox4.Text = " ";
            int[] positions = new int[full.Length];
            for (int i = 0; i < positions.Length; i++)
            {
                positions[i] = alphabet.IndexOf(full[i]) + 1;
            }
            Lun(MakeArray(positions, 15));
        }
        private void button4_Click(object sender, EventArgs e)
        {
            textBox4.Text = " ";
            int[] positions = new int[full.Length];
            for (int i = 0; i < positions.Length; i++)
            {
                positions[i] = alphabet.IndexOf(full[i]) + 1;
            }
            EAN13(MakeArray(positions, 13));
        }
        private void button5_Click(object sender, EventArgs e)
        {
            textBox4.Text = " ";
            int[] positions = new int[full.Length];
            for (int i = 0; i < positions.Length; i++)
            {
                positions[i] = alphabet.IndexOf(full[i]) + 1;
            }
            EAN13(MakeArray(positions, 13));
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox4.Text = " ";
            int[] positions = new int[full.Length];
            for (int i = 0; i < positions.Length; i++)
            {
                positions[i] = alphabet.IndexOf(full[i]) + 1;
            }
            INN(MakeArray(positions, 10));
        }
        private void button7_Click(object sender, EventArgs e)

        {
            textBox4.Text = " ";
            int[] positions = new int[full.Length];
            for (int i = 0; i < positions.Length; i++)
            {
                positions[i] = alphabet.IndexOf(full[i]) + 1;
            }
            INN(MakeArray(positions, 10));
        }
        private void button8_Click(object sender, EventArgs e)
        {

            textBox4.Text = " ";
            int[] positions = new int[full.Length];
            for (int i = 0; i < positions.Length; i++)
            {
                positions[i] = alphabet.IndexOf(full[i]) + 1;
            }
            RailwayTransport(MakeArray(positions, 5));
        }
        private void button9_Click(object sender, EventArgs e)
        {
            textBox4.Text = " ";
            int[] positions = new int[full.Length];
            for (int i = 0; i < positions.Length; i++)
            {
                positions[i] = alphabet.IndexOf(full[i]) + 1;
            }
            CRC(new int[] { alphabet.IndexOf(lastName[0]) + 1, alphabet.IndexOf(lastName[1]) + 1, alphabet.IndexOf(lastName[2]) + 1 });
        }
        private void button10_Click(object sender, EventArgs e)
        {
            textBox4.Text = " ";
            string message = lastName.Substring(0, 2);
            byte[] messageInASCII = Encoding.ASCII.GetBytes(message);
            string newMessage = "";


            for (int i = 0; i < messageInASCII.Length; i++)
            {
                newMessage += Convert.ToString(messageInASCII[i], 2);
            }

            newMessage = newMessage.Substring(0, 11);

            ECC(newMessage);
        }
























        private static void ECC(string newMessage)
        {
            Console.WriteLine("ECC algorithm. Input");
            Console.WriteLine(newMessage);

            string result = "";

            result = "11" + newMessage[0] + "0" + newMessage.Substring(1, 3) + "0" + newMessage.Substring(4, newMessage.Length - 4);

            int pb = 0;

            for (int i = 0; i < result.Length; i++)
            {
                pb += int.Parse(result[i].ToString());
            }

            pb %= 2;

            Console.WriteLine(result + ", pb = " + pb);
        }

        private static void CRC(int[] v)
        {
            Console.WriteLine("G(x) = x^4 + x^1 + x^0");

            Console.WriteLine("CRC algorithm. Input");

            foreach (var item in v)
            {
                Console.Write(item + "\t");
            }

            Console.WriteLine();

            string dect = "1011";

            Console.WriteLine("dect = " + dect + "(" + Convert.ToInt32(dect, 2) + ")");

            Console.WriteLine("Делимое \t *x^N \t Частное \t Остаток \t Результат");

            for (int i = 0; i < v.Length; i++)
            {
                string input = Convert.ToString(v[i], 2);

                string input2 = string.Concat(input, "0000");

                string chastnoe = GetChastnoeAndOstatokForCRC(input2, dect)[0];
                string ostatok = GetChastnoeAndOstatokForCRC(input2, dect)[1];

                int input2Integer = Convert.ToInt32(input2, 2);

                int ostatokInteger = Convert.ToInt32(ostatok, 2);

                int chastnoeInteger = Convert.ToInt32(chastnoe, 2);

                string final = string.Concat(input, ostatok);

                int finalRes = Convert.ToInt32(final, 2);

                Console.WriteLine(v[i] + "(" + input + ")" + "\t" +
                    input2 + "(" + input2Integer + ")" + "\t" +
                   chastnoe + "(" + chastnoeInteger + ")" + "\t"
                    + ostatok + "(" + ostatokInteger + ")" + "\t"
                    + final + "(" + finalRes + ")");
            }
        }

        private static string[] GetChastnoeAndOstatokForCRC(string imya2, string dect)
        {
            string delit, resultat = "";
            bool f = true;
            do
            {
                delit = "";
                int l1 = imya2.Length - 1;
                int l2 = dect.Length - 1;
                int raz = l1 - l2;

                string dect2 = dect;
                for (int i = 0; i < raz; i++)
                {
                    dect2 = dect2 + "0";
                }

                for (int i = 0; i <= l1; i++)
                {
                    delit = delit + Convert.ToString(Convert.ToInt32(Convert.ToString(imya2[i]), 2) ^ Convert.ToInt32(Convert.ToString(dect2[i]), 2));
                }

                int counter = 0;

                bool h = true;
                if (delit.IndexOf('1') >= 0)
                {
                    do
                    {
                        if (delit[1] != '0')
                            h = false;
                        if (delit[0] == '0' && delit.Length >= dect.Length)
                        {
                            delit = delit.Substring(1, delit.Length - 1);
                            counter++;
                        }
                        else
                        {
                            h = false;
                        }
                    }
                    while (h);
                }
                else
                {
                    imya2 = "0000";
                    resultat = "1" + new string('0', dect.Length - 1);
                    f = false;
                    break;
                }

                resultat += "1" + new string('0', counter - 1);


                if (delit.Length < dect.Length)
                    f = false;

                imya2 = delit;
            }
            while (f);

            return new string[] { resultat, imya2 };
        }

        private static void RailwayTransport(int[] v)
        {
            Console.WriteLine("RailwayTransport algorithm. Input");

            foreach (var item in v)
            {
                Console.Write(item + "\t");
            }

            Console.WriteLine();

            int controlNumber = (1 * v[0] + 2 * v[1] + 3 * v[2] + 4 * v[3]) % 11;

            if (controlNumber == 10)
            {
                controlNumber = (3 * v[0] + 4 * v[1] + 5 * v[2] + 6 * v[3]) % 11;

                if (controlNumber == 10)
                {
                    controlNumber = 0;
                }
            }

            Console.WriteLine("LastNumber should be " + controlNumber);
        }

        private static void INN(int[] v)
        {
            Console.WriteLine("INN algorithm. Input");

            foreach (var item in v)
            {
                Console.Write(item + "\t");
            }

            Console.WriteLine();

            int result = ((2 * v[0] + 4 * v[1] + 10 * v[2] + 3 * v[3] + 5 * v[4] + 9 * v[5] + 5 * v[6] + 6 * v[7] + 8 * v[8]) % 11) % 10;

            Console.WriteLine("LastNumber should be " + result);
        }

        private static void EAN13(int[] v)
        {
            Console.WriteLine("EAN-13 algorithm. Input");

            foreach (var item in v)
            {
                Console.Write(item + "\t");
            }

            Console.WriteLine();

            int sumNeChet = 0;
            int sumChet = 0;

            for (int i = 1; i <= v.Length; i++)
            {
                if (i % 2 == 0)
                {
                    sumChet += v[i - 1];
                }
                else if (i != v.Length)
                {
                    sumNeChet += v[i - 1];
                }
            }

            sumChet *= 3;

            int result = 0;

            for (int i = 0; ; i++)
            {
                if ((sumChet + sumNeChet + i) % 10 == 0)
                {
                    result = i;
                    break;
                }
            }


            Console.WriteLine("LastNumber should be " + result);
        }

        private static void Lun(int[] v)
        {
            Console.WriteLine("Lun algorithm. Input");

            foreach (var item in v)
            {
                Console.Write(item + "\t");
            }

            Console.WriteLine();

            int sumNeChet = 0;
            int sumChet = 0;

            for (int i = 1; i <= v.Length; i++)
            {
                if (i % 2 == 0)
                {
                    v[i - 1] = (v[i - 1] * 2) % 9;

                    sumChet += v[i - 1];
                }
                else
                {
                    sumNeChet += v[i - 1];
                }
            }

            int result = 0;

            for (int i = 0; ; i++)
            {
                if ((sumChet + sumNeChet + i) % 10 == 0)
                {
                    result = i;
                    break;
                }
            }


            Console.WriteLine("LastNumber should be " + result);
        }

        private static void Bits(string lastName)
        {
            Console.WriteLine("Bits algorithm");
            Console.WriteLine("Char \t Bits \t EvenBit \t OddBit");
            foreach (char item in lastName)
            {
                byte[] messageInASCII = Encoding.ASCII.GetBytes(new char[] { item });
                string newMessage = "";

                for (int i = 0; i < messageInASCII.Length; i++)
                {
                    newMessage += Convert.ToString(messageInASCII[i], 2);
                }

                int EvenBit = (newMessage.Length - newMessage.Replace("1", "").Length) % 2;

                int OddBit = EvenBit == 1 ? 0 : 1;

                Console.WriteLine($"{item} \t {newMessage} \t {EvenBit} \t {OddBit}");
            }

        }

        private static int[] MakeArray(int[] array, int count)
        {
            int[] result = new int[count];

            for (int i = 0; i < count; i++)
            {
                result[i] = array[i];
            }

            return result;
        }


    }
}
