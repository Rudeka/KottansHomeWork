using System;
using System.Runtime.Serialization;


namespace Implementation
{
    [Serializable]
    public class NotAShipException : Exception
    {

        public NotAShipException()
        { }

        public NotAShipException(string message) 
        : base(message)
    { }

        public NotAShipException(string message, Exception innerException)
        : base (message, innerException)
    { }

        protected NotAShipException(SerializationInfo info, StreamingContext context)
        : base (info, context)
    { }

    }
}