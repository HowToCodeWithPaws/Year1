using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetLib
{
	/// <summary>
	/// Абстрактный класс, реализующий интерфейс питомца: 
	/// имеет необходимые свойства с проверкой корректности 
	/// входных данных, конструктор с параметрами, реализацию
	/// сравнения объектов этого класса и переопределение
	/// метода ToString().
	/// </summary>
	public abstract class Pet : IPet
	{
		// Поля для имени и массы, используются в свойствах.
		string name;
		double mass;

		/// <summary>
		/// Публичное свойство имени с проверкой
		/// корректности данных в сеттере: имя
		/// должно состоять из латинских букв,
		/// первая заглавная, остальные строчные
		/// и длина строки от 3 до 10 символов.
		/// Иначе выбрасывается исключение PetException.
		/// </summary>
		public string Name
		{
			get
			{
				return name;
			}
			set
			{
				if (!(3 <= value.Length && value.Length <= 10)
					|| !value.Substring(1).All(a => 'a' <= a && a <= 'z')
					|| !('A' <= value[0] && value[0] <= 'Z'))
				{
					throw new PetException($"Недопустимая кличка {value}");
				}

				name = value;
			}
		}

		/// <summary>
		/// Публичное свойство массы с проверкой 
		/// в сеттере: масса не может быть отрицательной,
		/// в таком случае выбрасывается исключение
		/// PetException.
		/// </summary>
		public double Mass
		{
			get
			{
				return mass;
			}
			set
			{
				if (value < 0)
				{
					throw new PetException("Масса не может быть отрицательной");
				}

				mass = value;
			}
		}

		/// <summary>
		/// Защищенный конструктор с параметрами имени и массы.
		/// </summary>
		/// <param name="name_"> Строка для имени. </param>
		/// <param name="mass_"> Число для массы. </param>
		protected Pet(string name_, double mass_)
		{
			Name = name_;
			Mass = mass_;
		}

		/// <summary>
		/// Метод сравнения двух питомцев:
		/// сравнение по массе и в случае 
		/// равенства масс сравнение по кличке.
		/// Сделано с помощью тернарной операции,
		/// альтернативно можно было сделать if else.
		/// </summary>
		/// <param name="other"> Принимает на вход
		/// другой объект, реализующий интерфейс IPet. </param>
		/// <returns> Возвращает сравнение 
		/// по тому или иному параметру.</returns>
		public int CompareTo(IPet other) {

			return Mass.CompareTo(other.Mass) == 0 
				? Name.CompareTo(other.Name) 
				: Mass.CompareTo(other.Mass);
		}

		/// <summary>
		/// Переопределение ToString(), возвращающее 
		/// информацию о данном питомце, масса выводится
		/// до двух знаков после запятой, альтернативно
		/// можно было сделать #.00.
		/// </summary>
		/// <returns> Возвращает строку с именем и массой
		/// животного. </returns>
		public override string ToString()
		{
			return $"name: {Name}, mass: {Mass:F2}";
		}
	}
}
