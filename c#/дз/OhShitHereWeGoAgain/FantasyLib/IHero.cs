using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyLib
{
	public interface IHero:IComparable<IHero>
	{
		string Name { get; set; }

		double Damage { get; set; }

		DateTime DateOfCreation { get; }
	}
}
