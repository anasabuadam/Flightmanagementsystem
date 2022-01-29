using System;
using System.Runtime.Serialization;

namespace Flightmanagementsystem.Exceptions
{
    [Serializable]
    internal class FlighAlreadyExistsException : Exception
    {
        public FlighAlreadyExistsException()
        {
        }

        public FlighAlreadyExistsException(string message) : base(message)
        {
        }

        public FlighAlreadyExistsException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected FlighAlreadyExistsException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
