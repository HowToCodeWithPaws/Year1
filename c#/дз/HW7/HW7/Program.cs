using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW7
{
	class Program
	{
		static void Main()
		{
			Point a, b, c;
			a = new Point(3, 4);
			Console.WriteLine(a.PointData);
			b = new Point(0, 3);
			Console.WriteLine(b.PointData);
			c = new Point();
			double x = 0, y = 0;

			List<Point> points = new List<Point>(0);
			points.Add(a);
			points.Add(b);

			do
			{
				Console.Write("x = ");
				double.TryParse(Console.ReadLine(), out x);
				Console.Write("y = ");
				double.TryParse(Console.ReadLine(), out y);
				
				points.Add(new Point(x, y));

				// #TODO3: следующий слайд
			} while (x != 0 | y != 0);

			List<double> key = new List<double>(points.Count);
			for (int i = 0; i < points.Count; i++)
			{
				key.Add(points[i].Ro) ;
			}
			IEnumerable<Point> pointz = points.OrderBy(point => point.Ro);

			foreach (Point point in pointz)
			{
				if (point.X!=0 || point.Y!=0)
				{
					Console.WriteLine($"\nТочка\n{point.PointData}");
				}
			}
		}

	}
}
