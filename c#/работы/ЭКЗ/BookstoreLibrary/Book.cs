using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreLibrary
{
	/// <summary>
	/// Класс для книги, содержит дополнительную информацию о ней.
	/// </summary>
	[DataContract]
	public class Book : Product
	{
		/// <summary>
		/// Поля для количества страниц, года издания, рейтинга.
		/// </summary>
		short numberOfPages, year;
		double rating;

		/// <summary>
		/// Свойство для количества страниц с проверкой корректности значения в сеттере.
		/// </summary>
		[DataMember]
		public short NumberOfPages
		{
			get => numberOfPages;
			set
			{
				if (value <= 0)
				{
					throw new BookstoreException($"Количество страниц не может" +
						$" быть отрицательным или нулевым: {value}");
				}

				numberOfPages = value;
			}
		}

		/// <summary>
		/// Свойство для года с проверкой корректности значения в сеттере.
		/// </summary>
		[DataMember]
		public short Year
		{
			get => year;
			set
			{
				if (value < 1990 || value > 2020)
				{
					throw new BookstoreException($"Год издания не может быть таким: {value}");
				}

				year = value;
			}
		}

		/// <summary>
		/// Свойство для рейтинга с проверкой корректности значения в сеттере.
		/// </summary>
		[DataMember]
		public double Rating
		{
			get => rating;
			set
			{
				if (value < 0 || value > 5)
				{
					throw new BookstoreException($"Рейтинг не может быть таким: {value}");
				}

				rating = value;
			}
		}

		/// <summary>
		/// Конструктор с параметрами.
		/// </summary>
		/// <param name="title_"> Имя книги. </param>
		/// <param name="price_"> Цена книги. </param>
		/// <param name="pages_"> Количество страниц. </param>
		/// <param name="year_"> Год издания. </param>
		/// <param name="rating_"> Рейтинг. </param>
		public Book(string title_, double price_, short pages_, short year_,
			double rating_):base(title_, price_)
		{
			NumberOfPages = pages_;
			Year = year_;
			Rating = rating_;
		}

		/// <summary>
		/// Метод, возвращающий короткую информацию о книге.
		/// </summary>
		/// <returns></returns>
		public string GetShortInfo()
		{
			return $"{NumberOfPages}.{Year}.{Title.Distinct().Count()}." +
				$"{Rating.ToString("F2", CultureInfo.InvariantCulture).Replace(".", "")}";
		}

		/// <summary>
		/// Переопределение Тустринг с соответствующим форматированием данных о книге.
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return base.ToString() + $", Title = {Title}, NumberOfPAges = {NumberOfPages}," +
				$" Year = {Year}, Rating = {Rating:F2}, ShortInfo = {GetShortInfo()}";
		}
	}
}
