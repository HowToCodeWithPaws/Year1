using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyLib
{
	public class Mage : IHero
	{
		string name;
		double damage;
		DateTime dateOfCreation;

		public string Name {
			get
			{
				return name;
			}
			set
			{
				if (!(3 <= value.Length && value.Length <= 10)
					|| !value.Substring(1).All(a => 'a' <= a && a <= 'z')
					|| !('A' <= value[0] && value[0] <= 'Z'))
				{
					throw new HeroException($"Недопустимая кличка {value}");
				}

				name = value;
			}
		}

		public double Damage
		{
			get
			{
				return damage;
			}
			set
			{
				if (value < 0)
				{
					throw new HeroException("урон не может быть отрицательным");
				}

				damage = value;
			}
		}

		public DateTime DateOfCreation { get { return dateOfCreation; } set { dateOfCreation = value; } }

		public int CompareTo(IHero other)
		{
			if (Damage.CompareTo(other.Damage) == 0)
			{
				return DateOfCreation.CompareTo(other.DateOfCreation);
			}
			return Damage.CompareTo(other.Damage);
		}

		public Mage(string name_, double damage_)
		{
			Name = name_;
			Damage = damage_;
		}

		public override string ToString()
		{
			return $"Mage name: {Name}, damage: {Damage:F2}, creation: {DateOfCreation}";
		}
	}
}
