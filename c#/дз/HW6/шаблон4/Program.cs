using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace шаблон3
{
	class Program
	{
		public static string Check(string[] matrix)
		{
			for (int i = 0; i < matrix.GetLength(0); i++)
			{
				for (int j = 0; j < matrix[i].Length; j++)
				{
					if (i!=j && (int)matrix[i][j]!=0)
					{
						return "Нет";
					}
				}
			}

			return "Да";
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
					string[] matrix = File.ReadAllLines("../../../../matrix.txt");
					for (int i = 0; i < matrix.Length; i++) 
					{
						for (int j = 0; j < matrix[i].Length; j++)
						{
							Console.Write(matrix[i][j]);
						}
						Console.WriteLine();
					}
					Console.WriteLine(Check(matrix));

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

				}


				Console.WriteLine("\nДля повторного решения нажмите Enter, для выхода нажмите любой другой символ");

			} while (Console.ReadKey().Key == ConsoleKey.Enter);
		}
	}
}
