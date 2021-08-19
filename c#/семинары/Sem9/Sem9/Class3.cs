using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sem9
{
	class Circle : Shape
	{
		public double Radius { get; private set; }

		public Circle(double radius) : base(radius) {
			Console.WriteLine("Circle");
		}

		public override double GetSquare()
		{
			return Math.PI* Radius*Radius;
		}
	}
}

