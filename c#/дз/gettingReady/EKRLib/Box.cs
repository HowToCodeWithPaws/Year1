using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace EKRLib
{
	public class Box : Item
	{
		double a, b, c;
		public double A { get => a; }
		public double B { get => b; }
		public double C { get => c; }

		public double GetLongestSideSize() => A >= B ? (A >= C ? A : C) : B >= C ? B : C;

		public override string ToString() => base.ToString() + $", A: {A:F3}, B: {B:F3}, C: {C:F3}";

		public Box(double a, double b, double c, double weight) : base(weight)
		{
			if (a < 0 || b < 0 || c < 0)
			{
				throw new ItemsException("negative dimensions are prohibited");
			}

			this.a = a;
			this.b = b;
			this.c = c;
		}

	}
}
