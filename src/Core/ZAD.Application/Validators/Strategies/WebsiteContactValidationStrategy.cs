using System;

namespace ZAD.Application.Validators.Strategies
{
    public class WebsiteContactValidationStrategy : IContactValidationStrategy
    {
        public bool IsValid(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return false;

            bool result = Uri.TryCreate(value, UriKind.Absolute, out Uri? uriResult)
                && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);

            return result;
        }
    }
}
