using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using EKRLib;
using System.Runtime.Serialization;

namespace ConsoleApp2
{
	class Program
	{
		static Server Deserialize()
		{

			/// Блок try catch для обработки исключений, которые
			/// могут возникнуть при работе с файлами.
			try
			{
				using (FileStream fs = new FileStream("../../../ConsoleApp1/bin/Debug/myServer.xml", FileMode.Open, FileAccess.Read))
				{
					DataContractSerializer serializer = new DataContractSerializer(typeof(Server));
					Server server = serializer.ReadObject(fs) as Server;
					Console.WriteLine("Десериализация закончена");

					return server;
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

			return null;
		}

		public static void FirstLinq(Server server)
		{
			var tablesmorethan50 = from db in server
								   where db.TablesCount > 50
								   orderby db.TablesCount
								   select db;

			Console.WriteLine("\nБазы данных с числом таблиц > 50:");

			foreach (DB item in tablesmorethan50)
			{
				Console.WriteLine(item.ToString());
			}
		}

		public static void SecondLinq(Server server)
		{
			var namesmmm = from db in server
						   where db.Name.CompareTo("mmm") > 0
						   orderby db.Name descending, db.TablesCount descending
						   select db;

			Console.WriteLine("\nБазы данных с именем > mmm:");

			foreach (DB item in namesmmm)
			{
				Console.WriteLine(item.ToString());
			}
		}

		public static void ThirdLinq(Server server) {
			var tablesmorethan40and = from db in server
								   where db.TablesCount > 40 && db.Name.Length>5
								   orderby db.TablesCount descending
								   select db;
			Console.WriteLine("\nБазы данных с числом таблиц > 40 и длиной имени >5:");

			foreach (DB item in tablesmorethan40and)
			{
				Console.WriteLine(item.ToString());
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
				{
					Server server = Deserialize();

					Console.WriteLine($"Сервер {server.ToString()}");

					foreach (DB item in server)
					{
						Console.WriteLine(item.ToString());
					}

					Console.WriteLine($"\nMost complex db: {server.GetMostComplexDB().ToString()}");

					FirstLinq(server);
					SecondLinq(server);
					ThirdLinq(server);
				}
				catch (Exception e)
				{
					Console.WriteLine("Произошла ошибка работы: " + e.Message);
				}

				Console.WriteLine("\nНажмите Enter, чтобы повторить решение," +
					"для выхода нажмие любую другую клавишу.");

			} while (Console.ReadKey().Key == ConsoleKey.Enter);


		}
	}
}
