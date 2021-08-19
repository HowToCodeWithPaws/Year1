using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// Определите и инициализируйте массив строк.
// Выведите строки в порядке возрастания их длин.
// Порядок элементов в исходном массиве строк не менять.

namespace Task4
{
	class Program
	{
		public static void HelpingArray(uint[] index, string[] lines)
		{

			for (uint i = 0; i < index.Length; i++)
			{
				index[i] = i;
			}

			for (int i = 0; i < index.Length - 1; i++)
			{
				for (int j = i + 1; j < index.Length; j++)
				{
					if (lines[index[i]].Length > lines[index[j]].Length)
					{
						uint temp = index[i];
						index[i] = index[j];
						index[j] = temp;
					}
				}
			}
		}

		public static void Print(string[] lines, uint[] index)
		{
			foreach (uint number in index)
			{
				Console.WriteLine(lines[number]);
			}
		}

		static void Main(string[] args)
		{
			do
			{
				string[] lines = new string[] { "нуль", "один", "два", "три", "четыре",
						"пять", "шесть", "семь", "восемь", "девять", "десять" };

				int len = lines.Length;

				uint[] index = new uint[len];

				HelpingArray(index, lines);

				Print(lines, index);

				Console.WriteLine("\nДля повторного решения нажмите Enter, для выхода нажмите любой другой символ");

			} while (Console.ReadKey().Key == ConsoleKey.Enter);
			
		}
	}
}
