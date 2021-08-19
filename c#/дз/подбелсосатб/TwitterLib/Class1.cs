using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitterLib
{

    [Serializable]
    public class TwitterException : Exception
    {
        public TwitterException() { }
        public TwitterException(string message) : base(message) { }
        public TwitterException(string message, Exception inner) : base(message, inner) { }
        protected TwitterException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
