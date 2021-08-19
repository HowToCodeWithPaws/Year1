using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sem22
{
	public class Node<T> : IEquatable<T>
	{
		public T Data { get; set; }

		public Node<T> Next { get; set; }

		public Node<T> Previous { get; set; }

		public Node(T data, Node<T> previous = null, Node<T> next = null)
		{
			Data = data;
			Next = next;
			Previous = previous;
		}

		public bool Equals(T other)
		{
			return Data.Equals(other);
		}
	}
}
