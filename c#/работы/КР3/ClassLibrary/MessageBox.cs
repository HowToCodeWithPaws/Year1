using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;// json runtime

namespace MessageLib
{
	/// <summary>
	/// Класс для коллекции сообщений.
	/// </summary>
	[Serializable]//binary
	[DataContract]
	[KnownType(typeof(Message))]
	[KnownType(typeof(Dmessage))]
	public class MessageBox : IEnumerable<Message>
	{
		[DataMember]
		List<Message> Messages { get; set; }

		/// Реализация интерфейса с сортировкой по дате.
		public IEnumerator<Message> GetEnumerator() =>
			Messages.OrderBy(message => message.ReceiveDate).GetEnumerator();

		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

		/// <summary>
		/// Метод добавления сообщения.
		/// </summary>
		/// <param name="msg"></param>
		public void ReceiveMail(Message msg) => Messages.Add(msg);

		/// <summary>
		///  Конструктор с параметрами.
		/// </summary>
		public MessageBox() { Messages = new List<Message>(); }
	}
}
