using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sem22
{
	public interface IIndex<out T>
	{
		T this[int index] { get; }
	}
}
