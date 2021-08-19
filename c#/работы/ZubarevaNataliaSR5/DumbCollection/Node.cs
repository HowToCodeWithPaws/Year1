using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DumbCollection
{
	/// <summary>
	/// Класс для ноды в коллекции.
	/// Нода хранит информацию, ссылки на
	/// предыдущую и следующие ноды, методы
	/// Equals и Dispose и конструктор с 
	/// параметрами.
	/// </summary>
	/// <typeparam name="T"> Обобщение типа 
	/// информации в ноде. </typeparam>
	public class Node<T> : IEquatable<T>, IDisposable
	{
		// Информация в ноде.
		public T Data { get; set; }

		// Ссылки на предыдущую и следующую ноды.
		public Node<T> Next { get; set; }

		public Node<T> Previous { get; set; }

		/// <summary>
		/// Конструктор с параметрами.
		/// </summary>
		/// <param name="data"> Информация в ноде. </param>
		/// <param name="previous"> Ссылка на предыдущую ноду. </param>
		/// <param name="next"> Ссылка на следующую ноду.</param>
		public Node(T data, Node<T> previous = null, Node<T> next = null)
		{
			Data = data;
			Next = next;
			Previous = previous;
		}

		/// <summary>
		/// Реализация интерфейса IEquatable<T>.
		/// </summary>
		/// <param name="other"> Информация типа Т,
		/// с которой сравнивается нода. </param>
		/// <returns> Возвращает результат сравнения
		/// информации в ноде и пришедшей информации.
		/// </returns>
		public bool Equals(T other)
		{
			return Data.Equals(other);
		}

		/// <summary>
		/// Реализация интерфейса IDisposable.
		/// </summary>
		public void Dispose()
		{
			Next = null;
			Previous = null;
		}
	}
}
