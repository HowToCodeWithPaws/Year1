using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5
{
	class Program
	{
		static public Random rand = new Random();
		static void Main(string[] args)
		{

			// С помощью цикла do while с условием нажатия клавиши Enter
			// (проверка с помощью метода Console.ReadKey()) реализуется возможность
			// повторного решения задачи по желанию пользователя.
			do
			{
				Book[] array = new Book[rand.Next(10, 21)];
				for (int i = 0; i < array.Length; i++)
				{
					array[i] = new Book($"Book{i}", rand.Next(1, 501), rand.Next(5, 11));
				}

				Library lib = new Library(array);

				Console.WriteLine(lib.ToString());

				Console.WriteLine(lib.GetBooksWithLessAmountOfPages(200));

				Book book = new Book("NewBook", 100, 100);

				lib.AddBook(book);

				Console.WriteLine(lib.ToString());

				Console.WriteLine("\nДля повторного решения нажмите Enter, для выхода нажмите любой другой символ");

			} while (Console.ReadKey().Key == ConsoleKey.Enter);

		}
	}
}
