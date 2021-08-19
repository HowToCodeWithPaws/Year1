using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;// json runtime

namespace MessageLib
{
	/// <summary>
	/// Класс для сообщения, отправляемого в прошлое.
	/// </summary>
	[Serializable]//binary
	[DataContract]
	public class Dmessage : Message
	{
		int hours;

		/// <summary>
		/// Свойство для разницы часов с проверкой корректности.
		/// </summary>
		[DataMember]
		public int Hours
		{
			get => hours; 
			set
			{
				if (value < 0)
				{
					throw new MessageException("Разница часов должна быть неотрицательная.");
				}

				hours = value;
			}
		}

		/// <summary>
		/// Свойство для времени получения сообщения.
		/// </summary>
		public override DateTime ReceiveDate { get => SendDate.AddHours(-Hours); }

		/// <summary>
		/// Конструктор с параметрами.
		/// </summary>
		public Dmessage(string content_, DateTime sendDate_, int hours_)
			: base(content_, sendDate_) { Hours = hours_; }

		/// <summary>
		/// Переопределенный метод ту стринг.
		/// </summary>
		/// <returns></returns>
		public override string ToString() => $"D-Message: Content = {Content},\n" +
		$" SendDate = {SendDate:yyyy-MM-dd HH:mm:ss},\n Hours = {Hours},\n " +
		$"ReceiveDate = {ReceiveDate:yyyy-MM-dd HH:mm:ss}";
	}
}
