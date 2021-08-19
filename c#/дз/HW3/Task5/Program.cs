using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5
{
	class Program
	{
		static public void Func(double X, ref double result)
		{
			switch (X >= 0.5)
			{
				case true:
					result = (Math.Sin(Math.PI / 2));
					break;

				case false:
					result = (Math.Sin(Math.PI * (X - 1) / 2));
					break;
			}
		}

		static public double Read()
		{
			double In;

			do
			{
				Console.WriteLine("Введите X ");

			} while (!double.TryParse(Console.ReadLine(), out In));

			return In;
		}

		static void Main(string[] args)
		{
			do
			{
				double ArgX, result = 0;

				ArgX = Read();

				Func(ArgX, ref result);

				Console.WriteLine($"{result}");
				Console.WriteLine("Для повторного решения нажмите Enter, для выхода нажмите любой другой символ");

			} while (Console.ReadKey().Key == ConsoleKey.Enter);
		}
	}
}
