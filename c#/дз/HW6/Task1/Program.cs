using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Получить от пользователя целое число N.Создать двумерный массив размера в NxN и заполнить его по правилу:


namespace Task1
{
	class Program
	{
		static void PrintArray(int[,] array)
		{
			for (int i = 0; i < array.GetLength(0); i++)
			{
				for (int j = 0; j < array.GetLength(1); j++)
				{
					Console.Write(array[i, j] + " ");
				}
				Console.WriteLine();
			}
		}
		public static void FillArray(int[,] array)
		{
			for (int i = 0; i < array.GetLength(0); i++)
			{
				for (int j = 0; j < array.GetLength(1); j++)
				{
					int value = (i + j + 1) % (array.GetLength(0) + 1);

					if (i + j >= array.GetLength(0)) value += 1;
					array[i, j] = value;
				}
			}
		}
		public static int Read()
		{
			int input;

			do
			{
				Console.WriteLine("Write down the number N");
			} while (!int.TryParse(Console.ReadLine(), out input) || input < 1);

			return input;
		}
		static void Main(string[] args)
		{
			do
			{
				int N = Read();

				int[,] array = new int[N, N];

				FillArray(array);

				PrintArray(array);

				Console.WriteLine("\nДля повторного решения нажмите Enter, для выхода нажмите любой другой символ");

			} while (Console.ReadKey().Key == ConsoleKey.Enter);
		}
	}
}
