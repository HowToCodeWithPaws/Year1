using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DumbCollection
{
	/// <summary>
	/// Интерфейс для коллекции со свойством размера,
	/// методами получения равного элемента, добавления
	/// элемента и проверки, присутствует ли элемент
	/// в коллекции.
	/// </summary>
	/// <typeparam name="T"> Обобщение коллекции.
	/// </typeparam>
	public interface ICollection<T>
	{
		int Size { get; }

		Optional<T> TryGetEquals(T item);

		void Add(T item);

		bool Contains(T item);
	}
}
