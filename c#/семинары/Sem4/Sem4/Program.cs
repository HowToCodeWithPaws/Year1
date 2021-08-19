using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sem4
{
	class Transformator
	{
		private int number;
		public Transformator()
		{
			number = 0;
		}
		public Transformator(int number)
		{
			this.number = number;
		}

		public int Number//метод описыввающий свойство элемента класса, чтобы с ним можно было работать снаружи
		{
			

			get//получить информацию
			{
				Console.WriteLine("Trying to get Transformator.Number");
				return number;
			}
			set//положить информацию
			{
				if (value < 0)
				{
					throw new ArgumentOutOfRangeException();
				}
				number = value;
			}
		}
		public bool Transform()
		{
			string number = this.number.ToString();

			char[] digitArray = number.ToCharArray();
			Array.Sort(digitArray);

			return int.TryParse(new string(digitArray), out this.number);
		}
	//	public void foo(int bar = 5)
	//	{
	//		Console.WriteLine(bar);
	//	}
	//
	//	public void foo(int bar, int baz)
	//	{
	//		Console.WriteLine(bar + baz);
	//	}
}
	class Program
	{
		static void Main(string[] args)
		{
			Transformator transformator = new Transformator(189872);
			transformator.Transform();
			Console.WriteLine(transformator.Number);
	//		transformator.Number = 10;// обращение к свойству set
	//		transformator.foo(100);
	//		transformator.foo();
		}
	}
}

//методы, передача параметров в методы по ссылке, битовые операции
//инкапсуляция - свойство обЪекта, не меняющееся снаружи