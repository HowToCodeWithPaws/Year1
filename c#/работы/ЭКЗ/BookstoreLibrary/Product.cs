using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreLibrary
{
	/// <summary>
	/// Класс продукта, содержащего цену и название 
	/// (которое никому не нужно в этом классе), умеет
	/// сравниваться со своим же типом.
	/// </summary>
	[DataContract]
	public class Product : IComparable<Product>
	{
		/// <summary>
		/// Поля для цены и тайтла.
		/// </summary>
		double price;
		string title;

		/// <summary>
		/// Свойство для цены с проверкой корректности знаечения в сеттере.
		/// </summary>
		[DataMember]
		public double Price
		{
			get => price;
			set
			{
				if (value <= 0)
				{
					throw new BookstoreException($"Стоимость не может быть" +
						$" отрицательной или нулевой: {value}");
				}

				price = value;
			}
		}


		/// <summary>
		/// Свойство для тайтла с проверкой корректности знаечения в сеттере.
		/// </summary>
		[DataMember]
		public string Title
		{
			get => title;
			set
			{
				if (string.IsNullOrEmpty(value))
				{
					throw new BookstoreException("Имя товара не может быть пустым");
				}

				title = value;
			}
		}

		/// <summary>
		/// Конструктор с параметрами.
		/// </summary>
		/// <param name="title_"> Параметр названия. </param>
		/// <param name="price_"> Параметр цены. </param>
		public Product(string title_, double price_)
		{
			Title = title_;
			Price = price_;
		}

		/// <summary>
		/// Реализация интерфейса сравнения по сравнению цены.
		/// </summary>
		/// <param name="product"> Объект с которым сравниваем. </param>
		/// <returns></returns>
		public int CompareTo(Product product) => this.Price.CompareTo(product.Price);

		/// <summary>
		/// Переопределение метода Тустринг на нужный формат (без названия ну и ладно).
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return $"Price = ${Price:F2}";
		}

		/// <summary>
		/// Определение явного приведения к типу дабл по цене.
		/// </summary>
		/// <param name="product"></param>
		public static explicit operator double(Product product) => product.Price;
	}
}
