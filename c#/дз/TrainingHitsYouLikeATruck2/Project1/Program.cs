using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Project1
{
	class Program
	{
		public static Random random = new Random();

		public static string CreateLeftPart(int leftBorder, int rightBorder, int length)
		{
			string temp = "";

			for (int i = 0; i < length; i++)
			{
				temp += (char)random.Next(leftBorder, rightBorder + 1);
			}

			return temp;
		}

		public static string[] Generate()
		{
			string[] generated = new string[1000];

			for (int i = 0; i < 10; i++)
			{
				generated[i] = CreateLeftPart('0', '9', 10) + "@edu.hse.ru";
			}

			for (int i = 10; i < 30; i++)
			{
				generated[i] = CreateLeftPart('a', 'z', 3) + ".edu.hse.ru";
			}

			for (int i = 30; i < 1000; i++)
			{
				generated[i] = CreateLeftPart('a', 'z', 7) + "@edu.hse.ru";
			}

			return generated;
		}

		static void Main(string[] args)
		{

			// С помощью цикла do while с условием нажатия клавиши Enter
			// (проверка с помощью метода Console.ReadKey()) реализуется возможность
			// повторного решения задачи по желанию пользователя.
			do
			{

				/// Блок try catch обрабатывает возможные исключения, возникающие при работе с файлами.
				try
				{
					File.WriteAllLines("../../../ForFiltering.txt", Generate());
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
					Console.WriteLine("Запись файла закончена");
				}

				Console.WriteLine("\nДля повторной записи файла нажмите Enter, " +
					"для выхода нажмите любой другой символ. " +
	 "После запустите, пожалуйста, проект 2");

			} while (Console.ReadKey().Key == ConsoleKey.Enter);
		}
	}
}
