using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sem25
{
	class Exchange : IEnumerable<Company>
	{

		public string Name { get; }
		public List<Company> Companies { get; }

		public Exchange(string name, params Company[] companies) : this(name, new List<Company>(companies)) { }

		public Exchange(string name, List<Company> companies)
		{
			Name = name;
			Companies = companies;
		}

		public IEnumerator<Company> GetEnumerator()
		{
			return Companies.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return Companies.GetEnumerator();

			//for (int i = 0; i < Companies.Count; i++)
			//{
			//	var com = Companies[i];
			//	if (com.Name.Contains("Yandex"))
			//	{
			//		yield break;
			//	}
			//	yield return Companies[i];
			//}


			//foreach (var company in Companies)
			//{
			//	yield return company;
			//}
		}
	}
	public interface IValuable
	{
		decimal Value { get; }
	}

	public abstract class Valuable : IValuable, IComparable<Valuable>
	{
		public int CompareTo(Valuable other) { return Value.CompareTo(other.Value); }
		public Valuable(string name, decimal value)
		{
			Name = name ?? throw new ArgumentNullException(nameof(name));
			Value = value;
		}

		public string Name { get; set; }
		public decimal Value { get; set; }

		public override string ToString()
		{
			return $"Person {Name} with balance {Value}";
		}

		public static Valuable operator +(Valuable a, Company b)
		{
			b.Value += a.Value;
			return b;
		}
	}

	public class Company : Valuable, IComparable<Company>
	{
		public int CompareTo(Company other)
		{
			return Value.CompareTo(other.Value);
		}

		public Company(string name, decimal value) : base(name, value) { }

		public static bool operator >(Company a, Company b)
		{
			return a.CompareTo(b) > 0;
		}

		public static bool operator <(Company a, Company b)
		{
			return a.CompareTo(b) < 0;
		}

		public static bool operator ==(Company a, Company b)
		{
			return a.CompareTo(b) == 0;
		}

		public static bool operator !=(Company a, Company b)
		{
			return a.CompareTo(b) != 0;
		}

		public static Company operator +(IValuable a, Company b)
		{
			b.Value += a.Value;
			return b;
		}

		public override bool Equals(object obj)
		{
			return this == obj as Company;
		}

		public static Company operator +(Company a, IValuable b)
		{
			a.Value += b.Value;
			return a;
		}

		public static Company operator +(Company a, Company b)
		{
			string name;
			decimal value;

			if (a > b)
			{
				name = $"{b.Name} of {a.Name}";
				value = a.Value - b.Value;
			}
			else if (a < b)
			{

				name = $"{a.Name} of {b.Name}";

				value = b.Value - a.Value;
			}
			else
			{
				name = $"{b.Name} & {a.Name}";

				value = a.Value + b.Value;
			}

			return new Company(name, value);
		}

		public override string ToString()
		{
			return $"Company {Name} with balance {Value}";
		}
	}

	class RichGuy : Valuable
	{
		public RichGuy(string name, decimal value) : base(name, value) { }

		public static Company operator +(RichGuy a, Company b)
		{
			if (a.Value < b.Value)
			{
				return b;
			}

			a.Value -= b.Value;
			b.Name = $"{a.Name}'s {b.Name}";
			return b;
		}
	}
	public class Program
	{
		

		static void Main(string[] args)
		{
			Company sbrf = new Company("Sberbank", 2.4m * 1e12m);
			Company motherRussia = new Company("Russian Federation", 30e12m);
			Company yndx = new Company("Yandex", 0.67m * 1e12m);
			Company vtb= new Company("VTB", 0.67m * 1e12m);

			Exchange mscExc = new Exchange("Московская биржа", sbrf, yndx, vtb);

		//	Console.WriteLine(sbrf + motherRussia);

//			RichGuy billGates = new RichGuy("Bill Gates", 2345678987654322345678m);
//			Console.WriteLine(billGates + sbrf);

			//List<Company> sortedByCapitalization = new List<Company>();

			//foreach (var company in mscExc)
			//{
			//	if (company.Value > 1e12m)
			//	{
			//		sortedByCapitalization.Add(company);
			//	}
			//	Console.WriteLine(company);
			//}

			//sortedByCapitalization.Sort((a, b) => { return a.Name.CompareTo(b.Name); });

			//Console.WriteLine(string.Join(Environment.NewLine, sortedByCapitalization));

			//var sortedCompaniesTrillion = from company in mscExc 
			//							  where company.Value>1e12m 
			//							  orderby company.Name descending 
			//							  select company;

			var ext = mscExc.Where(company => company.Value > 1e9m).OrderBy(company => company.Name);

			var avVal = ext.Average(company => company.Value);

			Console.WriteLine(avVal);

			var hugeCompany = ext.Aggregate((x,y)=> x+y);
			Console.WriteLine(hugeCompany);
			//foreach (var item in sortedCompaniesTrillion)
			//{
			//	Console.WriteLine(item);
			//}
		}
	}
}
