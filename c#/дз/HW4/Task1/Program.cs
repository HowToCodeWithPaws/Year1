using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Определить все тройки попарно различных целых чисел 𝑎,𝑏,𝑐 из интервала[1;20], для которых верно 𝑎^2+𝑏^2=𝑐^2.

namespace Task1
{
	class Program
	{
		static void FindTriplets()
		{
			int[] numberArray = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };

			for (int i = 0; i < 20; i++)
			{
				for (int k = i + 1; k < 20; k++)
				{
					for (int j = k + 1; j < 20; j++)
					{
						if (i * i + k * k == j * j)
						{
							Console.WriteLine($"{i} {k} {j}");
						}
					}
				}
			}
		}
		static void Main(string[] args)
		{
			do
			{
				FindTriplets();
				Console.WriteLine("Для повторного решения нажмите Enter, для выхода нажмите любой другой символ");

			} while (Console.ReadKey().Key == ConsoleKey.Enter);
		}
	}
}
