using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
	public class SquareFig:Dimensions
	{
		public SquareFig(int side, int secondside):base(side, secondside) { }

		public override double Square
		{
			get
			{
				return Side * BaseSide;
			}
		}
	}
}
