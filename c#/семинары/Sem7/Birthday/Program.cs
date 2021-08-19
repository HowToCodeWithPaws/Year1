using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Birthday
{

	class Program
	{
		static void Main(string[] args)
		{
			Birthday myBirthday = new Birthday("Nat", 2001, 5, 4);
			Console.WriteLine(myBirthday.Information);
		}
	}
}
