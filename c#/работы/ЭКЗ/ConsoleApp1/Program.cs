using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using BookstoreLibrary;

/// <summary>
/// Зубарева Наталия
/// БПИ199
/// 17.06.2020
/// </summary>

/// Консольное приложение первой части, здесь 
/// создается и сериализуется коллекция.
namespace ConsoleApp1
{
	class Program
	{
		static Random random = new Random();


		/// <summary>
		/// Метод, генерирующий случайное вещественное число в требуемом
		/// интервале (левая граница включается) с использованием
		/// экземпляра класса Random.
		/// </summary>
		/// <param name="minvalue"> Параметр левой границы интервала. </param>
		/// <param name="maxvalue"> Параметр правой границы интервала. </param>
		/// <returns> Возвращает сгенерированное число. </returns>
		public static double RandomDouble(double minvalue, double maxvalue)
		{
			return minvalue + random.NextDouble() * (maxvalue - minvalue);
		}

		/// <summary>
		/// Метод, добавляющий к коллекции требуемое количество новых книг,
		/// книги создаются со случайными параметрами,
		/// генерация в цикле, чтобы при возникновении исключения повторять создание.
		/// Альтернативно можно было бы в случае исключения рекурсивно вызывать этот 
		/// метод, но мне так не нравится.
		/// </summary>
		/// <param name="books"> Коллекция книг. </param>
		/// <param name="numberOfBooks"> Количество добавляемых книг. </param>
		static void GenerateBooks(Bookstore<Product> books, int numberOfBooks)
		{
			for (int i = 0; i < numberOfBooks; i++)
			{
				/// Создание параметров книги случайным образом.
				double price = RandomDouble(0, 20);

				short pages = (short)random.Next(0, 701);

				short year = (short)random.Next(1980, 2030);

				int length = random.Next(3, 16);

				double rating = RandomDouble(-2, 7);

				/// Альтернативно имя можно было создавать регуляркой, но нет.
				string alphabet = " ABCDEFGHIJKLMNOQRSTUVWXYZabcdefghijklmnoqrstuvwxyz";

				string title = "";

				for (int j = 0; j < length; j++)
				{
					title += alphabet[random.Next(0, alphabet.Length)];
				}

				try
				{
					/// Попытка добавления книги в коллекцию.
					books.Add(new Book(title, price, pages, year, rating));
				}
				catch (BookstoreException e)
				{
					Console.WriteLine(e.Message);
					i--;
				}
			}
		}


		/// <summary>
		/// Метод выводит сообщение с переданной информацией и осуществляет
		/// считывание переменной типа int с использованием метода 
		/// TryParse в цикле do while до тех пор, пока пользователь не введет
		/// данные, для которых осуществится парсинг, также метод принимает
		/// на вход границы значений считываемого числа, соответствие которым
		/// также проверяется внутри условия do while, дефолтно они задаются
		/// как int Min и MaxValue.
		/// </summary>
		/// <param name="message"> Входной параметр выводимого сообщения. </param>
		/// <param name="minvalue"> Входной параметр нижней границы значения 
		/// числа. </param>
		/// <param name="maxvalue"> Входной параметр верхней границы значения
		/// числа. </param>
		/// <returns>Метод возвращает считанные данные, приведенные к требуемому 
		/// типу.</returns>
		public static int Read(string message, int minvalue = int.MinValue,
			int maxvalue = int.MaxValue)
		{
			int input;

			do
			{
				Console.Write(message);
			} while (!int.TryParse(Console.ReadLine(), out input)
		   || input < minvalue || input > maxvalue);

			return input;
		}


		/// <summary>
		/// Метод для сериализации json через System.Runtime.Serialization.Json,
		/// можно было делать другими способами, но через контракты удобнее 
		/// всего.
		/// Альтернативно использование сторонних библиотек в частности Newtonsoft.Json.
		/// Здесь с помощью потоков сериализуется и записывается в файл переданный
		/// в параметрах объект.
		/// </summary>
		public static void Serialize(Bookstore<Product> books)
		{
			/// Блок try catch для обработки исключений, которые
			/// могут возникнуть при работе с файлами.
			try
			{
				/// Реализация записи с использованием файловых потоков.
				/// Альтернативно можно было руками создавать новый поток и
				/// осуществлять Flush и Dispose, но так удобнее.
				using (FileStream fs = new FileStream("books.json", FileMode.Create, FileAccess.Write))
				{
					DataContractJsonSerializer s = new DataContractJsonSerializer(typeof(Bookstore<Product>));
					s.WriteObject(fs, books);

					Console.WriteLine("\nСериализация завершена");
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
			catch (Exception ex)
			{
				Console.WriteLine("При работе с файлом произошла ошибка. " +
					"Исправьте ошибку и попробуйте снова.\n" + ex.Message);
			}
		}


		static void Main(string[] args)
		{
			/// С помощью цикла do while с условием нажатия клавиши Enter
			/// (проверка с помощью метода Console.ReadKey()) реализуется возможность
			/// повторного решения задачи по желанию пользователя.
			do
			{
				try
				{               /// Создание новой коллекции.
					Bookstore<Product> books = new Bookstore<Product>();

					/// Считывание количества книг с консоли.
					int N = Read("Введите число книг в коллекции (целое число от 1 до 500): ", 1, 500);

					/// Вызов метода создания коллекции книг.
					GenerateBooks(books, N);

					/// Добавление одного объекта типа Product.
					books.Add(new Product("Товар1", 1));

					Console.WriteLine("\nСписок товаров создан:");

					/// Вывод книг на экран.
					foreach (Product item in books)
					{
						Console.WriteLine(item);
					}

					/// Вызов метода сериализации.
					Serialize(books);
				}
				catch (Exception e) { Console.WriteLine("При работе программы произошла ошибка." +
					" Попробуйте снова " + e.Message); }


				Console.WriteLine("\nНажмите Enter, чтобы повторить решение," +
					" для выхода нажмие любую другую клавишу.");

			} while (Console.ReadKey().Key == ConsoleKey.Enter);


		}
	}
}
