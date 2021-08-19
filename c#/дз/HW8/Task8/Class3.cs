using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task8
{
	class Employee:Person
	{
		public string Enterprise { get; set; }
		public string Shedule { get; set; }
		public decimal Salary { get; set; }

		public Employee(string name, DateTime bday, string gender, string enterprise, string shedule, decimal salary):base(name, bday, gender)
		{
			Enterprise = enterprise;
			Shedule = shedule;
			Salary = salary;
		}

		public override void ShowInfo()
		{
			base.ShowInfo();
			Console.WriteLine($"Works for: {Enterprise}\nWorking shedule: {Shedule}\nSalary: {Salary}");
		}
	}
}
