using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Зубарева Наталия 
//Вариант 1 

namespace SR3
{
	/// <summary>
	/// Класс животное с свойствами голода, счастья,
	/// конструктором, оверрайдом метода ту стринг.
	/// </summary>
	public class Animal
	{
		/// <summary>
		/// Закрытое поле голода.
		/// </summary>
		private double hunger;

		/// <summary>
		/// Открытое свойство для голода с геттером
		/// и сеттером(с проверкой правильности значений).
		/// </summary>
		public double Hunger
		{
			get
			{
				return hunger;
			}
			set
			{
				if (value<0)
				{
					hunger = 0;
				}
				else
				{
					if (value > 10)
					{
						hunger = 10;
					}

					hunger = value;
				}
			}
		}

		/// <summary>
		/// Открытое поле счастья с геттером,
		/// вычисляется по данный формуле.
		/// </summary>
		public double Happiness
		{
			get
			{
				return (1 - Hunger / 10) * (1 - Hunger / 10);
			}
		}

		/// <summary>
		/// Открытый конструктор, принимает на вход 
		/// вещественное значение голода.
		/// </summary>
		/// <param name="_hunger"> Значение голода. </param>
		public Animal(double _hunger)
		{
			Hunger = _hunger;
		}

		/// <summary>
		/// Оверрайд метода ту стринг:
		/// теперь метод возвращает информацию о животном.
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			if (Happiness > 0.5)
			{
				return $"Happy animal with hunger of {Hunger:F3}";
			}

			return $"Sad animal with hunger of {Hunger:F3}";
		}
	}
}
