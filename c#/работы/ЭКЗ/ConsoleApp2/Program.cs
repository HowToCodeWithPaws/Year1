using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using BookstoreLibrary;

/// <summary>
/// Второе консольное приложение, в котором происходит десериализация
/// и линк запросы.
/// </summary>
namespace ConsoleApp2
{
	class Program
	{
		/// <summary>
		/// Метод для десериализации, возвращает объект
		/// требуемого типа, используется сериализация System.Runtime.Serialization.Json.
		/// </summary>
		/// <returns></returns>
		public static Bookstore<Product> Deserialize()
		{
			/// Блок try catch для обработки исключений, которые
			/// могут возникнуть при работе с файлами.

			Bookstore<Product> books = null;

			try
			{

				/// Реализация чтения с использованием файловых потоков.
				/// Альтернативно можно было руками создавать новый поток и
				/// осуществлять Flush и Dispose, но так удобнее.
				using (FileStream fs = new FileStream("../../../ConsoleApp1/bin/Debug/books.json",
					FileMode.Open, FileAccess.Read))
				{
					DataContractJsonSerializer s = new DataContractJsonSerializer(typeof(Bookstore<Product>));
					books = (Bookstore<Product>)s.ReadObject(fs);

					Console.WriteLine("\nДесериализация завершена.\n");
				}

				foreach (var book in books)
				{
					Console.WriteLine(book.ToString());
				}
			}
			catch (FileNotFoundException)
			{
				Console.WriteLine("Файл не существует. Исправьте ошибку и попробуйте снова.");
			}
			catch (IOException)
			{
				Console.WriteLine("Ошибка ввода-вывода. Исправьте ошибку и попробуйте снова.");
			}
			catch (System.Security.SecurityException)
			{
				Console.WriteLine("Ошибка безопасности при работе с файлом. " +
					"Исправьте ошибку и попробуйте снова.");
			}
			catch (UnauthorizedAccessException)
			{
				Console.WriteLine("У вас нет разрешения на чтение файла. " +
					"Исправьте ошибку и попробуйте снова.");
			}
			catch (BookstoreException ex)
			{
				Console.WriteLine("Неверные параметры объекта.\n" + ex.Message);
			}
			catch (Exception ex)
			{
				Console.WriteLine("При работе с файлом произошла ошибка. " +
					"Исправьте ошибку и попробуйте снова.\n" + ex.Message);
			}

			return books;
		}

		/// <summary>
		/// Первый линк запрос выводит книги , в которых короткая информация >14
		/// в порядке убывания стоимости.
		/// </summary>
		/// <param name="books"></param>
		static void Linq1(Bookstore<Product> books)
		{
			var newCollection = from book in books
								where book is Book && (book as Book).GetShortInfo().Length > 14
								orderby (double)book descending
								select book;

			Console.WriteLine("\nКниги с длиной краткой информации > 14 в порядке убывания стоимости:\n");

			foreach (var item in newCollection)
			{
				Console.WriteLine(item);
			}
		}

		/// <summary>
		/// Второй линк группирует книги по целой части рейтинга, 
		/// сортирует по ней и потом по цене, выводит группы.
		/// </summary>
		/// <param name="books"></param>
		static void Linq2(Bookstore<Product> books)
		{
			var groups = (from book in books
						  where book is Book
						  select book as Book).GroupBy(x => 
						  Math.Floor( x.Rating)).OrderBy(x => x.Key);

			Console.WriteLine("\nГруппы книг по целой части рейтинга:\n");

			foreach (var group in groups)
			{
				Console.WriteLine($"\nRating = { group.Key}");

				var groupSorted = group.OrderBy(b => (double)b);

				foreach (var book in groupSorted)
				{
					Console.WriteLine(book.ToString());
				}
			}
		}

		/// <summary>
		/// Третий линк запрос выбирает книги у которых максимальный
		/// год издания и выводит их и их количество.
		/// </summary>
		/// <param name="books"></param>
		static void Linq3(Bookstore<Product> books)
		{
			var maxYear = books.Where(b => (b is Book)).Max(b => (b as Book).Year);
			var newCollection = from book in books
								where book is Book && (book as Book).Year == maxYear
								select book;

			Console.WriteLine($"\nКниги с максимальным годом издания," +
				$" их количество = {newCollection.Count()}:\n");

			foreach (var item in newCollection)
			{
				Console.WriteLine(item);
			}
		}

		/// <summary>
		/// Точка входа и начало работы программы.
		/// </summary>
		/// <param name="args"></param>
		static void Main(string[] args)
		{
			/// С помощью цикла do while с условием нажатия клавиши Enter
			/// (проверка с помощью метода Console.ReadKey()) реализуется возможность
			/// повторного решения задачи по желанию пользователя.
			do
			{
				try
				{
					/// Десериализуем коллекцию и вызываем линк запросы.
					Bookstore<Product> books = Deserialize();

					Linq1(books);
					Linq2(books);
					Linq3(books);
				}
				catch (Exception e)
				{
					Console.WriteLine("При работе программы произошла ошибка. Попробуйте снова " + e.Message);
				}

				Console.WriteLine("\nНажмите Enter, чтобы повторить решение," +
					" для выхода нажмие любую другую клавишу.");

			} while (Console.ReadKey().Key == ConsoleKey.Enter);
		}
	}
}
