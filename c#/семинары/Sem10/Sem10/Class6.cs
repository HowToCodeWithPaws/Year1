using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Sem10
{

	class MobArmy
	{
		public static Random rand = new Random();
		private Mob[] army;

		public int Size
		{
			get
			{
				return army.Length;
			}
		}

		public bool IsAlive()
		{
			int totalHp = 0;
			foreach (Mob mob in army)
			{
				totalHp += mob.HP;
			}
			return totalHp > 0;
		}

		public MobArmy(int size)
		{
			army = new Mob[size];
			for (int i = 0; i < size; i++)
			{
				if (rand.Next(0,5)==0)
				{
					army[i] = new Boss(rand.Next(5, 16), rand.Next(0, 10), rand.Next(10, 25), rand.Next(1, 5));
				}
				else
				{
					army[i] = new Mob(rand.Next(5, 16), rand.Next(0, 10), rand.Next(10, 25));
				}
			}
		}

		public Mob this[int index]
		{
			get
			{
				return army[index];
			}
		}


	}
}
