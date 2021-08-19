using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sem21
{//Generics

	abstract class Point<T> : IComparable<Point<T>> where T : struct, IComparable<T>, IFormattable
	{
		public T X { get; }
		public T Y { get; }

		public Point(T x, T y) { X = x; Y = y; }

		protected abstract T SquaredDistance { get; }

		int IComparable<Point<T>>.CompareTo(Point<T> other)
		{
			return SquaredDistance.CompareTo(other.SquaredDistance);
		}

		public override string ToString()
		{
			return $"({X}; {Y})";
		}
	}

	class IntPoint : Point<int>
	{
		public IntPoint(int x, int y) : base(x, y) { }
		protected override int SquaredDistance => X * X + Y * Y;
	}

	class DoublePoint : Point<double>
	{
		public DoublePoint(double x, double y) : base(x, y) { }
		protected override double SquaredDistance => X * X + Y * Y;
	}

	class Program
	{
		static T Maximum<T>(T first, T second) where T : IComparable<T>
		{

			return first.CompareTo(second) > 0 ? first : second;
		}

		static void Main(string[] args)
		{
			Random random = new Random();
			Point<double>[] points = new Point<double>[10];

			for (int i = 0; i < points.Length; i++)
			{
				points[i] = new DoublePoint(random.Next(-10, 11) + random.NextDouble(),
					random.Next(-10, 11) + random.NextDouble());

			}

			Point<double> maximum = points[0];
			for (int i = 0; i < points.Length; i++)
			{
				maximum = Maximum(points[i], maximum);
			}

			Console.WriteLine(maximum);
		}
	}
}
