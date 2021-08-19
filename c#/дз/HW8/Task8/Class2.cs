using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task8
{
	class Student:Person
	{
		public string University { get; set; }
		public string Field { get; set; }

		public Student(string name, DateTime bday, string gender, string university, string field) : base(name, bday, gender)
		{
			University = university;
			Field = field;
		}

		public override void ShowInfo()
		{
			base.ShowInfo();
			Console.WriteLine($"University: {University}\nField of studies: {Field}");
		}
	}
}
