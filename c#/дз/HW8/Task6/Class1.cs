using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6
{
	class Point
	{
		private double _xCoord;
		private double _yCoord;


		public double YCoord { get { return _yCoord; } set { _yCoord = value; } }
		public double XCoord { get { return _xCoord; } set { _xCoord = value; } }

		public Point():this(0,0) { }

		public override string ToString()
		{
			return $"Point({XCoord};{YCoord})";
		}

		public double GetDistance(Point point)
		{
			return Math.Sqrt((this.XCoord-point.XCoord)* (this.XCoord - point.XCoord) + (this.YCoord - point.YCoord) * (this.YCoord - point.YCoord));
		}

		public Point(double x, double y) {
			YCoord = y;
			XCoord = x;
		}
	}
}
