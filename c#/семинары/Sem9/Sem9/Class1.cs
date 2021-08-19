using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sem9
{
	abstract class Shape
	{
		protected double side;
		public double Side { get; protected set; }

		protected Shape()
		{
			Console.WriteLine("shape w/out side");
		}

		public Shape(double side)
		{
			Console.WriteLine("Shape with side");
			this.side = side;
		}

		public abstract double GetSquare();
	}
}
