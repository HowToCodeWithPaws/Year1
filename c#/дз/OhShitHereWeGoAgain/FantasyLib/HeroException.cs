using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyLib
{
	public class HeroException : Exception
	{
		public HeroException() { }
		public HeroException(string message) : base(message) { }
		public HeroException(string message, Exception inner) : base(message, inner) { }
		protected HeroException(
		  System.Runtime.Serialization.SerializationInfo info,
		  System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
	}
}
