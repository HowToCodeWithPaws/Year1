using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task8
{
	class Program
	{
		static void Main(string[] args)
		{
			Person firstPerson = new Person("Adam", DateTime.MinValue, "male");
			Student firstStudent = new Student("PoorSoul", DateTime.Parse("04.05.2001"), "students have no gender only anxiety", "Oxford", "Mathematics");
			Employee firstEmployee = new Employee("Valentina Tereshkova",DateTime.Parse("06.03.1937") , "female", "Vostok-6", "3 days", decimal.MaxValue);

			firstPerson.ShowInfo();
			firstStudent.ShowInfo();
			firstEmployee.ShowInfo();

			Person[] people = new Person[3];
			people[0] = firstPerson;
			people[1] = firstStudent;
			people[2] = firstEmployee;

			Console.WriteLine("\nnow in array\n");

			for (int i = 0; i < people.Length; i++)
			{
				people[i].ShowInfo();
			}
		}

	}
}
