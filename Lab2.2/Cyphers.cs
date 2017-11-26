using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace Lab2._2
{
	public static class Cyphers
	{
		public static List<char> RussianAlphabet = new List<char> { 'а', 'б', 'в', 'г', 'д', 'е', 'ё', 'ж', 'з', 'и', 'й', 'к', 'л', 'м', 'н', 'о', 'п', 'р', 'с', 'т', 'у', 'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'ъ', 'ы', 'ь', 'э', 'ю', 'я' };
		private static Random aRand = new Random();
		private static int[] SimpleDigits = new int[] { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97, 101 };
		private static int[] SimpleDigitsMax = new int[] {  2, 3,5,7,11,13,17,19,23,29,31,37,41,43,47,53,59,61,67,71,
															73,79,83,89,97,101,103,107,109,113,127,131,137,139,149,151,157,163,167,173,
															179,181,191,193,197,199,211,223,227,229,233,239,241,251,257,263,269,271,277,281,
															283,293,307,311,313,317,331,337,347,349,353,359,367,373,379,383,389,397,401,409,
															419,421,431,433,439,443,449,457,461,463,467,479,487,491,499,503,509,521,523,541,
															547,557,563,569,571,577,587,593,599,601,607,613,617,619,631,641,643,647,653,659,
															661,673,677,683,691,701,709,719,727,733,739,743,751,757,761,769,773,787,797,809,
															811,821,823,827,829,839,853,857,859,863,877,881,883,887,907,911,919,929,937,941,
															947,953,967,971,977,983,991,997,1009, 1013, 1019, 1021, 1031, 1033, 1039, 1049, 1051, 1061, 1063, 1069,
															1087, 1091, 1093, 1097, 1103, 1109, 1117, 1123, 1129, 1151, 1153, 1163, 1171, 1181, 1187, 1193, 1201, 1213, 1217, 1223,
															1229, 1231, 1237, 1249, 1259, 1277, 1279, 1283, 1289, 1291, 1297, 1301, 1303, 1307, 1319, 1321, 1327, 1361, 1367, 1373,
															1381, 1399, 1409, 1423, 1427, 1429, 1433, 1439, 1447, 1451, 1453, 1459, 1471, 1481, 1483, 1487, 1489, 1493, 1499, 1511,
															1523, 1531, 1543, 1549, 1553, 1559, 1567, 1571, 1579, 1583, 1597, 1601, 1607, 1609, 1613, 1619, 1621, 1627, 1637, 1657,
															1663, 1667, 1669, 1693, 1697, 1699, 1709, 1721, 1723, 1733, 1741, 1747, 1753, 1759, 1777, 1783, 1787, 1789, 1801, 1811,
															1823, 1831, 1847, 1861, 1867, 1871, 1873, 1877, 1879, 1889, 1901, 1907, 1913, 1931, 1933, 1949, 1951, 1973, 1979, 1987,
															1993, 1997, 1999, 2003, 2011, 2017, 2027, 2029, 2039, 2053, 2063, 2069, 2081, 2083, 2087, 2089, 2099, 2111, 2113, 2129,
															2131, 2137, 2141, 2143, 2153, 2161, 2179, 2203, 2207, 2213, 2221, 2237, 2239, 2243, 2251, 2267, 2269, 2273, 2281, 2287,
															2293, 2297, 2309, 2311, 2333, 2339, 2341, 2347, 2351, 2357, 2371, 2377, 2381, 2383, 2389, 2393, 2399, 2411, 2417, 2423,
															2437, 2441, 2447, 2459, 2467, 2473, 2477, 2503, 2521, 2531, 2539, 2543, 2549, 2551, 2557, 2579, 2591, 2593, 2609, 2617,
															2621, 2633, 2647, 2657, 2659, 2663, 2671, 2677, 2683, 2687, 2689, 2693, 2699, 2707, 2711, 2713, 2719, 2729, 2731, 2741,
															2749, 2753, 2767, 2777, 2789, 2791, 2797, 2801, 2803, 2819, 2833, 2837, 2843, 2851, 2857, 2861, 2879, 2887, 2897, 2903,
															2909, 2917, 2927, 2939, 2953, 2957, 2963, 2969, 2971, 2999, 3001, 3011, 3019, 3023, 3037, 3041, 3049, 3061, 3067, 3079,
															3083, 3089, 3109, 3119, 3121, 3137, 3163, 3167, 3169, 3181, 3187, 3191, 3203, 3209, 3217, 3221, 3229, 3251, 3253, 3257,
															3259, 3271, 3299, 3301, 3307, 3313, 3319, 3323, 3329, 3331, 3343, 3347, 3359, 3361, 3371, 3373, 3389, 3391, 3407, 3413,
															3433, 3449, 3457, 3461, 3463, 3467, 3469, 3491, 3499, 3511, 3517, 3527, 3529, 3533, 3539, 3541, 3547, 3557, 3559, 3571 };

		public static void RSA(int k = 12)
		{
			int sLength = SimpleDigits.Length, d = 0, e = 0;

			bool flag = true;

			int pPosition = aRand.Next(1, sLength);
			int qPosition = aRand.Next(1, sLength);
			while (pPosition == qPosition)
			{
				qPosition = aRand.Next(1, sLength);
			}

			int p = SimpleDigits[pPosition];
			int q = SimpleDigits[qPosition];

			int n = p * q;
			int m = (p - 1) * (q - 1);
			List<int> mDivisors = GetDivisors(m);
			int fi = 2;
			while (d == 0)
			{
				if (!mDivisors.Any(u => fi % u == 0))
				{
					d = fi;
				}
				fi++;
			}
			while (flag)
			{
				e++;
				if ((d * e) % m == 1 && d != e)
				{
					flag = false;
				}
			}
			flag = true;
			int r = 1;
			while (flag)
			{
				r++;
				if (Pow(k, e) % n == r)
				{
					flag = false;
				}
			}
			BigInteger _k = Pow(r, d) % n;
			ShowInfoRSA(k, p, q, m, n, mDivisors, d, e, r, (int)_k);
		}
		public static void ClausShnor(int k = 17)
		{
			int sLength = SimpleDigits.Length;

			int pPosition = aRand.Next(1, 10);
			int qPosition = 9;
			int p = SimpleDigits[pPosition];
			int q = SimpleDigits[qPosition];
			while ((p - 1) % q != 0)
			{
				pPosition++;
				p = SimpleDigitsMax[pPosition];
				if(p > 100)
				{
					qPosition++;
					q = SimpleDigits[qPosition];
					p = SimpleDigits[2];
				}
			}
			int x = aRand.Next(1, q - 1);
			bool flag = true;
			int g = 1;
			while (flag)
			{
				g++;
				if (Pow(g, q) % p == 1)
				{
					flag = false;
				}
			}
			flag = true;
			int y = 1;
			while (flag)
			{
				y++;
				if ((Pow(g, x) * y) % p == 1)
				{
					flag = false;
				}
			}
			ShowClausGenerations(p, q, x, g, y);
			int r = (int)Pow(g, k) % p;
			int e = aRand.Next(0, 64);
			int s = (k + x * e) % q;
			if (r == Pow(g, s) * Pow(y, e) % p)
			{
				ShowClausAutentication(k, g, p, r, e, x, q, s);
			}

		}
		public static void Feyge(int r = 15)
		{
			int p = 5;
			int q = 7;
			int n = p * q;
			int v = 16;
			int _v = 11;
			int s = 9;
			int y = 0;

			int z = (int)Pow(r, 2) % p;
			int b = aRand.Next(0, 1);
			bool flag = false;
			if(b== 0)
			{
				if(z == Pow(r, 2) % p)
				{
					flag = true;
				}
			}
			else
			{
				y = (r * s) % p;
				if(z == (Pow(y, 2) * v) % p)
				{
					flag = true;
				}
			}
			if (flag)
			{
				ShowFeyge(p, q, n, v, _v, s, y, b, r, z);
			}
		}

		private static void ShowFeyge(int p, int q, int n, int v, int _v, int s, int y, int b, int r, int z)
		{
           
			Console.WriteLine("Два случайных числа p, q: {0} и {1}.\nИх произведение n: {2}.", p, q, n);
			Console.WriteLine("v =  {0}", v);
			Console.WriteLine("!v =  {0}", _v);
			Console.WriteLine("s = ({0}^2) % {1}  = {2} => {0}", s, n, _v);
			Console.WriteLine("r примем за {0}", r);
			Console.WriteLine("b = {0}", b);
			if (b> 0)
			{
				Console.WriteLine("y =  ({0}*{1}) % {2} = {3}", r, s, p, y);
				Console.WriteLine("z == (y^2 * v) % p.");
				Console.WriteLine("Сообщение истинно.");
				
			}
			else
			{
				Console.WriteLine("z == (r^2) % p. => {0} == ({1}^2)% {2}", z, r, p);
				Console.WriteLine("Сообщение истинно.");
				
			}
		}
		private static void ShowClausAutentication(int k, int g, int p, int r, int e, int x, int q, int s)
		{
            
            Console.WriteLine("k примем за {0}", k);
			Console.WriteLine("За формулой r = (g ^ k) % p, имеем r = ({0} ^ {1}) % {2} = {3}", g, k, p, r);
			Console.WriteLine("e = {0}", e);
			Console.WriteLine("s = (k + x * e) % q = ({0} + {1} * {2}) % {3} = {4}", k, x, e, q, s);
			Console.WriteLine("r == Pow(g, s) * Pow(y, e) % p");
			Console.WriteLine("Сообщение истинно.");
			
		}
		private static  void ShowClausGenerations(int p, int q, int x, int g, int y)
		{
			Console.WriteLine("Два случайных числа p, q: {0} и {1}.\nПри чем (p - 1) % q == 0", p, q);
			Console.WriteLine("x = {0}", x);
			Console.WriteLine("За формулой (g ^ q) % p == 1 имеем ({0} ^ {1}) % {2} == 1\nОтсюда g = {0}", g, q, p);
			Console.WriteLine("За формулой ((g ^ x)*y) % p == 1 имеем (({0} ^ {1})* {2}) % {3} == 1\nОтсюда y = {2}", g, x, y, p);
		}
		private static void ShowInfoRSA(int k, int p, int q, int m, int n, List<int> divisors, int d, int e, int r, int _k)
		{
			Console.WriteLine("k примем за {0}", k);
			Console.WriteLine("Два случайных числа p, q: {0} и {1}.\nИх произведение n: {2}.\n(p - 1) * (q - 1) = {3} (m).", p, q, m, n);
			Console.WriteLine("Делители m:");
			ShowListSimple(divisors);
			Console.WriteLine("d = {0}", d);
			Console.WriteLine("За формулой (d * e) % m == 1 имеем ({0} * {1}) % {2} == 1\nОтсюда е = {1}", d, e, m);
			Console.WriteLine("За формулой (k ^ e) % n == r имеем ({0} ^ {1}) % {2} == {3}\nОтсюда r = {3}", k, e, n, r);
			Console.WriteLine("Посылаем r ({0}) A", r);
			Console.WriteLine("B вычисляет 'k = (r ^ d) % n, имеем ({0} ^ {1}) % {2} \nОтсюда 'k = {3}", r, d, n, _k);
			Console.WriteLine("Сообщение истинно.");
			
		}

		private static void ShowListSimple<T>(List<T> list)
		{
			for (int i = 0; i < list.Count; i++)
			{
				Console.Write(list[i] + "\t");
			}
			Console.WriteLine();
		}

		private static BigInteger Pow(BigInteger digit, long pow)
		{
			BigInteger start = digit;
			for (int i = 1; i < pow; i++)
			{
				digit *= start;
			}
			return digit;
		}

		private static List<int> GetDivisors(int input)
		{
			List<int> divisors = new List<int>();

			int i = 0;
			while (input != 1)
			{
				if (input % SimpleDigitsMax[i] == 0)
				{
					input /= SimpleDigitsMax[i];
					if (!divisors.Contains(SimpleDigitsMax[i]))
					{
						divisors.Add(SimpleDigitsMax[i]);
					}
				}
				else
				{
					i++;
				}
			}
			return divisors;
		}
	}
}
