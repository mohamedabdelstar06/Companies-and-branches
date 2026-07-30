using System;

namespace ZAD.Application.Exceptions
{
    public class EntityDuplicatedException : Exception
    {
        public EntityDuplicatedException(string message) : base(message)
        {
        }
    }
}
