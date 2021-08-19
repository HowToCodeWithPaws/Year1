using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sem10;

namespace Sem10
{
	class Mob:Unit
	{
		public Mob(int hp, int xp, int strength) : base(hp) {
			XP = xp;
			Strength = strength;
		}

		public override string ToString()
		{
			return $"Противник - моб с hp {HP}, \n\t\tоружием {UnitsWeapon.Name} \n\t\tс силой {UnitsWeapon.WeaponPower} \n\t\tи собственной силой {Strength}.";
		}

	}
}
