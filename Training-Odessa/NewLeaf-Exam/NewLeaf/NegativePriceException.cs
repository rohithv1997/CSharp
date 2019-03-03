using System;
using System.Runtime.Serialization;

namespace NewLeaf
{
    [Serializable]
    internal class NegativePriceException : Exception
    {
        public NegativePriceException()
        {
        }

        public NegativePriceException(string message) : base(message)
        {
            Console.WriteLine(Message);
        }

        public NegativePriceException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NegativePriceException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}