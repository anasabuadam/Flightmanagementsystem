using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Flightmanagementsystem.Exceptions
{
    internal class AdminAlreadyExistsException : Exception
    {
        public AdminAlreadyExistsException()
        {
        }
        public AdminAlreadyExistsException(string message) : base(message)
        {
        }
        public AdminAlreadyExistsException(string message, Exception innerException) : base(message, innerException)
        {
        }
        protected AdminAlreadyExistsException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
        

    }
}
