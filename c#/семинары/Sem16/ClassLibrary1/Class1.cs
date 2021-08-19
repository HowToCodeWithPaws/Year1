using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ClassLibrary1
{
    public class Class1
    {
		public delegate double FuncDelegate(double arg);

		public static void PrintFunction(double x1, double x2, double delta, FuncDelegate f)
		{
			for (double i = x1; i < x2; i+=delta)
			{
				Console.WriteLine($"f({i:F2})={f(i):F2}");
			}
		}

	}
}
