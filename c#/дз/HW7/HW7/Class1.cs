using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW7
{
	class Point
	{
		public double X { get; set; }
		public double Y { get; set; }
		public Point(double x, double y) { X = x; Y = y; }
		public Point() : this(0, 0) { } // конструктор умолчания

		public double Fi
		{
			get
			{
				if (X>0)
				{
					if (Y>=0)
					{
						return Math.Atan(Y / X);
					}
					if (Y<0)
					{
						return Math.Atan(Y / X)+2*Math.PI;
					}
				}
				if (X==0)
				{
					if (Y==0)
					{
						return 0;
					}
					if (Y<0)
					{
						return 3 * Math.PI / 2;
					}
					if (Y>0)
					{
						return  Math.PI / 2;
					}
				}
				if (X<0)
				{
					return Math.Atan(Y / X) +  Math.PI;
				}
				return 1;
			}
		}// СВОЙСТВО RO
		public double Ro
		{
			get
			{
				return Math.Sqrt(Y*Y+X*X);
			}
		}       // СВОЙСТВО FI
		public string PointData
		{   // СВОЙСТВО 
			get
			{
				string maket =  "X = {0:F2}; Y = {1:F2}; Ro = {2:F2}; Fi = {3:F2} ";
				return string.Format(maket, X, Y, Ro, Fi);
			}
		}
	}
}