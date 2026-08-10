using ZAD.Domain.Enums;
using ZAD.Domain.SeedWork;

namespace ZAD.Domain.Entities.Common
{
    public class Contact : Entity
    {
        public ContactType Type { get; private set; }
        public string Value { get; private set; } = string.Empty;
        public string Name { get; private set; } = string.Empty;

        private Contact() { } // EF Core

        public Contact(ContactType type, string value, string name)
        {
            Type = type;
            Value = value;
            Name = name;
        }

        public void Update(ContactType type, string value, string name)
        {
            Type = type;
            Value = value;
            Name = name;
        }
    }
}
