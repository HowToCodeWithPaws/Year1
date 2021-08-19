using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sem7
{
	class Program
	{
		static void Main(string[] args)
		{
			//int[,] matr = new int[3, 4] { { 0, 1, 3, 4 }, { 5, 6, 7, 8 }, { 9, -1, -2, -3 } };
			//Console.WriteLine($"{matr.GetType()}");
			//Console.WriteLine($"{matr.IsFixedSize}");
			//Console.WriteLine($"{matr.Rank}");
			//Console.WriteLine($"{matr.Length}");
			//Console.WriteLine($"{matr.GetLength(1)}");
			//Console.WriteLine($"{matr.GetUpperBound(1)}");

			//foreach (int item in matr)
			//{
			//	Console.WriteLine(item);
			//}
			// Foreach will print all the elements in a row, so for cycles are better

			//		char[][][] ch =
			//		{
			//			new char [][]{ new char[] { 'a','b'},
			//new char }
			//		}

			do
			{

				int[][] paskal;

				int N;

				do
				{
					Console.WriteLine("");
				} while (!int.TryParse(Console.ReadLine(), out N));

				paskal = new int[N + 1][];

				for (int i = 0; i < paskal.Length; i++)
				{
					paskal[i] = new int[i + 1];
					paskal[i][0] = paskal[i][i] = 1;
					for (int j = 1; j < i; j++)
					{
						paskal[i][j] = paskal[i - 1][j - 1] + paskal[i - 1][j];
					}
				}

				int n = N + 1;

				foreach (int[] ar in paskal)
				{
					Console.Write(new string(' ',n*3));
					foreach (int item in ar)
					{
						Console.Write(item.ToString().PadLeft(6,' '));
					}
					Console.WriteLine();
					n--;
				}

				Console.WriteLine("\nДля повторного решения нажмите Enter, для выхода нажмите любой другой символ");

			} while (Console.ReadKey().Key == ConsoleKey.Enter);
		}
	}
}
