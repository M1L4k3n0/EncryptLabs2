using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace PR2_6
{
    //2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97
    class Program
    {
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            string IVA = "IVA";

            string Gamma1 = "YUL"; //TEST
            string Gamma2 = "ACK";
            string Gamma3 = "XYZ";

            string Gamma_1 = "IVA"; //TEST1
            string Gamma_2 = "NYU";
            string Gamma_3 = "SER";


            //Encrypt.SecretMultyEncrypt(new int[] { alphabet.IndexOf(IVA[0]) + 1, alphabet.IndexOf(IVA[1]) + 1, alphabet.IndexOf(IVA[2]) + 1 });

            //Console.WriteLine("Press any key to see next method....");
            
            //Console.WriteLine("/////////////////////////////////////////");
            //Encrypt.GammaCipher(IVA, Gamma_1, Gamma_2, Gamma_3);

            //Console.WriteLine("Press any key to see next method....");
          
            //Console.WriteLine("/////////////////////////////////////////");
            //int m = 3, n = 5, s_num = alphabet.IndexOf(IVA[0]);


            //Encrypt.SchamirCipher(s_num, m, n);
            //Console.WriteLine("Press any key to see next method....");
            
            //Console.WriteLine("/////////////////////////////////////////");
            //Encrypt.BlumSecretCipher(s_num, m, n);
            //Console.WriteLine("Press any key to quit the program....");
            
        }
    }
}
