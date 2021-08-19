using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5
{
	class Library
	{
		Book[] library;

		public Library() : this(null) { }

		public int NumberOfBooks { get; set; }

		public Library(Book[] array)
		{
			library = new Book[array.Length];
			for (int i = 0; i < array.Length; i++)
			{
				library[i] = array[i];
			}
			NumberOfBooks = 0;
			NumberOfBooks += array.Length;
		}

		public void IncreaseSize(ref Book[] library)
		{
			Book[] libraryLarge = new Book[2 * NumberOfBooks];
			for (int i = 0; i < NumberOfBooks; i++)
			{
				libraryLarge[i] = library[i];
			}

			library = libraryLarge;
		}

		public void AddBook(Book book)
		{
			if (library.Length == NumberOfBooks)
			{
				IncreaseSize(ref library);
			}

			library[NumberOfBooks] = book;

			NumberOfBooks++;
		}

		public void LibrarySort()
		{
			for (int j = 0; j < NumberOfBooks; j++)
			{
				for (int i = 0; i < NumberOfBooks - 1; i++)
				{
					if (library[i].SectionNumber > library[i + 1].SectionNumber)
					{
						Book temp = library[i];
						library[i] = library[i + 1];
						library[i + 1] = temp;
					}
				}
			}

		}

		public override string ToString()
		{
			LibrarySort();
			string info = $"В данной библиотеке {NumberOfBooks} книг, а ее размер {library.Length}";
			
			for (int i = 0;i<NumberOfBooks;i++)
			{
			
				info += $"\n\nНа {i} месте лежит книга {library[i].ToString()}";
			}

			return info;
		}

		public string GetBooksWithLessAmountOfPages(int n)
		{
			LibrarySort();
			string result = $"\n\nКниги с количеством страниц меньшим чем {n}";

			for (int i = 0; i < library.Length; i++)
			{
				if (library[i].CountPages < n)
				{
					result += library[i].ToString();
				}
			}

			return result;
		}

		public Book this[int index]
		{
			get { return library[index]; }
		}
	}
}
