using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
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

		static void CreateArray(ref uint[] array, int coeffA, int coeffD)
		{
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = (uint)(coeffA + coeffD*i);
			}
		}

		public static uint Read()
		{
			uint input;

			do
			{
				Console.Write("\nВведите число элементов ");
			} while (!uint.TryParse(Console.ReadLine(), out input) || input <=1);

			return input;
		}

		public static int Read(string name)
		{
			int input;

			do
			{
				Console.Write($"\nВведите коэффициент {name} ");
			} while (!int.TryParse(Console.ReadLine(), out input));

			return input;
		}

		static void Main(string[] args)
		{
			do
			{
				uint number;

				int coeffA, coeffD;

				number = Read();
				coeffA = Read("A");
				coeffD = Read("D");

				uint[] arrayOfNumbers = new uint[number];

				CreateArray(ref arrayOfNumbers, coeffA, coeffD);

				PrintArray(arrayOfNumbers);

				Console.WriteLine("\nДля повторного решения нажмите Enter, для выхода нажмите любой другой символ");

			} while (Console.ReadKey().Key == ConsoleKey.Enter);
		}
	}
}
