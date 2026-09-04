using System.Text.RegularExpressions;

namespace ZAD.Application.Strategies.ContactValidation
{
    public class PhoneContactValidationStrategy : IContactValidationStrategy
    {
        private static readonly Regex PhoneRegex = new Regex(
            @"^\+?[1-9]\d{1,14}$", 
            RegexOptions.Compiled);

        public bool IsValid(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return false;

            // Optional: Basic phone number validation (E.164 format roughly)
            // or just allow standard digits, spaces, hyphens, and plus sign
            var cleanedValue = value.Replace(" ", "").Replace("-", "").Replace("(", "").Replace(")", "");
            return PhoneRegex.IsMatch(cleanedValue) || System.Text.RegularExpressions.Regex.IsMatch(cleanedValue, @"^\d+$");
        }
    }
}

