using System;

namespace MessengerWebAPI.Exceptions
{
    public class ModelNotFoundException : Exception
    {
        public ModelNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
