using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1;

namespace SR2
{
	class Program
	{
		public static Class2.StringProcDelegate First = str => Console.Write($"Длина строки: {str.Length} ");
		public static Class2.StringProcDelegate Second = Class2.ReportWordsCount;
		public static Class2.StringProcDelegate Multi = First + Second;

		static void Main(string[] args)
		{

			// С помощью цикла do while с условием нажатия клавиши Enter
			// (проверка с помощью метода Console.ReadKey()) реализуется возможность
			// повторного решения задачи по желанию пользователя.
			do
			{
				Console.WriteLine("Введите строку: ");
				Multi(Console.ReadLine());

				Console.WriteLine("\nДля повторного решения нажмите Enter, для выхода нажмите любой другой символ");

			} while (Console.ReadKey().Key == ConsoleKey.Enter);

		}
	}
}
