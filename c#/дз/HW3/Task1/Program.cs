using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
	class Program
	{
		static public void FindNumber(ref uint Number, ref uint N, ref string Summ)
		{
			for (uint i = 1; i <= 45; i++)
			{
				Number += i;
				if ((Number % 111 == 0) && (Number < 1000))
				{
					N = i;
					Summ = $"1 + 2 + 3 + ... + {N - 2} + {N - 1} + {N}";
					break;
				}
			}
		}

		static public void Main()
		{
			do
			{
				uint Number = 0, N = 0;
				string Summ = String.Empty;

				FindNumber(ref Number, ref N, ref Summ);

				Console.WriteLine($"{Number}\n{N}\n{Summ}");
				Console.WriteLine("Для повторного решения нажмите Enter, для выхода нажмите любой другой символ");

			} while (Console.ReadKey().Key == ConsoleKey.Enter);
		}
	}
}
