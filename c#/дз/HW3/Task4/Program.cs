using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
	class Program
	{
		static public void Func(double X, double Y, ref double result)
		{

			result = (X < Y && X > 0) ? (X + Math.Sin(Y)) : ((X > Y && X < 0) ? (Y - Math.Cos(X)) : (0.5 * X * Y));
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
				double CoordX, CoordY, result = 0;

				CoordX = Read("X");
				CoordY = Read("Y");

				Func(CoordX, CoordY, ref result);

				Console.WriteLine($"{result}");
				Console.WriteLine("Для повторного решения нажмите Enter, для выхода нажмите любой другой символ");

			} while (Console.ReadKey().Key == ConsoleKey.Enter);
		}
	}
}
