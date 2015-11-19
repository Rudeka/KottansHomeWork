using System;

namespace Implementation
{
    public class BoardIsNotReadyException : Exception
    {
        public BoardIsNotReadyException()
        { }

        public BoardIsNotReadyException(string message) 
            : base(message)
        { }
    }
}