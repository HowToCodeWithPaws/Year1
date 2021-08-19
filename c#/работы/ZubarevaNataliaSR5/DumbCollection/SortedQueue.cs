using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DumbCollection
{
	/// <summary>
	/// Класс для отсортированной очереди, которая реализует 
	/// интерфейсы ICollection<T>, ISortedQueue<T> и IEnumerable<T>,
	/// информация реализует интерфейс IComparable<T>.
	/// Эта очередь сортируется, выводится методом ToString() через 
	/// пробел, в нее можно добавить элемент, а также удалить первый
	/// в очереди. Короче, отсортированная.очередь.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class SortedQueue<T> : ICollection<T>, ISortedQueue<T>, 
		IEnumerable<T> where T : IComparable<T>
	{
		// Поле для стандартной реализации сравнения.
		IComparer<T> myComparer;

		/// <summary>
		/// Свойства - ноды головы и хвоста.
		/// </summary>
		Node<T> Head { get; set; }
		Node<T> Tail { get; set; }

		/// <summary>
		/// Свойство размера с приватным сеттером.
		/// </summary>
		public int Size { get; private set; }

		/// <summary>
		/// Конструктор без параметров - 
		/// формируется пустая очередь и 
		/// сравнения осуществляется по дефолтному
		/// сравнению для типа Т.
		/// </summary>
		public SortedQueue()
		{
			Head = Tail = null;
			myComparer = Comparer<T>.Default;
		}

		/// <summary>
		/// Конструктор, создающий пустую очередь,
		/// для сравнения элементов которой используется
		/// переданная в конструктор реализация интерфейса
		/// IComparer<TKey>.
		/// </summary>
		/// <param name="comparer"> Реализация сравнения.
		/// </param>
		public SortedQueue(IComparer<T> comparer)
		{
			Head = Tail = null;
			myComparer = comparer;
		}

		/// <summary>
		/// Метод добавления элемента в очередь.
		/// Поддерживает сортировку очереди.
		/// </summary>
		/// <param name="item"> Принимает информацию,
		/// по которой нужно создать ноду. </param>
		public void Add(T item)
		{
			// Увеличиваем размер.
			++Size;

			// Если очередь пуста, добавляем отдельно.
			if (Head == null)
			{
				Head = new Node<T>(item);
				Tail = Head;
				return;
			}

			// Если в очереди есть элементы, сортировкой
			// ищем индекс, перед которым нужно поставить 
			// новую ноду.
			for (int i = 0; i < Size - 1; i++)
			{
				if (myComparer.Compare(GetNode(i).Data, item) > 0)
				{
					// Вызываем метод вставки.
					Insert(item, i);
					return;
				}
			}

			// Если у новой ноды самый низкий приоитет,
			// записываем ее в хвост и меняем ссылки.
			Node<T> newNode = new Node<T>(item, Tail);
			Tail.Next = newNode;
			Tail = newNode;
		}

		/// <summary>
		/// Метод для вставки элемента в какое-то место
		/// в коллекции. Нужен для более удобного
		/// формирования сортированной очереди.
		/// </summary>
		/// <param name="item"> Принимает на вход информацию,
		/// элемент с которой нужно вставить в очередь. </param>
		/// <param name="index"> Принимает индекс, перед 
		/// которым нужно вставить новую ноду. </param>
		void Insert(T item, int index)
		{
			// Создание новой, предыдущей и следующей нод.
			Node<T> newNode = new Node<T>(item);
			Node<T> nextNode = GetNode(index);
			Node<T> previousNode = nextNode.Previous;

			// Если предыдущая не пустая, даем ей ссылку на новую.
			if (previousNode != null) previousNode.Next = newNode;

			// Привязываем к новой ссылки на ноды рядом.
			newNode.Previous = previousNode;
			newNode.Next = nextNode;

			// Если следующая не пустая, даем ей ссылку на новую.
			if (nextNode != null) nextNode.Previous = newNode;

			// Если мы добавили ноду перед началом очереди,
			// меняем ссылку на голову.
			if (index == 0) { Head = newNode; }
		}

		/// <summary>
		/// Метод для проверки, содержится ли элемент
		/// с информацией в коллекции.
		/// </summary>
		/// <param name="item"> Принимает информацию
		/// для сравнения. </param>
		/// <returns> Возвращает true или false в 
		/// зависимости от наличия. </returns>
		public bool Contains(T item)
		{
			Node<T> currentNode = Head;

			// Проходим циклом по всей коллекции.
			while (currentNode != null)
			{
				if (currentNode.Equals(item))
				{
					// Если нашелся равный, возвращаем true.
					return true;
				}

				currentNode = currentNode.Next;
			}

			// Если равный не нашелся - false.
			return false;
		}

		/// <summary>
		/// Метод для возвращения равного элемента
		/// иногда дает неожиданные результаты при 
		/// интересно (читать "садистически")
		/// переопределенном Equals. Если нет элементов,
		/// хоть как-то удовлетворяющих равенству,
		/// возвращает аналог null.
		/// </summary>
		/// <param name="item"> Принимает значение
		/// информации, по которому проверяется равенство.
		/// </param>
		/// <returns> Возвращает объект Optional<T>
		/// либо пустой, либо сформированный по информации.
		/// </returns>
		public Optional<T> TryGetEquals(T item)
		{
			Node<T> currentNode = Head;

			// Проходим по всем нодам и проверяем равенство.
			while (currentNode != null)
			{
				if (currentNode.Equals(item))
				{
					// Возвращаем объект сформированный 
					// по информации "равного".
					return new Optional<T>(currentNode.Data);
				}

				currentNode = currentNode.Next;
			}

			// Иначе возвращаем пустой объект.
			return Optional<T>.Empty();
		}

		/// <summary>
		/// Метод для удаления первого элемента очереди.
		/// </summary>
		/// <returns> Возвращает объект Optional<T>
		/// либо сформированный по содержимому ноды,
		/// либо пустой. </returns>
		public Optional<T> Pop()
		{
			// Если очередь пустая, возвращаем "null".
			if (Head == null)
			{
				return Optional<T>.Empty();
			}

			// Иначе копируем информацию об удаляемой ноде. 
			Node<T> nodeToRemove = Head;
			Optional<T> removed = new Optional<T>(nodeToRemove.Data);

			// Меняем ссылки, сдвигая очередь.
			Head = Head.Next;
			Head.Previous = null;

			// Уничтожаем ноду.
			nodeToRemove.Dispose();

			// Уменьшаем размер.
			--Size;

			// Возвращаем информацию об удаленной ноде.
			return removed;
		}

		/// <summary>
		/// Метод, позволяющий по индексу получить
		/// ссылку на ноду с таким порядковым номером
		/// в очереди.
		/// </summary>
		/// <param name="index"> Принимает индекс. </param>
		/// <returns> Возвращает ссылку на ноду. </returns>
		private Node<T> GetNode(int index)
		{
			// Если индекс вне границ, кидается эксепшн.
			if (index < 0 || index >= Size)
			{
				throw new ArgumentOutOfRangeException();
			}

			// Начинаем с головы.
			Node<T> currentNode = Head;

			// Меняем текущую столько раз, сколько нужно.
			for (int i = 0; i < index; ++i)
			{
				currentNode = currentNode.Next;
			}

			return currentNode;
		}

		/// <summary>
		/// Реализуем интерфейс IEnumerable.
		/// Начинаем с головы и далее, проходясь
		/// по нодам, если нода не null, 
		/// делаем отложенный возврат ноды.
		/// </summary>
		/// <returns></returns>
		public IEnumerator<T> GetEnumerator()
		{
			Node<T> currentNode = Head;

			while (currentNode != null)
			{
				yield return currentNode.Data;
				currentNode = currentNode.Next;
			}
		}

		/// <summary>
		/// Реализуем интерфейс IEnumerable.
		/// </summary>
		/// <returns></returns>
		IEnumerator IEnumerable.GetEnumerator()
		{
			return (this as IEnumerable<T>).GetEnumerator();
		}

		/// <summary>
		/// Переопределение метода ToString() для 
		/// упорядоченной очереди - выводит
		/// элементы в одну строку через пробел.
		/// </summary>
		/// <returns> Возвращает строку
		/// нужного формата. </returns>
		public override string ToString()
		{
			string text = string.Empty;

			Node<T> currentNode = Head;

			while (currentNode != null)
			{
				text += currentNode.Data.ToString() + " ";

				currentNode = currentNode.Next;
			}

			return text.Trim();
		}
	}
}
