using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using EKRLib;

namespace ConsoleApp1
{
	class Program
	{
		static Random random = new Random();

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


		static void CreateDBs(int number, Server server)
		{
			for (int i = 0; i < number; i++)
			{
				int numberOfTables = random.Next(0, 151);

				int namelength = random.Next(2, 11);
				string name = "";

				for (int j = 0; j < namelength; j++)
				{
					char newletter = (char)random.Next('a', 'z' + 1);

					if (random.Next(0, 2) % 2 == 0)
					{
						name += newletter.ToString().ToUpper();
					}
					else { name += newletter; }
				}

				try
				{
					server.Add(new DB(name, numberOfTables));
				}
				catch (MyDBException e)
				{
					Console.WriteLine(e.Message);
					i--;
				}
			}
		}

		static void Serialize(Server server)
		{

			/// Блок try catch для обработки исключений, которые
			/// могут возникнуть при работе с файлами.
			try
			{
				using (FileStream fs = new FileStream("myServer.xml", FileMode.Create, FileAccess.Write))
				{
					DataContractSerializer serializer = new DataContractSerializer(typeof(Server));
					serializer.WriteObject(fs, server);
					Console.WriteLine("Сериализация закончена");
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
				int N = Read("Введите количество баз данных на сервере (целое число от 1 до 100): ", 1, 100);

				Server server = new Server();

				CreateDBs(N, server);

				Console.WriteLine($"\nСервер {server.ToString()}");

				Console.WriteLine("\nВот таблицы: ");

				foreach (DB db in server)
				{
					Console.WriteLine(db.ToString());
				}

				Serialize(server);

				Console.WriteLine("\nНажмите Enter, чтобы повторить решение," +
					"для выхода нажмие любую другую клавишу.");

			} while (Console.ReadKey().Key == ConsoleKey.Enter);


		}
	}
}
