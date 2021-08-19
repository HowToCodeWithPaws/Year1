using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task7
{
	class Program
	{
		public static Random rn = new Random();
		static void Main(string[] args)
		{
			// С помощью цикла do while с условием нажатия клавиши Enter
			// (проверка с помощью метода Console.ReadKey()) реализуется возможность
			// повторного решения задачи по желанию пользователя.
			do
			{
				LinearEquation[] eqs = new LinearEquation[rn.Next(3, 6)];

				for (int i = 0; i < eqs.Length; i++)
				{
					eqs[i] = new LinearEquation(rn.Next(-10, 11), rn.Next(-10, 11), rn.Next(-10, 11));
					Console.WriteLine("\n" + eqs[i].ToString());
				}

				double[] keyes = new double[eqs.Length];
				for (int i = 0; i < eqs.Length; i++)
				{
					keyes[i] = eqs[i].Root();
				}

				Array.Sort(keyes, eqs);
				Console.WriteLine("\nОтсортированный массив:");

				for (int i = 0; i < eqs.Length; i++)
				{
					Console.WriteLine("\n" + eqs[i].ToString());
				}

				Console.WriteLine("\nДля повторного решения нажмите Enter, для выхода нажмите любой другой символ");

			} while (Console.ReadKey().Key == ConsoleKey.Enter);
		}
	}
}
