using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
	class Program
	{
		static public bool GetValue(double X, double Y)
		{
			return ((X * X + Y * Y <= 4) && (Y <= X) && (X >= 0));
		}

		static public double Read(string Name)
		{
			double In;

			do
			{
				Console.WriteLine($"Введите координату {Name}");

			} while (!double.TryParse(Console.ReadLine(), out In));

			return In;
		}

		static void Main(string[] args)
		{
			do
			{
				double CoordX, CoordY;
				bool result;

				CoordX = Read("X");
				CoordY = Read("Y");

				result = GetValue(CoordX, CoordY);

				Console.WriteLine($"{result}");
				Console.WriteLine("Для повторного решения нажмите Enter, для выхода нажмите любой другой символ");

			} while (Console.ReadKey().Key == ConsoleKey.Enter);
		}
	}
}
