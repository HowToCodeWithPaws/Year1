using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameClassLibrary
{
	/// <summary>
	/// Класс грузового судна, наследуемый от класса Ship.
	/// </summary>
	public class CargoShip : Ship
	{
		// Защищенное поле для количества груза.
		protected int cargo;

		/// <summary>
		/// Публичное свойство для поля cargo с 
		/// сеттером и геттером.
		/// </summary>
		public int Cargo
		{
			get
			{
				if (cargo < 0)
				{
					return 0;
				}
				return cargo;
			}
			set { cargo = value; }
		}

		/// <summary>
		/// Открытый конструктор, задающий
		/// значение поля cargo. Наследуется от 
		/// конструктора класса Ship.
		/// </summary>
		/// <param name="_healthy"> Принимает 
		/// значение здоровья. </param>
		/// <param name="_cargo"> Принимает 
		/// количество груза. </param>
		public CargoShip(double _healthy, int _cargo)
			: base(_healthy)
		{
			Cargo = _cargo;
		}

		/// <summary>
		/// Открытый оверрайд метода класса Ship, отвечающий
		/// за получение урона: урон вычитается из здоровья,
		/// вызывается метод запоминания изменений.
		/// </summary>
		/// <param name="damage"> Принимает значение
		/// урона. </param>
		public override void GetDamage(double damage)
		{
			if (damage > 0)
			{
				Remember(false, $"Нанесен урон {damage}, " +
				$"на здоровье - {damage} единиц");
			}
			else
			{
				Remember(false, $"Нанесен нулевой урон, " +
					$"здоровье судна не изменилось.");
			}
			Healthy -= damage;
		}

		/// <summary>
		/// Открытый оверрайд метода класса Ship,
		/// возвращающий строку с информацией о судне: 
		/// в строю ли оно, здоровье и груз.
		/// </summary>
		/// <returns> Возвращает строку с информацией. </returns>
		public override string GetInfo()
		{
			if (IsAlive())
			{
				return $"Грузовое судно с параметрами: " +
				$"\nСостояние: в строю; Здоровье: " +
				$"{Healthy:0.##}; Груз: {Cargo};";
			}

			return $"Грузовое судно с параметрами: " +
					"\nСостояние: потоплен";
		}
	}
}
