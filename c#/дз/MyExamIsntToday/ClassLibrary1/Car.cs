using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
	public abstract class Car
	{
		protected int x=1;
		protected string name;
		//public bool winner = false;

		//public bool Winner
		//{
		//	get { return winner; }
		//	set { winner = value; }
		//}

		public int X
		{
			get { return x; }
			set
			{
				if (value >= 1)
				{
					x = value;
				}
			}
		}

		public string Name
		{
			get { return name; }
		}

		public abstract char Symbol { get; }

		public abstract void Step();

		public string PrintOnMap(int width)
		{
			string here = "";

			if (X <= width)
			{
				here += new string('-', X - 1);
				here += Symbol;
				here += new string('-', width - X);
			}
			if (X>width)
			{
				here += new string('-', width - 1)+Symbol;
			}

			Console.WriteLine($"{Name}: [{here}]");
			return $"\n{Name}: [{here}]";
		}
	}
}
