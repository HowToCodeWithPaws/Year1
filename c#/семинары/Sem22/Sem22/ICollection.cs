using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sem22
{
	public interface ICollection<in T>
	{
		void Add(T item);

		void RemoveAt(int index);

		bool Contains(T item);
	}
}
