using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreLibrary
{
	/// <summary>
	/// Коллекция книг, обобщена на наследников Product и его самого.
	/// Имеет метод добавления, реализует IEnumerable<T>.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	[DataContract]
	[KnownType(typeof(Book))]
	[KnownType(typeof(Product))]
	public class Bookstore<T> : IEnumerable<T> where T:Product
	{
		/// <summary>
		/// Приватная коллекция элементов - книг и не только.
		/// </summary>
		[DataMember]
		private List<T> items;

		/// <summary>
		/// Метод добавления элемента к коллекции.
		/// </summary>
		/// <param name="item"> Добавляемый элемент.</param>
		public void Add(T item) => items.Add(item);

		/// <summary>
		/// Методы для реализации IEnumerable<T> с помощью готового
		/// итератора коллекции.
		/// </summary>
		/// <returns></returns>
		public IEnumerator<T> GetEnumerator() => items.GetEnumerator();

		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

		/// <summary>
		/// Конструктор без параметров задает новую коллекцию.
		/// </summary>
		public Bookstore() { items = new List<T>(); }
	}
}
