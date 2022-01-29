using System;
using System.Runtime.Serialization;

namespace Flightmanagementsystem.Exceptions
{
    [Serializable]
    internal class CountryAlreadyExistsException : Exception
    {
        public CountryAlreadyExistsException()
        {
        }

        public CountryAlreadyExistsException(string message) : base(message)
        {
        }

        public CountryAlreadyExistsException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected CountryAlreadyExistsException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
