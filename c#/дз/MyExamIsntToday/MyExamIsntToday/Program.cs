using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1;
using static ClassLibrary1.Utilities;
using System.IO;

namespace MyExamIsntToday
{
	class Program
	{
		public static void WriteFile(string info)
		{
			try
			{
				File.WriteAllText("../../../racing.txt", info);
			}
			catch (System.Security.SecurityException e)
			{
				Console.WriteLine("Произошло исключение в безопасности, " +
					"попробуйте перезапустить программу"+Environment.NewLine+e);
			}
			catch (UnauthorizedAccessException e)
			{
				Console.WriteLine("Произошло исключение неавторизованного доступа к файлу, " +
					"попробуйте перезапустить программу" + Environment.NewLine + e);
			}
			catch (IOException e)
			{
				Console.WriteLine("Произошло исключение в работе с файлом, " +
					"попробуйте перезапустить программу" + Environment.NewLine + e);
			}
		}

		public static string CreateName()
		{
			string name = ((char)random.Next('A', 'Z' + 1)).ToString();

			for (int i = 0; i < 5; i++)
			{
				name += ((char)random.Next('a', 'z' + 1)).ToString();
			}

			return name;
		}

		static void Main(string[] args)
		{
			do
			{
				int width = random.Next(10, 31);
				string info = "";
				bool finished = false;

				Car[] cars = new Car[5];

				for (int i = 0; i < cars.Length; i++)
				{
					if (random.Next(0, 2) % 2 == 0)
					{
						cars[i] = new SlowCar(CreateName());
					}
					else { cars[i] = new SpeedCar(CreateName()); }
				}

				foreach (Car car in cars)
				{
					info += car.PrintOnMap(width);
				}

				while (!finished)
				{
					do { Console.WriteLine("\nПожалуйста нажмите пробел"); }
					while (Console.ReadKey().Key != ConsoleKey.Spacebar);

					info += $"\n\nПожалуйста нажмите пробел\n";
					Console.WriteLine();


					foreach (Car car in cars)
					{
						car.Step();
						info += car.PrintOnMap(width);

						if (car.X >= width)
						{
							finished = true;
						}
					}
				}


				foreach (Car car in cars)
				{
					if (car.X >= width)
					{
						Console.WriteLine($"\nПобедила машина {car.Name}");
						info += $"\nПобедила машина {car.Name}";
					}
				}

				WriteFile(info);

				Console.WriteLine("\nЕсли хотите повторить решение, " +
					"нажмите Enter, иначе нажмите любую другую клавишу");
			} while (Console.ReadKey().Key == ConsoleKey.Enter);
		}
	}
}
