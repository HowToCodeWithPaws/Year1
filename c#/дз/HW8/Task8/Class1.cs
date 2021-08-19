using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task8
{
	class Person
	{
		public string FullName { get; private set; }
		public DateTime BirthDate { get; private set; }
		public string Gender { get; private set; }

		public Person(string name, DateTime bday, string gender)
		{
			FullName = name;
			BirthDate = bday;
			Gender = gender;
		}

		public virtual void ShowInfo()
		{
			Console.WriteLine($"\nName: {FullName}\nDate of birth: {BirthDate}\nGender identity: {Gender}");
		}
	}
}
