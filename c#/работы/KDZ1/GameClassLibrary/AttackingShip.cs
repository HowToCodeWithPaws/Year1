using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameClassLibrary
{
	/// <summary>
	/// Абстрактный класс, наследуемый от класса Ship, 
	/// является базой для всех боевых кораблей.
	/// </summary>
	public abstract class AttackingShip : Ship
	{
		// Защищенные поля для наносимого урона,
		// брони, орудий и припасов.
		protected double damage;
		protected double guard;
		protected int guns;
		protected int ammunition;

		/// <summary>
		/// Публичное свойство для поля damage с 
		/// геттером.
		/// </summary>
		public double Damage
		{
			get { return damage; }
		}

		/// <summary>
		/// Публичное свойство для поля guard с 
		/// сеттером и геттером.
		/// </summary>
		public double Guard
		{
			get
			{
				if (guard < 0)
				{
					return 0;
				}
				return guard;
			}
			set { guard = value; }
		}

		/// <summary>
		/// Публичное свойство для поля guns с 
		/// сеттером и геттером.
		/// </summary>
		public int Guns
		{
			get
			{
				if (guns < 0)
				{
					return 0;
				}
				return guns;
			}
			set { guns = value; }
		}

		/// <summary>
		/// Публичное свойство для поля ammunition с 
		/// сеттером и геттером.
		/// </summary>
		public int Ammunition
		{
			get
			{
				if (ammunition < 0)
				{
					return 0;
				}
				return ammunition;
			}
			set { ammunition = value; }
		}

		/// <summary>
		/// Открытый конструктор, наследуемый от конструктора Ship.
		/// задает значения полю урона, через свойства - броне, 
		/// орудиям и припасам.
		/// </summary>
		/// <param name="_healthy"> Принимает значение здоровья. </param>
		/// <param name="_damage"> Принимает значение урона. </param>
		/// <param name="_guard"> Принимает значение брони. </param>
		/// <param name="_guns"> Принимает количество орудий. </param>
		/// <param name="_ammunition"> Принимает количество 
		/// припасов. </param>
		public AttackingShip(double _healthy, double _guard,
			int _guns, double _damage, int _ammunition) : base(_healthy)
		{
			damage = _damage;
			Guard = _guard;
			Guns = _guns;
			Ammunition = _ammunition;
		}

		/// <summary>
		/// Абстрактный метод атаки.
		/// </summary>
		/// <param name="enemyShip"> Принимает на вход 
		/// атакуемый корабль. </param>
		public abstract void Attack(Ship enemyShip);

		/// <summary>
		/// Открытый оверрайд метода, возвращающего
		/// информацию о корабле.
		/// </summary>
		/// <returns> Возвращает строку с 
		/// параметрами корабля. </returns>
		public override string GetInfo()
		{
			string alive = IsAlive() ? "в строю" : "потоплен";

			return $"\nСостояние: {alive}; Здоровье: {Healthy:0.##};" +
				$" Защита: {Guard:0.##}; Орудия в строю: {Guns}; " +
				$"Наносимый урон: {Damage:0.##}; Боеприпасы: {Ammunition};";
		}
	}
}
