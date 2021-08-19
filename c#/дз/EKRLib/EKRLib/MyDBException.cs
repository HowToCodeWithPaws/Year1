using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EKRLib
{	[Serializable]
	public class MyDBException : Exception
	{
		public MyDBException() { }
		public MyDBException(string message) : base(message) { }
		public MyDBException(string message, Exception inner) : base(message, inner) { }
		protected MyDBException(
		  System.Runtime.Serialization.SerializationInfo info,
		  System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
	}
}
