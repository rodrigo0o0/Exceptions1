using System;


namespace Exception1.Entities.Exceptions
{
    internal class DomainException : ApplicationException
    {

        public DomainException(string message) : base(message)
        {
        }

    
    }
}
