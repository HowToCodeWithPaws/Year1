using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Собственный класс исключений, относящихся к питомцам.
/// </summary>
namespace PetLib
{
	[Serializable]
	public class PetException : Exception
	{
		public PetException() { }
		public PetException(string message) : base(message) { }
		public PetException(string message, Exception inner) : base(message, inner) { }
		protected PetException(
		  System.Runtime.Serialization.SerializationInfo info,
		  System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
	}
}
