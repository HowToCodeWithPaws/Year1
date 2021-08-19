using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sem10;

namespace Sem10
{
	class Weapon
	{
		public string Name { get; }
		public int WeaponPower { get; }


		public Weapon(int number)
		{
			switch (number)
			{
				case 1:
					Name = "Цементная Чашка";
					WeaponPower = 6;
					break;

				case 2:
					Name = "Убийственный Взгляд";
					WeaponPower = 30;
					break;

				case 3:
					Name = "Ядовитый Фикус";
					WeaponPower = 10;
					break;

				case 4:
					Name = "Меч";
					WeaponPower = 20;
					break;

				case 5:
					Name = "Ручной Динозавр";
					WeaponPower = 90;
					break;

				default:
					Name = "Удача";
					WeaponPower = 1;
					break;
			}
		}
	}
}
