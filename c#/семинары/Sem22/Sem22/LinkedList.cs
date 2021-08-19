using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sem22
{
	public class LinkedList<T> : ICollection<T>, IIndex<T>
	{
		Node<T> Head { get; set; }
		Node<T> Tail { get; set; }

		public int Size { get; private set; }

		public T this[int index]
		{
			get
			{
				if (index < 0 || index >= Size)
				{
					throw new ArgumentOutOfRangeException();
				}

				Node<T> currentNode = Head;

				for (int i = 0; i < index; i++)
				{
					currentNode = currentNode.Next;
				}

				return currentNode.Data;
			}
		}

		public void Add(T item)
		{
			if (Head == null)
			{
				Head = new Node<T>(item);
				Tail = Head;
			}
			else
			{
				Node<T> newNode = new Node<T>(item, Tail);
				Tail.Next = newNode;
				Tail = newNode;
			}

			++Size;
		}

		public void RemoveAt(int index) { }

		public bool Contains(T item)
		{
			Node<T> currentNode = Head;
			while (currentNode != null)
			{
				if (currentNode.Equals(item))
				{
					return true;
				}

				currentNode = currentNode.Next;
			}
			return false;
		}
	}
}
