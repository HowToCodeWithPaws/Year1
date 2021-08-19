using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DumbCollection
{
	/// <summary>
	/// Очень странный класс, если бы мы 
	/// знали, что это такое, но мы не знаем,
	/// что это такое. Нужен чтобы понимать, есть
	/// ли информация в ноде и отлична ли она от 
	/// значения по умолчанию.
	/// </summary>
	/// <typeparam name="T"> Обобщение типа. 
	/// </typeparam>
	public class Optional<T>
	{
		// Свойство того, задавалось ли значение, изначально false.
		public bool IsPresent { get; private set; } = false;

		// Поле для значения
		private T value;

		/// <summary>
		/// Свойство для значения, сеттер с изменением 
		/// того, задавалось ли значение и проверкой на null.
		/// </summary>
		public T Value
		{
			get { return value; }
			set
			{
				IsPresent = value != null;
				this.value = value;
			}
		}

		/// <summary>
		/// Конструктор с параметрами - значением.
		/// </summary>
		/// <param name="value"> Значение. </param>
		public Optional(T value)
		{
			Value = value;
		}

		/// <summary>
		/// Конструктор без параметров.
		/// </summary>
		private Optional() { }

		/// <summary>
		/// Статический метод, возвращающий 
		/// пустой дефолтный объект.
		/// </summary>
		/// <returns> Возвращает экземпляр класса,
		/// сделанный с помощью конструктора без 
		/// параметров - значение null и флаг 
		/// заполнения false. </returns>
		public static Optional<T> Empty()
		{ return new Optional<T>(); }
	}
}
