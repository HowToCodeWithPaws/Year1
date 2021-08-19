using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
	class Program
	{


		static public Random rand = new Random();
		static void Main()
		{
			ConsolePlate cp = new ConsolePlate();
			ConsolePlate[] somePlates =
			{        new ConsolePlate('*', ConsoleColor.Red),
	   cp,
	   new ConsolePlate((char)12, ConsoleColor.Green)
	  };
			foreach (ConsolePlate conPl in somePlates)
			{
				Console.ForegroundColor = conPl.PlateColor;
				Console.Write(conPl.PlateChar);
			}

			ConsolePlate plateX = new ConsolePlate('X', ConsoleColor.White, ConsoleColor.Red);
			ConsolePlate plateO = new ConsolePlate('O', ConsoleColor.White, ConsoleColor.Magenta);

				int size;

			Console.ForegroundColor = ConsoleColor.White;

				do
				{
					Console.WriteLine("\nВведите размер поля: ");
				} while (!int.TryParse(Console.ReadLine(), out size) || size < 2 || size > 34);

	
			for (int i = 0; i < size; i++)
			{
				for (int j = 0; j < size; j++)
				{
					if (rand.Next(0,11)%2==0)
					{
						Console.BackgroundColor = plateO.Background;
						Console.ForegroundColor = plateO.PlateColor;
						Console.Write(plateO.PlateChar+" ");
					}
					else
					{
						Console.BackgroundColor = plateX.Background;
						Console.ForegroundColor = plateX.PlateColor;
						Console.Write(plateX.PlateChar+" ");
					}
				}
				Console.WriteLine();
				Console.ForegroundColor = ConsoleColor.White;
				Console.BackgroundColor = ConsoleColor.Black;
			}


		}
	}

}
