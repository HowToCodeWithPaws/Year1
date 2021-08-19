using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sem9
{
	class Program
	{
		static void Main(string[] args)
		{
			Shape[] shapes = new Shape[] { new Triangle(1, 1), new Circle(1) };

			foreach (Shape shape1 in shapes)
			{
				Console.WriteLine(shape1.GetSquare());
			}

		

		}
	}
}
