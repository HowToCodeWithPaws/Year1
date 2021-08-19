using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sem4
{
	class Battlefield
	{
		static public Random rand = new Random();

		Battleship battleship1;
		Battleship battleship2;
		Logger logger;

		public Battlefield(Battleship b1, Battleship b2, Logger logger1)
		{
			battleship1 = b1;
			battleship2 = b2;
			logger = logger1;
		}

		public void Battle()
		{
			while (battleship1.Health>0 && battleship2.Health>0)
			{
				if (rand.Next(2)==0)
				{
					battleship1.AttackShip(battleship2);
					logger.Write("корабль 1 бьет корабль 2");
				}
				else
				{
					battleship2.AttackShip(battleship1);
					logger.Write("корабль 2 бьет корабль 1");
				}

				
			}
		}
	}
}
