using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sem9
{
	class Triangle:Shape
	{
		public double Height { get; private set; }

		public Triangle(double baseside, double height) :base(baseside)
		{
			Console.WriteLine("Triangle");
			Height = height;
		}

		public override double GetSquare()
		{
			return 0.5 * Height * Side;
		}

	}
}
