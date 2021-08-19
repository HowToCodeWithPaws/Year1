using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ClassLibrary1.Utilities;

namespace ClassLibrary1
{
	public class SlowCar :Car
	{
		public override char Symbol {
			get { return 'o'; }
		}

		public override void Step()
		{
			int shift = random.Next(0, 3);
			X += shift;
		}

		public SlowCar(string _name)
		{
			name = _name;
		}
	}
}
