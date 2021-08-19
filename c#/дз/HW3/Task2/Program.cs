using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
	class Program
	{
		static public void Reverse(uint Number, ref uint result)
		{
			while (Number > 0)
			{
				result *= 10;
				result += Number % 10;
				Number = Number / 10;
			}
		}

		static public uint Read()
		{
			uint In;

			do
			{
				Console.Write("Введите ваше число ");

			} while (!uint.TryParse(Console.ReadLine(), out In));

			return In;
		}

		static void Main(string[] args)
		{
			do
			{
				uint Number, result = 0;
				Number = Read();

				Reverse(Number, ref result);

				Console.WriteLine($"{result}");
				Console.WriteLine("Для повторного решения нажмите Enter, для выхода нажмите любой другой символ");

			} while (Console.ReadKey().Key == ConsoleKey.Enter);
		}
	}
}
