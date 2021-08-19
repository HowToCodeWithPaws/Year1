using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetLib
{
	/// <summary>
	/// Класс для животного - кошки, наследуется
	/// от класса питомца, есть конструктор с 
	/// параметрами имени и массы, наследующийся от 
	/// базового, и переопределение метода ToString(),
	/// добавляющее строку "Cat with " к базовому.
	/// </summary>
	public class Cat:Pet
	{
		public Cat(string name_, double mass_) : base(name_, mass_) { }

		public override string ToString()
		{
			return "Cat with " + base.ToString();
		}
	}
}
