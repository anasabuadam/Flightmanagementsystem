using System;
using System.Runtime.Serialization;

namespace Flightmanagementsystem.Exceptions
{
    [Serializable]
    internal class WrongPasswordException : Exception
    {
        public WrongPasswordException()
        {
        }

        public WrongPasswordException(string message) : base(message)
        {
        }

        public WrongPasswordException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected WrongPasswordException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
