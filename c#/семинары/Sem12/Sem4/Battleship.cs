using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sem4
{
	class Battleship
	{
		public int Attack { get; }
		public int Health { get; set; }

		public Battleship()
		{
			Attack = 10;
			Health = 40;
		}

		public void AttackShip(Battleship enemy)
		{
			enemy.Health -= this.Attack;
		}
	}
}
