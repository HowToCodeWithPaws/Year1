using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
	public class Child:Person
	{
		private string additionalPocket = string.Empty;

		public Child(string name_) : base(name_) { }

		public override bool IsPocketEmpty()
		{
			if (this.Pocket==string.Empty || additionalPocket == string.Empty)
			{
				return true;
			}
			return false;
		}

		public override void Receive(string present)
		{
			if (!IsPocketEmpty())
			{
				throw new ArgumentException();
			}
			else
			{
				if (Pocket==string.Empty)
				{
					Pocket = present;
				}
				else
				{
					additionalPocket = present;
				}
	
			}
		}
	}
}
