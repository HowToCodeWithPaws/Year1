using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreLibrary
{
    /// <summary>
    /// Кастомный эксепшен для того, чтобы кидать при несоответствии параметров
    /// при задании свойств.
    /// </summary>
    [Serializable]
    public class BookstoreException : Exception
    {
        public BookstoreException() { }
        public BookstoreException(string message) : base(message) { }
        public BookstoreException(string message, Exception inner) : base(message, inner) { }
        protected BookstoreException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
