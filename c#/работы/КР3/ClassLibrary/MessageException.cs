using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageLib
{
	[Serializable]
	public class MessageException : Exception
	{
		public MessageException() { }
		public MessageException(string message) : base(message) { }
		public MessageException(string message, Exception inner) : base(message, inner) { }
		protected MessageException(
		  System.Runtime.Serialization.SerializationInfo info,
		  System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
	}
}
