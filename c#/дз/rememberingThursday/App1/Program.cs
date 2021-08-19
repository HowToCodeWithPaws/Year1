using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using rememberingThursday;
using System.IO;

namespace App1
{
	class Program
	{
		static bool listExists;
		static bool last3;
		static RectangleList rectangleList;

		static void Main(string[] args)
		{
			// С помощью цикла do while с условием нажатия клавиши Enter
			// (проверка с помощью метода Console.ReadKey()) реализуется возможность
			// повторного решения задачи по желанию пользователя.
			do
			{
				listExists = false;
				last3 = false;

				try
				{
					Console.WriteLine("\nHey there. You have some options. " +
						"Print the number of the one you like\n" +
						"\n\nPlease notice: you obviously can only choose 2nd and 3rd" +
						" options once you've chosen the 1st one,\n also you can only" +
						" choose the 4th right after choosing the 3rd." +
						"\nChoose wisely and may the Force be with you");
					WriteMenu();
				}
				catch (MyException e)
				{
					Console.WriteLine(e.Message);
				}

				Console.WriteLine("\nДля повторного решения нажмите Enter, для выхода нажмите любой другой символ");

			} while (Console.ReadKey().Key == ConsoleKey.Enter);


		}

		public static void WriteMenu()
		{
			Console.WriteLine(
			"\n1. Создать объект RectangleList" +
			"\n2. Вывести на экран данные о прямоугольниках из " +
			"неупорядоченной коллекции RectangleList" +
			"\n3. Вывести на экран данные о прямоугольниках из " +
			"упорядоченной коллекции из RectangleList" +
			"\n4. Сохранить данные из упорядоченной коллекции в файл\n\n");

			try
			{
				ParseTheChoice();
			}
			catch (MyException)
			{
				throw;
			}
		}

		public static void ParseTheChoice()
		{
			string reading = Console.ReadLine();

			switch (reading)
			{
				case "1":
					try
					{
						rectangleList = new RectangleList();
						listExists = true;
						last3 = false;
						Console.WriteLine("\nlist generated\n");
						WriteMenu();
					}
					catch (MyException)
					{
						throw;
					}
					break;

				case "2":
					if (listExists)
					{
						try
						{
							Console.WriteLine(rectangleList.ToString());
							last3 = false;
							WriteMenu();
						}
						catch (Exception e)
						{
							Console.WriteLine("\nOOps something went wrong" + e.Message);
						}
					}
					else
					{
						Console.WriteLine("\nSadly you cannot do this yet. Create the list first\n");
						WriteMenu();
					}
					break;

				case "3":
					if (listExists)
					{
						try
						{
							Console.WriteLine(rectangleList.OrderedRectangles());
							last3 = true;
							WriteMenu();
						}
						catch (Exception e)
						{
							Console.WriteLine("\nOOps something went wrong" + e.Message);
						}
					}
					else
					{
						Console.WriteLine("\nSadly you cannot do this yet. Create the list first\n");
						WriteMenu();
					}
					break;

				case "4":
					if (last3)
					{
						try
						{
							using (StreamWriter writer = new StreamWriter("../../../Файл_2.txt"))
							{
								writer.Write(rectangleList.OrderedRectangles());
							}

							Console.WriteLine("\nData written to file!\n");
							last3 = false;
							WriteMenu();
						}
						catch (MyException)
						{
							throw;
						}
						catch (Exception e)
						{
							Console.WriteLine("\nOOps something went wrong" + e.Message);
						}
					}
					else
					{
						Console.WriteLine("\nSadly you cannot do this yet. Choose the 3rd first\n");
						WriteMenu();
					}
					break;

				default:
					Console.WriteLine("\nTry writing something sensible instead\n");
					last3 = false;
					WriteMenu();
					break;
			}
		}
	}
}
