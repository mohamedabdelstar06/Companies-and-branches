using System.Text.RegularExpressions;

namespace ZAD.Application.Validators.Strategies
{
    public class EmailContactValidationStrategy : IContactValidationStrategy
    {
        private static readonly Regex EmailRegex = new Regex(
            @"^[^@\s]+@[^@\s]+\.[^@\s]+$", 
            RegexOptions.Compiled | RegexOptions.IgnoreCase);

        public bool IsValid(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return false;

            return EmailRegex.IsMatch(value);
        }
    }
}
