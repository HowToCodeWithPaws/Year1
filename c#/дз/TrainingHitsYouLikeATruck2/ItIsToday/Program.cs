using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1;
using System.IO;

namespace ItIsToday
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
				string readings="";
				bool proceed = true;

				/// Блок try catch обрабатывает возможные исключения, 
				/// возникающие при работе с файлами.
				try
				{
					readings = File.ReadAllText("../../../ForFiltering.txt");
				}
				catch (FileNotFoundException e)
				{
					Console.WriteLine("Файл, который вы пытаетесь открыть, не существует." +
						" Для его создания сначала запустите проект 1" + Environment.NewLine + e);
					proceed = false;
				}
				catch (IOException e)
				{
					Console.WriteLine("Ошибка ввода/вывода" + Environment.NewLine + e);
					proceed = false;
				}
				catch (UnauthorizedAccessException e)
				{
					Console.WriteLine("Ошибка доступа: " +
						"у вас нет разрешения на создание файла" + Environment.NewLine + e);
					proceed = false;
				}
				catch (System.Security.SecurityException e)
				{
					Console.WriteLine("Ошибка безопасности" + Environment.NewLine + e);
					proceed = false;
				}
				finally
				{
					Console.WriteLine("Чтение файла закончено");
				}

				if (proceed)
				{
					EmailFilter filter = new EmailFilter();
					TransformatorBase[] transformators = new TransformatorBase[2];

					transformators[0] = new EmailTrimTransformator();
					transformators[1] = new ToUpperTransformator();

					List<string> check = new List<string>();

					string[] split = readings.Split('\n');

					for (int i = 0; i < split.Length; i++)
					{
						try
						{
							if (filter.Filter(split[i]))
							{
								split[i]=transformators[0].Transform(split[i]);
								split[i] = transformators[1].Transform(split[i]);

								check.Add(split[i]);
							}
						}
						catch (ArgumentOutOfRangeException)
						{

							Console.WriteLine("найдена пустая строка");
						}
					}

					/// Блок try catch обрабатывает возможные исключения,
					/// возникающие при работе с файлами.
					try
					{
						File.WriteAllLines("ProcessedData.txt", check);
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
						Console.WriteLine("запись во второй файл закончена");
					}
				}

				Console.WriteLine("\nДля повторного решения нажмите Enter, " +
					"для выхода нажмите любой другой символ");

				throw new MyException();

			} while (Console.ReadKey().Key == ConsoleKey.Enter);

		}
	}
}
