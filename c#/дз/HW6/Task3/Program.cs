using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Ввести положительные значения N и M. Построить двумерный 
// целочисленный массив (матрицу) с размерами N на M, элементы 
// которого a[i, j] = (i+1)*(2*j+1), для i от 0 до (N-1), 
// j от 0 до (M-1). 
// Вывести матрицу в виде таблицы, а также значения свойств 
// Rank и Length. 

namespace Task3
{
	class Program
	{
		public static bool Empty(uint[,] array)
		{
			if (array.GetLength(0) == array.GetLength(1))
			{
				int count = array.GetLength(0);

				for (int i = 0; i < array.GetLength(0); i++)
				{
					for (int j = 0; j < array.GetLength(1); j++)
					{
						if (j>=count)
						{
							array[i, j] = 0;
						}
					}
					--count;
				}
				return true;
			}
				Console.WriteLine("Wrong matrix");
			return false;
		}
		public static void GenerateArray(uint[,] array)
		{
			for (int i = 0; i < array.GetLength(0); i++)
			{
				for (int j= 0; j < array.GetLength(1); j++)
				{
					array[i, j] = (uint)((i+1) * (j*2+1));
				}
			}
		}

		public static void Printing(uint[,] array)
		{
			for (int i = 0; i < array.GetLength(0); i++)
			{
				for (int j = 0; j < array.GetLength(1); j++)
				{
					Console.Write("{0,3}",array[i,j]);
				}
				Console.WriteLine();
			}
		}

		public static uint Read(string message)
		{
			uint input;

			do
			{
				Console.WriteLine(message);
			} while (!uint.TryParse(Console.ReadLine(), out input)|| input<1);

			return input;
		}
		static void Main(string[] args)
		{
			do
			{
				uint sizeN, sizeM;

				sizeN = Read("Input N");
				sizeM = Read("Input M");

				uint[,] array = new uint[sizeN,sizeM];

				GenerateArray(array);

				Console.WriteLine($"\narray.Rank: {array.Rank}\narray.Length: {array.Length}");
				
				Printing(array);

				if (Empty(array)) Printing(array);
			
				Console.WriteLine("\nДля повторного решения нажмите Enter, для выхода нажмите любой другой символ");

			} while (Console.ReadKey().Key == ConsoleKey.Enter);	
		}
	}
}
