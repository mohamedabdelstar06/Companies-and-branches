namespace ZAD.Application.Strategies.ContactValidation
{
    public class DefaultContactValidationStrategy : IContactValidationStrategy
    {
        public bool IsValid(string value)
        {
            // For general contact types where we don't have a specific format requirement,
            // we just ensure it's not empty.
            return !string.IsNullOrWhiteSpace(value);
        }
    }
}

