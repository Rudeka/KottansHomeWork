using System;

namespace Implementation
{
    public class ShipOverlapException : Exception
    {
        public ShipOverlapException(string message) : base(message)
        {
        }
    }
}