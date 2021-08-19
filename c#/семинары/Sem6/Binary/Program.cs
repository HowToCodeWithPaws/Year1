using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Binary
{
	class Program
	{
		static Random random = new Random();

		public static int Read()
		{
			int input;

			do
			{
				Console.WriteLine("Введите число элементов.");
			} while (!int.TryParse(Console.ReadLine(), out input) || input == 0);

			return input;
		}

		static void Main(string[] args)
		{

			string path;
			do
			{
				Console.WriteLine("Введите адрес файла");

				path = Console.ReadLine();
			} while (!new FileInfo(path).Exists);

			/// Блок try catch обрабатывает возможные исключения, возникающие при работе с файлами.
			try
			{

			}
			catch (IOException)
			{
				Console.WriteLine("Ошибка ввода/вывода");
			}
			catch (UnauthorizedAccessException)
			{
				Console.WriteLine("Ошибка доступа: у вас нет разрешения на создание файла");
			}
			catch(System.Security.SecurityException )
			{
				Console.WriteLine("Ошибка безопасности");
			}
			finally
			{

			}




			do
			{
				int number;

				number = Read();

				int[] array = new int[random.Next(number / 2 +1, 2*number +1)];

				for (int i = 0; i < array.Length; i++)
				{
					array[i] = random.Next(-number, number + 1);
				}

				try
				{
					File.WriteAllText("../../../intNum.txt",что_мы_хотим_написать);
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.Message);
				}
				catch()
				{

				}
				catch ()
				{

				}
				finally(){


				}

				Console.WriteLine("\nДля повторного решения нажмите Enter, для выхода нажмите любой другой символ");

			} while (Console.ReadKey().Key == ConsoleKey.Enter);
		}
	}
}

