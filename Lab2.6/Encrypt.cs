using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace PR2_6
{
    static class Encrypt
    {
        public static void BlumSecretCipher(int number, int m, int n)
        {
            Console.WriteLine("BlumSecretCipher ");
            int[] simpleNumbers = { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97 };

            Console.WriteLine($"secret = {number}");
            Console.WriteLine($"m = {m}");
            Console.WriteLine($"n = {n}");
            int p = 37;

            Console.WriteLine($"p = {p}");

            int[] d = new int[5];

            int count = 0;

            for (int i = 0; i < simpleNumbers.Length; i++)
            {
                if (simpleNumbers[i] > number && count < 5)
                {
                    d[count] = simpleNumbers[i];
                    count++;
                }

                if (count > 4)
                {
                    if ((d[0] * d[1] * d[2]) > (number * d[3] * d[4]))
                    {
                        d[4] = simpleNumbers[i];
                    }
                    else break;
                }
            }

            Console.WriteLine("d = ");

            for (int i = 0; i < d.Length; i++)
            {
                Console.Write(d[i] + "\t");
            }

            int dobutok = 1;

            for (int i = 0; i < m; i++)
            {
                dobutok *= d[i];
            }

            int r = new Random().Next(0, 60);

            while (r > (dobutok - number) / p)
            {
                r = new Random().Next(0, 60);
            };

            int sStrikh = number + r * p;

            int[] x = new int[n];
            int[] y = new int[n];

            for (int i = 0; i < n; i++)
            {
                x[i] = d[i];
                y[i] = sStrikh % d[i];
            }

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"(x{i},y{i}) = ({x[i]},{y[i]})");
            }

            int[] indexes = { 1, 3, 4 };

            int[] newX = { x[1], x[3], x[4] };
            int[] newY = { y[1], y[3], y[4] };

            Console.WriteLine("sbor m doley");

            for (int i = 0; i < m; i++)
            {
                Console.WriteLine($"(x{i},y{i}) = ({newX[i]},{newY[i]})");
            }

            int D = 1;

            for (int i = 0; i < m; i++)
            {
                D *= newX[i];
            }

            int[] Dj = new int[m];
            int[] Dj_1 = new int[m];

            for (int i = 0; i < m; i++)
            {
                Dj[i] = D / newX[i];

                for (int j = 0; j < 100000; j++)
                {
                    if ((Dj[i] * j) % newX[i] == 1)
                    {
                        Dj_1[i] = j;
                        break;
                    }
                }

                Console.WriteLine($"Dj[{i}] = {Dj[i]}");
                Console.WriteLine($"Dj_1[{i}] = {Dj_1[i]}");
            }

            int ssFinal = 0;

            for (int i = 0; i < m; i++)
            {
                ssFinal += newY[i] * Dj[i] * Dj_1[i];
            }

            ssFinal %= D;

            Console.WriteLine($"ssFinal = {ssFinal}");

            int secretFinal = ssFinal % p;

            Console.WriteLine($"secret = {secretFinal}");
        }


        public static void SchamirCipher(int secret, int m, int n)
        {
            

            Console.WriteLine($"secret = {secret}");
            Console.WriteLine($"m = {m}");
            Console.WriteLine($"n = {n}");
            int p = 37;

            Console.WriteLine($"p = {p}");

            Random rnd = new Random();

            int a2 = rnd.Next(1, 30);
            int a1 = rnd.Next(1, 30);

            Console.WriteLine($"a1 = {a1}");
            Console.WriteLine($"a2 = {a2}");

            Console.WriteLine("f(x) = (а2х2 + a1x + S) mod p");

            int[] x = new int[n];
            int[] y = new int[n];

            for (int i = 0; i < n; i++)
            {
                x[i] = i + 1;
                int num = i + 1;
                y[i] = (a2 * num * num + a1 * num + secret) % p;
            }

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"(x{i},y{i}) = ({x[i]},{y[i]})");
            }

            int[] indexes = { 1, 3, 4 };

            Console.WriteLine("sbor m doley");

            int count = 0;

            for (int i = 0; i < n; i++)
            {
                if (i == indexes[count])
                {
                    Console.WriteLine($"(x{i},y{i}) = ({x[i]},{y[i]})");
                    count++;
                }
            }

            Console.WriteLine($"secret = {secret}");
        }


        public static void WriteSecondMethodNumbers(string[] arr, string text)
        {
            Console.WriteLine(text + "\t" + $"{arr[0]} \t {arr[1]} \t {arr[2]} \t");
        }

        public static void GammaCipher(string IVA, string gamma1, string gamma2, string gamma3)
        {
            Console.WriteLine("UseGammaMethod \n");

            Console.WriteLine($"CHARS = {IVA}");
            Console.WriteLine($"gamma1 = {gamma1}");
            Console.WriteLine($"gamma2 = {gamma2}");
            Console.WriteLine($"gamma3 = {gamma3}");

            Console.WriteLine();

            string[] kmsBin = new string[3];
            string[] gamma1Bin = new string[3];
            string[] gamma2Bin = new string[3];
            string[] gamma3Bin = new string[3];

            byte[] kmsInASCII = Encoding.ASCII.GetBytes(IVA);
            byte[] gamma1InASCII = Encoding.ASCII.GetBytes(gamma1);
            byte[] gamma2InASCII = Encoding.ASCII.GetBytes(gamma2);
            byte[] gamma3InASCII = Encoding.ASCII.GetBytes(gamma3);

            for (int i = 0; i < 3; i++)
            {
                kmsBin[i] = Convert.ToString(kmsInASCII[i], 2);
                gamma1Bin[i] = Convert.ToString(gamma1InASCII[i], 2);
                gamma2Bin[i] = Convert.ToString(gamma2InASCII[i], 2);
                gamma3Bin[i] = Convert.ToString(gamma3InASCII[i], 2);
            }

            WriteSecondMethodNumbers(kmsBin, "CHARSBIN   ");
            WriteSecondMethodNumbers(gamma1Bin, "gamma1Bin");
            WriteSecondMethodNumbers(gamma2Bin, "gamma2Bin");
            WriteSecondMethodNumbers(gamma3Bin, "gamma3Bin");


            string[] cipher = new string[3];

            for (int i = 0; i < 3; i++)
            {
                char[] start = kmsBin[i].ToCharArray();
                for (int k = 0; k < 3; k++)
                {
                    string toWork = k == 0 ? gamma1Bin[i] : k == 1 ? gamma2Bin[i] : gamma3Bin[i];

                    for (int j = 0; j < gamma1Bin.Length; j++)
                    {
                        if (start[j] == '0')
                        {
                            start[j] = toWork[j] == '1' ? '1' : '0';
                        }
                        else
                        {
                            start[j] = toWork[j] == '1' ? '0' : '1';
                        }
                    }
                }

                cipher[i] = new string(start);
            }

            WriteSecondMethodNumbers(cipher, "cipher   ");

            string[] atStart = new string[3];

            for (int i = 0; i < 3; i++)
            {
                char[] start = cipher[i].ToCharArray();
                for (int k = 0; k < 3; k++)
                {
                    string toWork = k == 0 ? gamma1Bin[i] : k == 1 ? gamma2Bin[i] : gamma3Bin[i];

                    for (int j = 0; j < gamma1Bin.Length; j++)
                    {
                        if (start[j] == '0')
                        {
                            start[j] = toWork[j] == '1' ? '1' : '0';
                        }
                        else
                        {
                            start[j] = toWork[j] == '1' ? '0' : '1';
                        }
                    }
                }

                atStart[i] = new string(start);
            }

            WriteSecondMethodNumbers(atStart, "atStart  ");
        }


        public static void SecretMultyEncrypt(int[] ch)
        {
            //int x = 3;
            //int _I = 9;
            // int _V = 22;
            //int _A = 1;

            Console.WriteLine("FirstMethod. Input \n");

            Console.WriteLine($"zi = {ch[0]}");
            Console.WriteLine($"zv = {ch[1]}");
            Console.WriteLine($"za = {ch[2]}");

            //v[0] = 10;
            //v[1] = 5;
            //v[2] = 2;

            Console.WriteLine();

            //int ed = 3, nd = 47, dd = 31;
            //int ec = 11, nc = 47, dc = 37;
            //int ey = 7, ny = 47, dy = 91;

            int ed = 5, nd = 91, dd = 29;
            int ec = 7, nc = 91, dc = 31;
            int ey = 17, ny = 91, dy = 17;

            int secretX = 3;
            Console.WriteLine("A cipher");
            int resultY = (int)BigInteger.ModPow(ch[2] + secretX, ec, nc);

            Console.WriteLine("secretX " + secretX + ", cipher #1 " + resultY);

            Console.WriteLine("V cipher");
            int number1 = (int)BigInteger.ModPow(resultY, dc, nc);

            int resultC = (int)BigInteger.ModPow(ch[1] + number1, ed, nd);

            Console.WriteLine("decrypt " + number1 + ", cipher #2 " + resultC);

            Console.WriteLine("I cipher");
            int number2 = (int)BigInteger.ModPow(resultC, dd, nd);

            int resultD = (int)BigInteger.ModPow(ch[0] + number2, ey, ny);

            Console.WriteLine("decrypt " + number2 + ", cipher #3 " + resultD);

            double number = (int)BigInteger.ModPow(resultD, ey, ny);

            double finalResult = (number - secretX) / 3;

            Console.WriteLine("RESULT = " + finalResult);
        }
    }
}
