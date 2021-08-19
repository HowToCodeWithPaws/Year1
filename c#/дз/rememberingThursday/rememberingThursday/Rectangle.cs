using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rememberingThursday
{
	public class Rectangle : IComparable<Rectangle>
	{
		uint length, width;

		public Rectangle(uint a, uint b)
		{
			length = a;
			width = b;
		}

		public uint Square { get { return width * length; } }

		public int CompareTo(Rectangle other)
		{
			return Square.CompareTo(other.Square);
		}

		public override string ToString()
		{
			return $"{length} {width} {Square}";
		}
	}
}
