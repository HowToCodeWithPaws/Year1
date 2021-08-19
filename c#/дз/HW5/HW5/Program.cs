using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW5
{
	class Program
	{

		static void PrintArray(int[] array)
		{
			foreach (int item in array)
			{
				Console.Write(item + " ");
			}
		}

		static void CreateArray(ref int[] array)
		{
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = random.Next(1, 51);
			}
		}

		static void ChangeArray(ref int[] array, int exchange)
		{
			int max = array.Max();

			for (int i = 0; i < array.Length; ++i)
			{
				if (array[i] == max)
				{
					array[i] = exchange;
				}
			}
		}

		static Random random = new Random();

		public static int Read()
		{
			int input;

			do
			{
				Console.Write("\nВведите целое число, которым хотите заменить максимальный элемент массива ");
			} while (!int.TryParse(Console.ReadLine(), out input));

			return input;
		}

		static void Main(string[] args)
		{
			do
			{
				int changeto;

				uint number = (uint)random.Next(1, 21);

				int[] arrayOfRandoms = new int[number];

				CreateArray(ref arrayOfRandoms);

				Console.WriteLine("Изначальный массив сгенерирован");

				PrintArray(arrayOfRandoms);

				changeto = Read();

				ChangeArray(ref arrayOfRandoms, changeto);

				Console.WriteLine("Измененный массив");

				PrintArray(arrayOfRandoms);

				Console.WriteLine("\nДля повторного решения нажмите Enter, для выхода нажмите любой другой символ");

			} while (Console.ReadKey().Key == ConsoleKey.Enter);
		}
	}
}
