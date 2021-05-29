using System;

namespace Framework.Domain.Exceptions
{
    [Serializable]
    public class DomainException : Exception
    {
        public DomainException(string message) : base(message)
        {

        }
    }
}