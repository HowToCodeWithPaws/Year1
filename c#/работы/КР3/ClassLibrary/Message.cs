using MessageLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;// json runtime

namespace MessageLib
{
	/// <summary>
	/// Класс для обычного сообщения.
	/// </summary>
	[Serializable]//binary
	[DataContract]
	public class Message
	{
		string content;

		/// <summary>
		/// Свойство для содержимого с проверкой корректности.
		/// </summary>
		[DataMember]
		public string Content
		{
			get => content;
			protected set
			{
				if (value == null) return;

				if (value.Length > 80)
				{
					throw new MessageException("Длина сообщения не" +
						" должна превышать 80 символов");
				}

				content = value;
			}
		}

		/// <summary>
		/// Свойство для времени отправки сообщения.
		/// </summary>

		[DataMember]
		public DateTime SendDate { get; protected set; }

		/// <summary>
		/// Свойство для времени получения сообщения.
		/// </summary>
		public virtual DateTime ReceiveDate { get => SendDate.AddSeconds(1); }


		/// <summary>
		/// Конструктор с параметрами.
		/// </summary>
		public Message(string content_, DateTime sendDate_)
		{
			Content = content_;
			SendDate = sendDate_;
		}

		/// <summary>
		/// Переопределенный метод ту стринг.
		/// </summary>
		/// <returns></returns>
		public override string ToString() => $"Mail: Content = {Content},\n" +
			$" SendDate = {SendDate:yyyy-MM-dd HH:mm:ss},\n " +
			$"ReceiveDate = {ReceiveDate:yyyy-MM-dd HH:mm:ss}";
	}
}
