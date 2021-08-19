using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EKRLib
{
	[Serializable]
	public class ItemsException : Exception
	{
		public ItemsException() { }
		public ItemsException(string message) : base(message) { }
		public ItemsException(string message, Exception inner) : base(message, inner) { }
		protected ItemsException(
		  System.Runtime.Serialization.SerializationInfo info,
		  System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
	}
}
