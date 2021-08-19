using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MessageLib;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Json;// json runtime

/// <summary>
/// Контрольная работа 4
/// Зубарева Наталия Дмитриевна
/// БПИ 199
/// 06.06.2020
/// </summary>

namespace ConsoleApp1
{
	/// <summary>
	/// Консольное приложение для создания и сериализации коллекции.
	/// </summary>
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


		/// <summary>
		/// Метод для создания текста.
		/// </summary>
		/// <param name="length"></param>
		/// <returns></returns>
		static string CreateContent(int length)
		{
			string symbols = "AQBRCSDTEUFVGWHXIYJZKLMNOaqbrcsdteufvgwhxiyjzklmno 0123456789";

			StringBuilder content = new StringBuilder();

			for (int i = 0; i < length - 1; i++)
			{
				content.Append(symbols[random.Next(0, symbols.Length)]);
			}
			return content.ToString();
		}

		/// <summary>
		/// Метод для создания сообщений.
		/// </summary>
		/// <param name="n"></param>
		/// <param name="messages"></param>
		public static void CreateMessages(int n, MessageBox messages)
		{
			for (int i = 0; i < n; i++)
			{
				try
				{
					messages.ReceiveMail(new Message(CreateContent(random.Next(5, 101)), DateTime.Now));
				}
				catch (MessageException e)
				{
					Console.WriteLine(e.Message);
					i--;
				}
			}
		}

		/// <summary>
		/// Метод для создания сообщений в прошлое.
		/// </summary>
		/// <param name="n"></param>
		/// <param name="messages"></param>
		public static void CreateDMessages(int n, MessageBox messages)
		{
			for (int i = 0; i < n / 2; i++)
			{
				try
				{
					messages.ReceiveMail(new Dmessage(CreateContent(random.Next(5, 37)), DateTime.Now, random.Next(1, 1001)));
				}
				catch (MessageException e)
				{
					Console.WriteLine(e.Message);
					i--;
				}
			}
		}

		/// <summary>
		/// Метод для сериализации.
		/// </summary>
		/// <param name="messages"></param>
		public static void Serialize(MessageBox messages)
		{
			/// Блок try catch для обработки исключений, которые
			/// могут возникнуть при работе с файлами.
			try
			{
				/// Реализация записи с использованием файловых потоков.
				/// Альтернативно можно было руками создавать новый поток и
				/// осуществлять Flush и Dispose, но так удобнее.

				//json
				//using (FileStream fs = new FileStream("messageBox.json", FileMode.Create, FileAccess.Write))
				//{
				//	DataContractJsonSerializer s = new DataContractJsonSerializer(typeof(MessageBox));// json runtime
				//	s.WriteObject(fs, messages);

				//	Console.WriteLine("\nСериализация (отправка в прошлое) завершена");
				//}

				//xml
				using (FileStream fs = new FileStream("messageBox.xml", FileMode.Create, FileAccess.Write))
				{
					DataContractSerializer s = new DataContractSerializer(typeof(MessageBox));// json runtime
					s.WriteObject(fs, messages);

					Console.WriteLine("\nСериализация (отправка в прошлое) завершена");
				}

				//bin
				//using (FileStream fs = new FileStream("messageBox.bin", FileMode.Create, FileAccess.Write))
				//{
				//	BinaryFormatter formatter = new BinaryFormatter();
				//	formatter.Serialize(fs, messages);

				//	Console.WriteLine("\nСериализация (отправка в прошлое) завершена");
				//}
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
				/// Создание коллекции и вызов методов.
				int n = Read("Пожалуйста введите число обычных сообщений," +
					" целое число от 10 до 1000: ", 10, 1000);

				MessageBox messages = new MessageBox();

				CreateMessages(n, messages);

				CreateDMessages(n, messages);

				Console.WriteLine("Сообщения сгенерированы:\n");

				foreach (var message in messages)
				{
					Console.WriteLine(message.ToString());
				}

			Serialize(messages);


				Console.WriteLine("\nНажмите Enter, чтобы повторить решение," +
					"для выхода нажмие любую другую клавишу.");

			} while (Console.ReadKey().Key == ConsoleKey.Enter);
		}
	}
}
