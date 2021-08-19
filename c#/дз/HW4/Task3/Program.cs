using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Протабулировать функцию 𝑦 на заданном диапазоне, с заданным шагом изменения аргумента, значения 𝑎,𝑏,𝑐 вводит пользователь:
//𝑦={█(𝑎𝑥^2+𝑏𝑥+𝑐, 𝑥<1,2@𝑎⁄𝑥+√(𝑥^2+1),𝑥=1,2@((𝑎+𝑏𝑥))⁄√(𝑥^2+1),𝑥>1,2),𝑥∈[1;2],∆𝑥=0,05┤

namespace Task3
{
	class Program
	{

		static void Function(double cA, double cB, double cC)
		{
			double result;

			for (double x = 1; x <= 2.01; x += 0.05)
			{
				if (x < 1.2)
				{
					result = cA * x * x + cB * x + cC;
				}
				else
				{
					if (x > 1.2)
					{
						result = (cA + cB * x) / Math.Sqrt(x * x + 1);
					}
					else
					{
						result = cA / x + Math.Sqrt(x * x + 1);
					}
				}

				Console.WriteLine($"Функция при x = {x}: \t{result}");
			}
		}

		public static double Read(string name)
		{
			double In;

			do
			{
				Console.Write($"Введите коэффициент {name}  ");
			} while (!double.TryParse(Console.ReadLine(), out In));
			return In;
		}


		static void Main(string[] args)
		{
			do
			{
				double coeffA, coeffB, coeffC;

				coeffA = Read("A");
				coeffB = Read("B");
				coeffC = Read("C");

				Function(coeffA, coeffB, coeffC);

				Console.WriteLine("Для повторного решения нажмите Enter, для выхода нажмите любой другой символ");

			} while (Console.ReadKey().Key == ConsoleKey.Enter);
		}

	}
}
