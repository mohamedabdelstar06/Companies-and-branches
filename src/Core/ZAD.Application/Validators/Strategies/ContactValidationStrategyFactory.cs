using System;
using ZAD.Domain.Enums;

namespace ZAD.Application.Validators.Strategies
{
    public static class ContactValidationStrategyFactory
    {
        public static IContactValidationStrategy GetStrategy(ContactType type)
        {
            return type switch
            {
                ContactType.Email => new EmailContactValidationStrategy(),
                ContactType.Phone => new PhoneContactValidationStrategy(),
                ContactType.Whatsapp => new PhoneContactValidationStrategy(),
                ContactType.SMS => new PhoneContactValidationStrategy(),
                ContactType.Fax => new PhoneContactValidationStrategy(),
                ContactType.Website => new WebsiteContactValidationStrategy(),
                ContactType.Instagram => new WebsiteContactValidationStrategy(), // Assuming it's a URL
                _ => new DefaultContactValidationStrategy()
            };
        }
    }
}
