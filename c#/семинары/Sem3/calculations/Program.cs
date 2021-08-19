using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calculations
{
	class Program
	{
		static double F(double X)
		{
			return X * X;
		}
		public static void Read(string Name, out int X)
		{
		
			{ 
				Console.Write($"Введите {Name}");
			} while (!int.TryParse(Console.ReadLine(), out X));//считывание входных данных

		}
		static void Main(string[] args)
		{

			Read("A ", out int A);
			Read("число шагов ", out int N);

			double Delta = A / N;
			double result = 0;

			for(double x = 0; x <= A; x += Delta)
			{
				result += (F(x) + F(x + Delta)) / 2 * Delta;
			}

			Console.WriteLine($"результат = {result}");
		
		}
	}
}
