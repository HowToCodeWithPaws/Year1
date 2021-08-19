using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
	class Birthday
	{
		string name; // закрытое поле - фамилия
		int year, month, day; // Закрытые поля: год, месяц, день рождения

		public Birthday(string name) : this("Another", 1970, 1, 1)
		{
		}
		public Birthday(string name, int y = 1970, int m = 1, int d = 1)
		{ // Конструктор
			this.name = name;
			year = y; month = m; day = d;
		}

		DateTime Date
		{ // закрытое свойство - дата рождения
			get { return new DateTime(year, month, day); }
		}
		public string Information
		{   // свойство - сведения о человеке
			get
			{
				return name + ", дата рождения " + day + ":" + month + ":" + year;
			}
		}


		public string Info1
		{
			get
			{
				string Day = day < 10 ? "0" + day.ToString() : day.ToString();
				string Month = month < 10 ? "0" + month.ToString() : month.ToString();
				string Year = (year.ToString()[2]).ToString()+ year.ToString()[3];
				return Day + "-" + Month + "-" + Year;
			}
		}

		public string Info2
		{
			get
			{
				return $"{Date:D}";
			}
		}
		public int HowManyDays
		{ // свойство - сколько дней до дня рождения
			get
			{
				// номер сего дня от начала года:
				int nowDOY = DateTime.Now.DayOfYear;
				//  номер дня рождения от начала года: 
				int myDOY = Date.DayOfYear;
				int period = myDOY >= nowDOY ? myDOY - nowDOY :
											   365 - nowDOY + myDOY;
				return period;
			}
		}

		class Program
		{
			static void Main(string[] args)
			{
				Birthday me = new Birthday("Nat", 2001, 5, 4);
				Console.WriteLine(me.Information);
				Console.WriteLine("До следующего дня рождения дней осталось: ");
				Console.WriteLine(me.HowManyDays);

				Console.WriteLine("\nAlternatively");
				Console.WriteLine(me.Info1);
				Console.WriteLine(me.Info2);

				Birthday notme = new Birthday("Another");
				Console.WriteLine("\n"+notme.Information);
				Console.WriteLine("До следующего дня рождения дней осталось: ");
				Console.WriteLine(notme.HowManyDays);
			}
		}
	}
}