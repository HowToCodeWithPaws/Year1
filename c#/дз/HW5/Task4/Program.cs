using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
	class Program
	{
		static void PrintArray(ulong[] array)
		{
			for (int i = array.Length; i > 0; --i)
			{
				Console.Write(array[i - 1] + " ");
			}
		}

		static void CreateArray(ref ulong[] array)
		{
			array[0] = 1;
			array[1] = 1;

			for (int i = 2; i < array.Length; i++)
			{
				array[i] = (ulong)(array[i - 1] + array[i - 2]);
			}
		}

		public static uint Read()
		{
			uint input;

			do
			{
				Console.Write("\nВведите число элементов ");
			} while (!uint.TryParse(Console.ReadLine(), out input) || input <= 1);

			return input;
		}

		static void Main(string[] args)
		{
			do
			{
				uint number;

				number = Read();

				ulong[] arrayOfFibonacci = new ulong[number];

				CreateArray(ref arrayOfFibonacci);

				PrintArray(arrayOfFibonacci);

				Console.WriteLine("\nДля повторного решения нажмите Enter, для выхода нажмите любой другой символ");

			} while (Console.ReadKey().Key == ConsoleKey.Enter);
		}
	}
}
