using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameClassLibrary
{
	/// <summary>
	/// Класс эсминец, наследуемый от класса 
	/// боевых кораблей.
	/// </summary>
	public class Destroyer : AttackingShip
	{
		/// <summary>
		/// Открытый конструктор копирует конструктор
		/// родительского класса.
		/// </summary>
		/// <param name="_healthy"> Принимает здоровье. </param>
		/// <param name="_damage"> Принимает наносимый урон. </param>
		/// <param name="_guard"> Принимает броню. </param>
		/// <param name="_guns"> Принимает орудия. </param>
		/// <param name="_ammunition"> Принимает припасы. </param>
		public Destroyer(double _healthy, double _guard, int _guns,
			double _damage, int _ammunition)
			: base(_healthy, _guard, _guns, _damage, _ammunition) { }

		/// <summary>
		/// Открытый оверрайд метода IsAlive: корабль жив, 
		/// если у него есть орудия в строю и здоровье >0 
		/// или произведено меньше минимального необходимого 
		/// числа атак.
		/// </summary>
		/// <returns> Воззвращает true, если корабль жив
		/// и false иначе. </returns>
		public override bool IsAlive()
		{
			return base.IsAlive() && Guns > 0;
		}

		/// <summary>
		/// Открытый оверрайд метода принятия урона:
		/// урон распределяется между броней и здоровьем
		/// пополам, с вероятностью 0,2 каждое орудие выходит
		/// из строя. Все изменения запоминаются.
		/// Если урон равен нулю (например при атаке корабля с
		/// нулевым количеством припасов), поля атакованного корабля
		/// не изменяются.
		/// </summary>
		/// <param name="damage"> Принимает размер урона. </param>
		public override void GetDamage(double damage)
		{
			if (damage > 0)
			{
				if (0.5 * damage <= Guard)
				{
					Guard -= 0.5 * damage;
					Healthy -= 0.5 * damage;
					Remember(false, $"Нанесен урон {damage:0.##}; " +
						$"На броню пришлось {0.5 * damage:0.##} единиц, " +
						$"на здоровье {0.5 * damage:0.##}");
				}
				else
				{
					Remember(false, $"Нанесен урон {damage:0.##}; " +
						$"На броню пришлось {Guard:0.##} единиц, ");
					damage -= Guard;
					Guard = 0;
					Remember(true, $"на здоровье {damage:0.##};");
					Healthy -= damage;

				}

				int numberOfGuns = Guns;

				for (int i = 0; i < numberOfGuns; i++)
				{
					if (Utilities.random.Next(1, 11) % 4 == 0)
					{
						Guns--;
					}
				}

				Remember(true, $" Сломалось {numberOfGuns - Guns} орудий");
			}
			else
			{
				Remember(false, $"Был нанесен нулевой урон," +
				$" состояние атакованного корабля не изменилось");
			}
		}

		/// <summary>
		/// Открытый оверрайд метода атаки, если припасов 
		/// достаточно, то стреляют все орудия, иначе столько,
		/// сколько припасов. Все изменения запоминаются.
		/// </summary>
		/// <param name="enemyShip"> Принимает корабль - противник. </param>
		public override void Attack(Ship enemyShip)
		{
			if (Ammunition >= Guns)
			{
				enemyShip.GetDamage(Damage * Guns);
				Ammunition -= Guns;
				Remember(false, $"Потрачено {Guns} припасов");
			}
			else
			{
				Remember(false, $"Потрачено {Ammunition} припасов");
				enemyShip.GetDamage(Damage * Ammunition);
				Ammunition = 0;
			}

		}

		/// <summary>
		/// Открытый оверрайд метода получения информации.
		/// </summary>
		/// <returns> Возвращает строку с информацией о 
		/// корабле. </returns>
		public override string GetInfo()
		{
			if (IsAlive())
			{
				return $"Эсминец с параметрами: " + base.GetInfo();
			}

			return "Эсминец с параметрами: \nСостояние: потоплен;";
		}
	}
}
