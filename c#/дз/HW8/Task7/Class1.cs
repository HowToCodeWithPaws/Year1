using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task7
{
	class LinearEquation
	{
		public double CoeffA { get; set; }
		public double CoeffB { get; set; }
		public double CoeffC { get; set; }

		public LinearEquation(double a, double b) : this(a, b, 0) { }
		public LinearEquation(double a, double b, double c)
		{
			CoeffA = a;
			CoeffB = b;
			CoeffC = c;
		}

		public double Root()
		{
			return ((CoeffC-CoeffB)/CoeffA);
		}

		public override string ToString()
		{
			return $"Линейное уравнение:\n{CoeffA}х+({CoeffB})={CoeffC}\nКорень уравнения: {this.Root()}";
		}
	}
}
