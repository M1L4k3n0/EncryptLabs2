using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Lab2._2
{
	class Program
	{
        
        static void Main()
		{
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

   //         Console.WriteLine("Выберите тип шифра:\n 1 - RSA,\n 2 - Шнорра,\n 3 - Фейге-Фиата-Шамира");
			//int sypherType = int.Parse(Console.ReadLine());

			//Console.Write("Введите k: ");
			//int index = int.Parse(Console.ReadLine());

			//switch (sypherType)
			//{
			//	case 1: Cyphers.RSA(index); break;
			//	case 2: Cyphers.ClausShnor(index); break;
			//	case 3: Cyphers.Feyge(index); break;
			//}
			//Console.ReadKey();
		}
	}
}
