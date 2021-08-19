using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
	/// <summary>
	/// Класс Burger с требуемыми членами.
	/// </summary>
	public class Burger
	{
		// Перечисление кто?
		private static List<BurgerPart> burgerParts = new List<BurgerPart>();

		// Имя.
		public string Name { get; }

		// Поля для подсчета булочек и котлеток.
		private int buns = 0;
		private int patties = 0;


		/// <summary>
		/// Публичное свойство для поля buns с сеттером и геттером.
		/// </summary>
		public int Buns
		{
			get { return buns; }
			set { buns = value; }
		}


		/// <summary>
		/// Публичное свойство для поля patties с сеттером и геттером.
		/// </summary>
		public int Patties
		{
			get { return patties; }
			set { patties = value; }
		}

		// Конструктор.
		public Burger(string name)
		{
			Name = name;
			burgerParts.Clear();
		}

		// Цена, вычисляющаяся по формуле.
		public int Price
		{
			get
			{
				Count();
				return 30 * Patties + 10 * Buns;
			}
		}

		// Метод для подсчета ингридиетов в перечислении.
		public void Count()
		{
			for (int i = 0; i < burgerParts.Count; i++)
			{
				if (burgerParts[i] == BurgerPart.Bun)
				{
					Buns++;
				}
				else
				{
					Patties++;
				}
			}
		}

		// Переопределенный метод ToString().
		// Альтернативное решение: можно было объединять как String.Join.
		// Можно было не делать ПЕРЕЧИСЛЕНИЯ например.
		public override string ToString()
		{
			string parts = burgerParts[0].ToString() + ", ";

			for (int i = 1; i < burgerParts.Count - 1; i++)
			{
				parts += burgerParts[i] + ", ";
			}

			parts += burgerParts[burgerParts.Count - 1]+".";

			return $"Burger {Name} with price {Price} and parts {parts}";
		}

		/// <summary>
		/// Методы для добавления булочек и котлеток.
		/// </summary>
		public static void AddBunToBurger(Burger burger)
		{
			burgerParts.Add(BurgerPart.Bun);
		}
		public static void AddPattyToBurger(Burger burger)
		{
			burgerParts.Add(BurgerPart.Patty);
		}

		// Тип делегата.
		public delegate void BurgerAction(Burger burger);
	}
}
