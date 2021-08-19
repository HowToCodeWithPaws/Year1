using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ClassLibrary1.Utilities;

namespace ClassLibrary1
{
	public class Santa : Person
	{
		public static Random random = new Random();

		protected List<string> sack;

		public Santa(string name_) : base(name_)
		{
			sack = new List<string>(0);

		}

		public void Request(SnowMaiden snowMaiden, int amount)
		{
			string[] presents = snowMaiden.CreatePresent(amount);
			for (int i = 0; i < presents.Length; i++)
			{
				sack.Add(presents[i]);
			}
		}

		public void Give(Person person)
		{
			if (sack.Count == 0)
			{
				Console.WriteLine("alas, the sack is empty(");
				return;
			}

			int gift = random.Next(0, sack.Count);
			try
			{
				person.Receive(sack.ElementAt(gift));

				Console.WriteLine($"{this.ToString()} выдал {person.ToString()} " +
					$"подарок {sack.ElementAt(gift)}");

				sack.RemoveAt(gift);
			}
			catch (ArgumentException)
			{
				Console.WriteLine($"{person.ToString()} пытался забрать чужое!! ");
				person.Cancel = true;
			}
		}

		public override void Receive(string present)
		{
			base.Receive(present);
		}

		public override string ToString()
		{
			return Name;
		}

		public bool isSackEmpty()
		{
			if (sack.Count ==0)
			{
				return true;
			}

			return false;
		}

	}
}
