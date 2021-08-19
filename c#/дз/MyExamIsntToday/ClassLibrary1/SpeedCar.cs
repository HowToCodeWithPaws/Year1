using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ClassLibrary1.Utilities;

namespace ClassLibrary1
{
	public class SpeedCar : Car
	{
		public override char Symbol
		{
			get { return '>'; }
		}

		public override void Step()
		{
			int shift = random.Next(3, 6);
			X += shift;
		}

		public SpeedCar(string _name)
		{
			name = _name;
		}
	}
}
