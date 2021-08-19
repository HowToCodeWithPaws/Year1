using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sem10
{
	abstract class Unit
	{
		private readonly int maxHP;
		private int hp;

		static Random random = new Random();

		public Unit() : this(100) { }

		public Unit(int hp) : this(hp, hp, random.Next(1,10)) { }

		public Unit(int hp, int maxHP, int number)
		{
			this.hp = hp;
			this.maxHP = maxHP;
			Strength = 10;
			XP = 0;
			UnitsWeapon = new Weapon(number);
		}

		public Weapon UnitsWeapon { get; protected set; }
		public int HP
		{
			get
			{
				return hp;
			}
			set
			{
				if (value > maxHP)
				{
					hp = maxHP;
				}
				else { hp = value > 0 ? value : 0; }
			}
		}
		public int XP { get; protected set; }
		public int Strength { get; protected set; }

		public virtual void Attack(Unit enemy)
		{
			enemy.HP -= Strength;
		}

		public bool IsAlive
		{
			get
			{
				return hp > 0;
			}
		}

		public void ChangeWeapon()
		{
			UnitsWeapon = new Weapon(random.Next(1, 10));
		}
	}
}
