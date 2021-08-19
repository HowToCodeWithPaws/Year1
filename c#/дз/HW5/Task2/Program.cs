using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
	class Program
	{
		static void PrintArray(uint[] array)
		{
			foreach (uint item in array)
			{
				Console.Write(item + " ");
			}
		}

		static void CreateArray(ref uint[] array)
		{
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = (uint)(2 * i + 1);
			}
		}

		public static uint Read()
		{
			uint input;

			do
			{
				Console.WriteLine("Введите число элементов.");
			} while (!uint.TryParse(Console.ReadLine(), out input) || input == 0);

			return input;
		}

		static void Main(string[] args)
		{
			do
			{
				uint number;

				number = Read();

				uint[] arrayOfOdds = new uint[number];

				CreateArray(ref arrayOfOdds);

				PrintArray(arrayOfOdds);

				Console.WriteLine("\nДля повторного решения нажмите Enter, для выхода нажмите любой другой символ");

			} while (Console.ReadKey().Key == ConsoleKey.Enter);
		}
	}
}
