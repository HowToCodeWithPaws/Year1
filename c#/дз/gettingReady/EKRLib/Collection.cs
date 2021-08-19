using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace EKRLib
{
	[JsonObject] //newtonsoft
	public class Collection<T> : IEnumerable<T> where T : Item
	{
		List<T> items;

		public List<T> Items { get { return items; }}

		public Collection() { items = new List<T>(); }

		public void Add(T item) => items.Add(item);

		public IEnumerator<T> GetEnumerator() => new CollectionEnumerator<T>(items);

		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

		class CollectionEnumerator<U> : IEnumerator<U> where U : T
		{
			IEnumerator<U> col;

			public CollectionEnumerator(List<U> items)
			{
				col = items.Where(e => e.Weight > 0).GetEnumerator();
			}

			public U Current => col.Current;

			object IEnumerator.Current => Current;

			void IDisposable.Dispose() => col.Dispose();

			bool IEnumerator.MoveNext() => col.MoveNext();
			void IEnumerator.Reset() => col.Reset();
		}
	}
}
