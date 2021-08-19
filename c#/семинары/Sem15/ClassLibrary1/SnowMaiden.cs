using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ClassLibrary1.Utilities;

namespace ClassLibrary1
{
	public class SnowMaiden : Person
	{
		public SnowMaiden(string name_): base(name_){ }

		public string[] CreatePresent(int amount)
		{
			char letter1;
			char letter2;
			char letter3;

			string[] presents = new string[amount];

			for (int i = 0; i < amount; i++)
			{
				letter1 = (char)random.Next('a', 'z'+1);
				letter2 = (char)random.Next('a', 'z' + 1);
				letter3 = (char)random.Next((int)'a', (int)'z' + 1);

				string present = letter1.ToString() +letter2.ToString()+
					letter3.ToString()+letter2.ToString()+letter1.ToString() ;

				presents[i] = present;
			}

			return presents;
		}

		public override void Receive(string present)
		{
			base.Receive(present);
		}

	}
}
