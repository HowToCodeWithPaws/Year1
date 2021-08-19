using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameClassLibrary
{
	/// <summary>
	/// Класс линкора, наследуемый от боевого корабля.
	/// </summary>
	public class Battleship : AttackingShip
	{
		// Защищенное поле минимального количества атак,
		// необходимого, чтобы потопить линкор.
		protected int minimalAttacked;

		/// <summary>
		/// Публичное свойство для поля minimalAttacked с 
		/// геттером.
		/// </summary>
		public int MinimalAttacked
		{
			get { return minimalAttacked; }
		}

		/// <summary>
		/// Автореализуемое свойство для количества
		/// уже произведенных атак.
		/// </summary>
		public int Attacked { get; set; }

		/// <summary>
		/// Открытый конструктор, наследуемый от конструктора 
		/// боевого корабля. Задает минимальное количество атак,
		/// а также произведенные атаки.
		/// </summary>
		/// <param name="_healthy"> Принимает здоровье. </param>
		/// <param name="_damage"> Принимает урон. </param>
		/// <param name="_guard"> Принимает броню. </param>
		/// <param name="_guns"> Принимает орудия. </param>
		/// <param name="_ammunition"> Принимает припасы. </param>
		/// <param name="_minimalAttacked"> Принимает минимальное 
		/// количество атак. </param>
		public Battleship(double _healthy, double _guard, int _guns,
			double _damage, int _ammunition, int _minimalAttacked)
			: base(_healthy, _guard, _guns, _damage, _ammunition)
		{
			minimalAttacked = _minimalAttacked;
			Attacked = 0;
		}

		/// <summary>
		/// Открытый оверрайд метода принятия урона:
		/// урон разделяется между здоровьем и броней 
		/// в отношении 3 к 7, увеличивается количество 
		/// совершенных атак, с вероятностью 0,1 все орудия
		/// выходят из строя. Запоминаются изменения
		/// методом Remember.
		/// Если урон равен нулю, ничего не меняется.
		/// </summary>
		/// <param name="damage"> Принимает урон. </param>
		public override void GetDamage(double damage)
		{
			if (damage > 0)
			{
				Attacked += 1;

				if (0.7 * damage <= Guard)
				{
					Guard -= 0.7 * damage;
					Healthy -= 0.3 * damage;
					Remember(false, $"Нанесен урон {damage:0.##}; " +
						$"На броню пришлось {0.7 * damage:0.##} единиц, " +
						$"на здоровье - {0.3 * damage:0.##}");
				}
				else
				{
					Remember(false, $"Нанесен урон {damage:0.##}; " +
						$"На броню пришлось {Guard:0.##} единиц, ");
					damage -= Guard;
					Guard = 0;
					Remember(true, $"на здоровье - {damage:0.##};");
					Healthy -= damage;
				}

				int numberOfGuns = Guns;

				for (int i = 0; i < numberOfGuns; i++)
				{
					if (Utilities.random.Next(1, 11) % 7 == 0)
					{
						Guns--;
					}
				}

				Remember(true, $" Сломалось {numberOfGuns - Guns} орудий");
			}
			else
			{
				Remember(false, $"Был нанесен нулевой урон, состояние " +
					$"атакованного корабля не изменилось");
			}
		}

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
			return (base.IsAlive() || Attacked < MinimalAttacked) && Guns > 0;
		}

		/// <summary>
		/// Открытый оверрайд метода атаки. 
		/// Если припасов >= чем орудий, противник получает 
		/// урон в размере Damage * Guns, тратится столько 
		/// припасов, сколько орудий стреляло. Иначе урон
		/// наносится тем количеством припасов, которое есть,
		/// оно становится равно 0. Все изменения запоминаются
		/// с помощью метода Remember.
		/// </summary>
		/// <param name="enemyShip"> Принимает 
		/// корабль-противник. </param>
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
		/// Открытый оверрайд метода, 
		/// возвращающего информацию о корабле.
		/// </summary>
		/// <returns></returns>
		public override string GetInfo()
		{
			if (IsAlive())
			{
				return $"Линкор с параметрами:" + base.GetInfo() +
			$"\nМинимальное количество атак: {MinimalAttacked};" +
			$" Уже был атакован {Attacked} раз;";
			}
			return "Линкор с параметрами:\nСостояние: потоплен;";
		}
	}
}
