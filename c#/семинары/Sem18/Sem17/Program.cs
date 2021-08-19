using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sem17
{

	delegate void Del();
	class Program
	{
		static event Del Ev;

		static void f1() { Console.WriteLine("f1"); }
		static void f2() { Console.WriteLine("f2"); }
		static void f3() { Console.WriteLine("f3"); }
		static void Main(string[] args)
		{
			Ev += f1;
			Ev += f3;
			Ev += f2;
			Ev();
		}
	}
}
