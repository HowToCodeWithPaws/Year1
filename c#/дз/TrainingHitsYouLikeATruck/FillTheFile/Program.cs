using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static ClassLibrary1.Utilities;

namespace FillTheFile
{
	class Program
	{
		static void Main(string[] args)
		{

			// С помощью цикла do while с условием нажатия клавиши Enter
			// (проверка с помощью метода Console.ReadKey()) реализуется возможность
			// повторного решения задачи по желанию пользователя.
			do
			{
				byte[] text = new byte[1000];

				for (int i = 0; i < 1000; i++)
				{
					text[i] = (byte)random.Next(0, 128);
				}

				/// Блок try catch обрабатывает возможные исключения, возникающие при работе с файлами.
				try
				{
					File.WriteAllText("../../../data.txt", string.Join(" ", text));
				}
				catch (IOException)
				{
					Console.WriteLine("Ошибка ввода/вывода");
				}
				catch (UnauthorizedAccessException)
				{
					Console.WriteLine("Ошибка доступа: у вас нет разрешения на создание файла");
				}
				catch (System.Security.SecurityException)
				{
					Console.WriteLine("Ошибка безопасности");
				}
				finally
				{
					Console.WriteLine("Мы закончили работу с файлом");
				}

				

				Console.WriteLine("\nДля повторной записи в файл нажмите Enter, для выхода " +
					"нажмите любой другой символ. После этого проекта запустите второй проект в решении");

			} while (Console.ReadKey().Key == ConsoleKey.Enter);
			
		}
	}
}
