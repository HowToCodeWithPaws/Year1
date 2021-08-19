using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6
{
	class Program
	{
		public static Random rnd = new Random();
		static void Main(string[] args)
		{
		 // С помощью цикла do while с условием нажатия клавиши Enter
		 // (проверка с помощью метода Console.ReadKey()) реализуется возможность
		 // повторного решения задачи по желанию пользователя.
			do
			{
				//Point point1 = new Point(1,1);
				//Point point2 = new Point(3,0);
				//Point point3 = new Point(3, 3);

				//Console.WriteLine($"First {point1.ToString()}\nDistance to (0;0) is {point1.GetDistance(new Point())}");
				//Console.WriteLine($"Second {point2.ToString()}\nDistance to (0;0) is {point2.GetDistance(new Point())}");
				//Console.WriteLine($"Third {point3.ToString()}\nDistance to (0;0) is {point3.GetDistance(new Point())}");
				//Console.WriteLine($"Distance between {point2.ToString()} and {point3.ToString()} is {point2.GetDistance(point3)}");

				Point[] points = new Point[rnd.Next(5,16)];
				for (int i = 0; i < points.Length; i++)
				{
					points[i] = new Point(rnd.NextDouble() + rnd.Next(-10, 9), rnd.NextDouble() + rnd.Next(-10, 9));
					Console.WriteLine($"\n{i} {points[i].ToString()}\nDistance to (0;0) is {points[i].GetDistance(new Point())}");
				}

				double max = double.MinValue;
				int rem=0;
				for (int i = 0; i < points.Length; i++)
				{
					if (points[i].GetDistance(new Point())>max)
					{
						max = points[i].GetDistance(new Point());
						rem = i;
					}
				}

				Console.WriteLine($"\nThe furtherest point from (0,0) is {points[rem].ToString()},\nThe distance is {points[rem].GetDistance(new Point())}");
				Console.WriteLine("\nДля повторного решения нажмите Enter, для выхода нажмите любой другой символ");

			} while (Console.ReadKey().Key == ConsoleKey.Enter);
		}
	}
}
