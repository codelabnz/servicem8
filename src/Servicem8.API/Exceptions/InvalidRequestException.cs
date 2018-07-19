using System;
namespace Servicem8.API.Exceptions
{
    public class InvalidRequestException : RequestException
    {
        public InvalidRequestException()
        {
        }

        public InvalidRequestException(string message) : base(message)
        {
        }

        public InvalidRequestException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
