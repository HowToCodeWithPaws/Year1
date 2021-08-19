using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polygon
{

	class Program
	{
		static void Main(string[] args)
		{
			do
			{
				int input;
				do
				{
					Console.WriteLine("Введите число многоугольников в массиве: ");
				} while (!int.TryParse(Console.ReadLine(), out input));

				Polygon[] arrayOfPols = new Polygon[input];

				arrayOfPols[0] = new Polygon();
				Console.WriteLine("\nПо умолчанию создан многоугольник: ");
				Console.WriteLine(arrayOfPols[0].PolygonData());


				for (int i = 1; i < input; i++)
				{
					arrayOfPols[i] = new Polygon();
					double rad;
					int number;

					Console.WriteLine("\nСоздается новый многоугольник:");
					do Console.Write("Введите число сторон: ");
					while (!int.TryParse(Console.ReadLine(), out number) | number < 3);
					do Console.Write("Введите радиус: ");
					while (!double.TryParse(Console.ReadLine(), out rad) | rad < 0);
					arrayOfPols[i] = new Polygon(number, rad);
					
				}

				double[] arrayArea = new double[input];
				for (int i = 0; i < input; i++)
				{
					arrayArea[i] = arrayOfPols[i].Area;
				}

				double minArea = double.MaxValue;
				int minRem = 0;
				double maxArea = double.MinValue;
				int maxRem = 0;

				for (int i = 0; i < input; i++)
				{
					if (arrayArea[i]<minArea)
					{
						minArea = arrayArea[i];
						minRem = i;
					}

					if (arrayArea[i] > maxArea)
					{
						maxArea = arrayArea[i];
						maxRem = i;
					}
				}

				for (int i = 0; i < input; i++)
				{
					Console.WriteLine("\nСведения о многоугольнике:");
					Console.WriteLine(arrayOfPols[i].PolygonData());
					if (i==minRem)
					{
						Console.ForegroundColor = ConsoleColor.Green;
						Console.WriteLine($"Площадь многоугольника: {arrayOfPols[i].Area}");
						Console.ForegroundColor = ConsoleColor.White;
					}
					if (i==maxRem)
					{
						Console.ForegroundColor = ConsoleColor.Red;
						Console.WriteLine($"Площадь многоугольника: {arrayOfPols[i].Area}");
						Console.ForegroundColor = ConsoleColor.White;
					}
					if(i!=minRem&&i!=maxRem) { Console.WriteLine($"Площадь многоугольника: {arrayOfPols[i].Area}"); }
					Console.WriteLine($"Периметр многоугольника: {arrayOfPols[i].Perimeter}");
				}

				Console.WriteLine("\nДля повторного решения нажмите Enter, для выхода нажмите любой другой символ");

			} while (Console.ReadKey().Key == ConsoleKey.Enter);
		}
	}
}
