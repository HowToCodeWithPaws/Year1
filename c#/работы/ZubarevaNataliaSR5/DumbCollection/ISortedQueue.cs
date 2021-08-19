using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DumbCollection
{
	/// <summary>
	/// Интерфейс для сортированной очереди
	/// с обобщением - требует реализации 
	/// метода удаления первого элемента очереди.
	/// </summary>
	/// <typeparam name="T"> Обобщение.
	/// </typeparam>
	public interface ISortedQueue<T>
	{
		Optional<T> Pop();
	}
}
