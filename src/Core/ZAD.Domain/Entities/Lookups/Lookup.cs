using ZAD.Domain.SeedWork;

namespace ZAD.Domain.Entities.Lookups
{
    public class Lookup : Entity
    {
        public string LookupKey { get; private set; } = string.Empty;
        public string Culture { get; private set; } = string.Empty;
        public string Value { get; private set; } = string.Empty;

        private Lookup() { }

        public Lookup(string lookupKey, string culture, string value)
        {
            LookupKey = lookupKey;
            Culture = culture;
            Value = value;
        }

        public void Update(string value)
        {
            Value = value;
        }
    }
}
