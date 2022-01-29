using System;
using System.Runtime.Serialization;

namespace Flightmanagementsystem.Exceptions
{
    [Serializable]
    internal class TicketAlreadyExistsException : Exception
    {
        public TicketAlreadyExistsException()
        {
        }

        public TicketAlreadyExistsException(string message) : base(message)
        {
        }

        public TicketAlreadyExistsException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected TicketAlreadyExistsException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
