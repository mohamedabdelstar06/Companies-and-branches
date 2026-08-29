using System;
using System.Collections.Generic;
using ZAD.Domain.SeedWork;

namespace ZAD.Domain.ValueObjects
{
    public class EmailAddress : ValueObject
    {
        public string Value { get; private set; }

        private EmailAddress() 
        {
            Value = string.Empty;
        }

        public EmailAddress(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Email cannot be empty.");
            
            if (!value.Contains("@")) // Basic domain validation, can be improved in the future
            
                throw new ArgumentException("Invalid email format.");

            Value = value;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

        public override string ToString() => Value;
    }
}
