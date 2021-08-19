using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polygon
{
	public class Polygon
	{ // Класс многоугольников
		int numb;       // Число сторон
		double radius;  // Радиус вписанной окружности
		public Polygon(int n = 3, double r = 1)
		{ // конструктор       
			numb = n;
			radius = r;
		}

		public double Perimeter
		{ // Периметр многоугольника - свойство
			get
			{   // аксессор свойства
				double term = Math.Tan(Math.PI / numb);
				return 2 * numb * radius * term;
			}
		}

		public double Area
		{ // Площадь многоугольника - свойство
			get
			{   // аксессор свойства
				return Perimeter * radius / 2;
			}
		}

		public string PolygonData()
		{
			string res =
			string.Format($"N={numb}; \nR={radius}; \nP={Perimeter:F3}; \nS={Area:F3}") ;
			return res;
		}
	}   // Polygon 
}
