using System;
using System.Runtime.Serialization;

namespace Flightmanagementsystem.Exceptions
{
    [Serializable]
    internal class FlightNotFoundException : Exception
    {
        public FlightNotFoundException()
        {
        }

        public FlightNotFoundException(string message) : base(message)
        {
        }

        public FlightNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected FlightNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
