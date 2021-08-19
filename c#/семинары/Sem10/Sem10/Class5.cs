using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sem10;

namespace Sem10
{
	class Boss:Mob
	{
		public int Level { get; }
		public Boss(int hp, int xp, int strenght, int level):base(hp, xp, strenght)
		{
			Level = level;
		}

		public override void Attack(Unit enemy)
		{
			enemy.HP-=Strength*Level;
		}
	}
}
