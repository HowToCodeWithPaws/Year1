using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
	public abstract class Dimensions:ISquare, INameable
	{
		public int Side { get; }
		public int BaseSide { get; }

		protected Dimensions(int side, int baseSide)
		{  // Конструктор
			Side = side;
			BaseSide = baseSide;
		}
	
		 public abstract double Square{ get; }   
		
		// Площадь фигуры
	}   // Dimensions end

}
