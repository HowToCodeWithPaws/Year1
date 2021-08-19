using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1;

namespace Sem11
{
	class Program
	{
		static void Main(string[] args)
		{
			Dimensions[] dims = new Dimensions[]
			{
				new Triangle(1,1),
			new SquareFig(19,2)
			};

			foreach (ISquare figure in dims)
			{
				Console.WriteLine(figure.Square);
			}

			INameable[] nameables = new INameable[]
			{
				new Triangle(1,1),
			new SquareFig(1,3), Box()
			};

		}
	}
}
