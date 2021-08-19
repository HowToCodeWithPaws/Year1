using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;


namespace Lesson2
{
	static class Myclass
	{
		public static int x = 10;
		public static IEnumerable<int> Enum1()
		{
			for (int i = 0; i < x; i++)
			{
				yield return i;
				x++;
			}
		}
		public static IEnumerable<int> Enum2()
		{
			for (int i = 0; i < x; i++)
			{
				yield return i;
				x--;
			}
		}
		public static IEnumerable<int> Enum3()
		{
			for (int i = 0; i < x; i++)
			{
				yield return i;
				x-=2;
			}
		}
	}
	class Program
	{
		static double getSquare(double radius)
		{
			return Math.PI * Math.Pow(radius, 2);
		}
		static double getLength(double radius)
		{
			return Math.PI * 2 * radius;
		}
		static void getSquareandLength(double radius, out double square, out double length)
		{
			square = getSquare(radius);
			length = getLength(radius);
		}
		public static double ReadDouble()
		{
			double R;

			do
			{
				Console.Write("Введите радиус круга ");
			} while (!double.TryParse(Console.ReadLine(), out R));

			return R;

		}

		double SingleShot { get; set; }
		double HeadShot { get; set; }


		public static Random random = new Random();

		public static double Attack(int shot)
		{
			double damage = 0;

			for (int i = 0; i < 5; i++)
			{
				if (random.Next(10) < 7)
				{
					damage += 0.1 * shot;
				}
			}

			return damage;

		}

		public static double SmartAttack(int headshot, int shot)
		{
			double damage = 0;

			for (int i = 0; i < 3; i++)
			{
				if (random.Next(10) < 3)
				{
					if (random.Next(10) < 8)
					{
						damage += 0.4 * shot;
					}
					else
					{
						damage += headshot;
					}
				}
			}
			return damage;
		}

		static void Main()
		{
			//double R = ReadDouble();

			//R = R == 0 ? Double.Epsilon : R;

			//double S, C;
			//getSquareandLength(R, out S, out C);

			//Console.WriteLine("Длина окружности равна = {0}, площадь круга равна = {1}", C, S);



			// С помощью цикла do while с условием нажатия клавиши Enter
			// (проверка с помощью метода Console.ReadKey()) реализуется возможность
			// повторного решения задачи по желанию пользователя.
			do
			{
				IEnumerable<int> c = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };
				var items = c.TakeWhile((x, y) =>  y  == 0);
				foreach (var item in items)
				{
					Console.WriteLine(item);
				}
				//	for (int i = 0; i < 1000; i = i + 100)
				//	{
				//		for (int j = 0; j < 1000; j = j + 100)
				//		{
				//			double sd = SmartAttack(i, j);
				//			double d = Attack(j);
				//			Console.WriteLine($"headshot {i} shot {j} \nattack damage {d} \nsmart damage {sd} \nresult {d>sd}\n \n");
				//		}
				//	}

				//	Console.WriteLine("\nДля повторного решения нажмите Enter, для выхода нажмите любой другой символ");


				Console.WriteLine("all is good");

			} while (Console.ReadKey().Key == ConsoleKey.Enter);


		}

		static void writing()
		{
			for (int i = 0; i < 10; i++)
			{
				Console.WriteLine(i);
			}
		}

		static void counting()
		{
			for (int i = 90; i < 100; i++)
			{
				Console.WriteLine((char)i);
			}
		}

		//static async void Write() {
		//	await Task.Run(() => {

		//		writing();

		//	});

		//	await Task.Run(() => {


		//		counting();
		//	});
		//}
	}
}
