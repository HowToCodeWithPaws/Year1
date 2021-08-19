using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1;

namespace SR
{
	class Program
	{
		public static int Read(string message, int minvalue = int.MinValue, int maxvalue = int.MaxValue)
		{
			int input;

			do
			{
				Console.WriteLine(message);
			} while (!int.TryParse(Console.ReadLine(), out input) || input < minvalue || input > maxvalue);

			return input;
		}
		static void Main(string[] args)
		{
		 // С помощью цикла do while с условием нажатия клавиши Enter
		 // (проверка с помощью метода Console.ReadKey()) реализуется возможность
		 // повторного решения задачи по желанию пользователя.
			do
			{

				int N = Read("Введите целое число от 1 до 5 включительно.", 1, 5);

				Class1.FuncDelegate Anonimous = delegate (double x) { return Math.Cos(x * N); };

				Class1.PrintFunction(0, 2 * Math.PI, Math.PI / 8, Anonimous);

				Console.WriteLine("\nДля повторного решения нажмите Enter, для выхода нажмите любой другой символ");

			} while (Console.ReadKey().Key == ConsoleKey.Enter);
			
		}
	}
}
