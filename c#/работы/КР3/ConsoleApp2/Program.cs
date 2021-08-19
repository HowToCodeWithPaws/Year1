using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MessageLib;
using System.IO;
using System.Runtime.Serialization.Json;// json runtime
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

/// <summary>
/// Контрольная работа 4
/// Зубарева Наталия Дмитриевна
/// БПИ 199
/// 06.06.2020
/// </summary>

namespace ConsoleApp2
{
	/// <summary>
	/// Консольное приложение для десериализации коллекции.
	/// </summary>
	class Program
	{
		/// <summary>
		/// Метод десериализации.
		/// </summary>
		/// <returns></returns>
		public static MessageBox Deserialize()
		{
			/// Блок try catch для обработки исключений, которые
			/// могут возникнуть при работе с файлами.

			MessageBox messages = null;
			try
			{

				/// Реализация чтения с использованием файловых потоков.
				/// Альтернативно можно было руками создавать новый поток и
				/// осуществлять Flush и Dispose, но так удобнее.


				///json
				//using (FileStream fs = new FileStream("../../../ConsoleApp1/bin/Debug/messageBox.json",
				//	FileMode.Open, FileAccess.Read))
				//{
				//	DataContractJsonSerializer s = new DataContractJsonSerializer(typeof(MessageBox));
				//	messages = (MessageBox)s.ReadObject(fs);// json runtime
				//	Console.WriteLine("\nДесериализация завершена.\n");
				//}

				//xml
				using (FileStream fs = new FileStream("../../../ConsoleApp1/bin/Debug/messageBox.xml",
				FileMode.Open, FileAccess.Read))
				{
					DataContractSerializer s = new DataContractSerializer(typeof(MessageBox));
					messages = (MessageBox)s.ReadObject(fs);
					Console.WriteLine("\nДесериализация завершена.\n");
				}

				//bin
				//using (FileStream fs = new FileStream("../../../ConsoleApp1/bin/Debug/messageBox.bin",
				//FileMode.Open, FileAccess.Read))
				//{
				//	BinaryFormatter formatter = new BinaryFormatter();
				//	messages = formatter.Deserialize(fs) as MessageBox;
				//	Console.WriteLine("\nДесериализация завершена.\n");
				//}

				foreach (var message in messages)
				{
					Console.WriteLine(message.ToString());
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
			catch (MessageException ex)
			{
				Console.WriteLine("Неверные параметры объекта.\n" + ex.Message);
			}
			catch (Exception ex)
			{
				Console.WriteLine("При работе с файлом произошла ошибка. " +
					"Исправьте ошибку и попробуйте снова.\n" + ex.Message);
			}

			return messages;
		}

		/// <summary>
		/// Метод запроса.
		/// </summary>
		/// <param name="messages"></param>
		public static void FirstLinq(MessageBox messages)
		{
			var min = messages.Where(m => !(m is Dmessage)).Min(m => m.ReceiveDate);
			Console.WriteLine(min);

			var newmessages = messages.Where(x => x.Content.Length > 20
			&& x is Dmessage && x.ReceiveDate < min);

			Console.WriteLine("\nСообщения длины больше 20," +
				" пришедшие раньше, чем первое обычное сообщение:");
			Console.WriteLine();

			foreach (var message in newmessages)
			{
				Console.WriteLine(message.ToString());
			}

		}

		/// <summary>
		/// Метод запроса.
		/// </summary>
		/// <param name="messages"></param>
		public static void SecondLinq(MessageBox messages)
		{
			Console.WriteLine("\nГруппы писем в прошлое по часам:\n");
			var groups = (from message in messages
						  where message is Dmessage
						  select message as Dmessage).GroupBy(x => x.Hours / 24).OrderBy(x => x.Key);

			foreach (var group in groups)
			{
				Console.WriteLine($"days { group.Key}");

				foreach (var message in group)
				{
					Console.WriteLine(message.ToString());
				}
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
					MessageBox messages = Deserialize();

					FirstLinq(messages);

					SecondLinq(messages);
				}
				catch (Exception ex)
				{
					Console.WriteLine("При произошла ошибка. " +
						"Исправьте ошибку и попробуйте снова.\n" + ex.Message);
				}

				Console.WriteLine("\nНажмите Enter, чтобы повторить решение," +
					"для выхода нажмие любую другую клавишу.");

			} while (Console.ReadKey().Key == ConsoleKey.Enter);
		}
	}
}
