using System.Collections.Generic;
using ZAD.Domain.SeedWork;

namespace ZAD.Domain.ValueObjects
{
    public class Address : ValueObject
    {
        public string? Country { get; private set; }
        public string? City { get; private set; }
        public string? AddressAr { get; private set; }
        public string? AddressEn { get; private set; }

        private Address() { } 

        public Address(string? country, string? city, string? addressAr, string? addressEn)
        {
            Country = country;
            City = city;
            AddressAr = addressAr;
            AddressEn = addressEn;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Country ?? string.Empty;
            yield return City ?? string.Empty;
            yield return AddressAr ?? string.Empty;
            yield return AddressEn ?? string.Empty;
        }
    }
}
