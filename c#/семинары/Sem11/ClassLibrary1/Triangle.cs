using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
	public class Triangle:Dimensions
	{
		public Triangle(int baseSide, int height):base(height, baseSide)
		{}

		public override double Square {
			get { return Side * BaseSide/2; }
		}

	}
}
