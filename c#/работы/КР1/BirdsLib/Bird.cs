using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirdsLib
{
	/// <summary>
	/// Родительский класс для всех птиц.
	/// </summary>
	public abstract class Bird
	{
		// Защищенные поля.
		protected int maxDistance;
		protected bool isPredator;
		protected string name;

		/// <summary>
		/// Свойство для имени с проверкой длины.
		/// </summary>
		protected string Name
		{
			get { return name; }
			set
			{
				if (value.Length < 2)
				{
					throw new ArgumentException("the name must be longer than 1 symbol");
				}

				name = value;
			}
		}

		/// <summary>
		/// Свойство только для чтения, хищная ли птица.
		/// </summary>
		protected bool IsPredator
		{
			get;
		}

		/// <summary>
		/// Свойство для максимальной длины полета с проверкой допустимого значения.
		/// </summary>
		protected int MaxDistance
		{
			get { return maxDistance; }
			set
			{
				if (value < 0)
				{
					throw new ArgumentException("the bird must fly");
				}

				maxDistance = value;
			}
		}

		/// <summary>
		/// Перегрузка конструктора с задаваемыми параметрами.
		/// </summary>
		/// <param name="name_"> Имя птицы. </param>
		/// <param name="maxDistance_"> Длина полета. </param>
		public Bird(string name_, int maxDistance_)
		{
			Name = name_;
			MaxDistance = maxDistance_;
		}

		/// <summary>
		/// Конструктор со всеми параметрами.
		/// </summary>
		/// <param name="name_"> Имя. </param>
		/// <param name="isPredator_"> Хищная ли птица. </param>
		/// <param name="maxDistance_"> Длина полета. </param>
		public Bird(string name_, bool isPredator_, int maxDistance_)
		{
			Name = name_;
			IsPredator = isPredator_;
			MaxDistance = maxDistance_;
		}

		/// <summary>
		/// Абстрактный метод перелета.
		/// </summary>
		/// <returns></returns>
		public abstract int Move();

		/// <summary>
		/// Оверрайд метода ту стринг.
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return $"Name:{Name}; IsPredator: {IsPredator}; MaxDistance: {MaxDistance}";
		}
	}
}
