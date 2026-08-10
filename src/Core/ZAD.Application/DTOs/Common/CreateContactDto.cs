using ZAD.Domain.Enums;

namespace ZAD.Application.DTOs.Common
{
    public class CreateContactDto
    {
        public ContactType Type { get; set; }
        public string Value { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
    }
}
