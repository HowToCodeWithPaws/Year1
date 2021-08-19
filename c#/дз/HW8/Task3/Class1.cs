using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
	class ArithmeticSequence
	{
		private double _start;
		private double _increment;

		public double Start
		{
			get { return _start; }
			set { _start = value; }
		}

		public double Increment
		{
			get { return _increment; }
			set { _increment = value; }
		}

		public ArithmeticSequence() : this(0, 1) { }

		public ArithmeticSequence(double start, double increment)
		{
			_start = start;
			_increment = increment;
		}

		public double GetSum(int n)
		{
			return ((2 * _start + (n - 1) * _increment) * n / 2.0);
		}

		public override string ToString()
		{
			return $"первый член {_start} \nи шаг {_increment}";
		}

		public double this[int index]
		{
			get
			{
				return (_start + (index - 1) * _increment);
			}
		}
	}
}
