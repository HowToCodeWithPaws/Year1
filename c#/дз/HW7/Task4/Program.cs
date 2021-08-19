using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
	class Program
	{
		static void Main()
		{
			MyClassmate Nan = new MyClassmate();
			Console.WriteLine(Nan.Information());
			MyClassmate Bob = new MyClassmate("Смирнов", 1997);
			Console.WriteLine(Bob.Information());
		}
	}

}
