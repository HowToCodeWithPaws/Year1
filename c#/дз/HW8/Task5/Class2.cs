using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5
{
	class Book
	{
		private string _name;
		private int _countPages;
		private int _sectionNumber;

		public int CountPages
		{
			 get
			{
				return _countPages;
			}
			private set
			{
				_countPages = value;
			}
		}
		public int SectionNumber
		{
			get
			{
				return _sectionNumber;
			}
			private set
			{
				_sectionNumber = value;
			}
		}

		public string Name
		{
			get
			{
				return _name;
			}
			private set
			{
				_name = value;
			}
		}

		public Book(string name, int countPages, int sectionNumber)
		{
			Name = name;
			CountPages = countPages;
			SectionNumber = sectionNumber;
		}

		public override string ToString()
		{
			return $"\n\nНазвание книги: {Name}\nКоличество страниц: {CountPages}\nНомер секции: {SectionNumber}";
		}
	}
}
