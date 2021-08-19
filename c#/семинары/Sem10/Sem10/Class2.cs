using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sem10
{
	class Hero:Unit
	{
		static Random random = new Random();
		public string Name { get; }

		public Hero(string name, int hp): base(hp){
			Name = name;
		}

		public override void Attack(Unit enemy)
		{
			base.Attack(enemy);
			enemy.HP -= UnitsWeapon.WeaponPower;
		}

		public void Heal(int healingOption)
		{
			switch (healingOption)
			{
				case 1:
					Console.WriteLine($"{Name} спит 10 часов, hp увеличивается на 10 !!!");
					HP += 10;
					break;

				case 2:
					Console.WriteLine($"{Name} находит волшебное пианино, hp увеличивается на 40 !!!");
					HP += 40;
					break;

				case 3:
					Console.WriteLine($"{Name} проводит выходные дома, hp увеличивается на 5 !!!");
					HP += 5;
					break;

				default:
					Console.WriteLine($"{Name} съедает вкусную клубничку, hp увеличивается на 1 !!!");
					HP += 1;
					break;
			}
		}

		public bool Fight(Mob mob)
		{
			while (this.IsAlive&&mob.IsAlive)
			{
				Attack(mob);
				mob.Attack(this);
			}
			return IsAlive;
		}

		public bool Fight(MobArmy mobArmy)
		{
			while (IsAlive && mobArmy.IsAlive())
			{
				int randomMobIndex = random.Next(mobArmy.Size);
				Mob mobInArmy = mobArmy[randomMobIndex];
				if (mobInArmy.IsAlive)
				{
					Attack(mobInArmy);
					mobInArmy.Attack(this);
				}
			}
			return IsAlive;
		}
	}
}
