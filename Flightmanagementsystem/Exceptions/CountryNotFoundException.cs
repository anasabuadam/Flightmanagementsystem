using System;
using System.Runtime.Serialization;

namespace Flightmanagementsystem.Exceptions
{
    [Serializable]
    internal class CountryNotFoundException : Exception
    {
        public CountryNotFoundException()
        {
        }

        public CountryNotFoundException(string message) : base(message)
        {
        }

        public CountryNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected CountryNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

    }
}