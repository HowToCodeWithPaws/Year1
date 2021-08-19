using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
	class Program
	{
		static void PrintArray(ulong[] array)
		{
			foreach (ulong item in array)
			{
				Console.Write(item + " ");
			}
		}

		static void CreateArray(ref ulong[] array)
		{
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = (ulong)Math.Pow(2, i);
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

				ulong[] arrayOfPower = new ulong[number];

				CreateArray(ref arrayOfPower);

				PrintArray(arrayOfPower);

				Console.WriteLine("\nДля повторного решения нажмите Enter, для выхода нажмите любой другой символ");

			} while (Console.ReadKey().Key == ConsoleKey.Enter);
		}
	}
}
