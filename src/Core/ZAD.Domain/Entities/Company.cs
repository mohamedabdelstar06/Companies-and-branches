using System.Collections.Generic;

namespace ZAD.Domain.Entities
{
    public class Company : BaseEntity
    {
        public string Code { get; set; } = string.Empty;
        public string NameAr { get; set; } = string.Empty;
        public string NameEn { get; set; } = string.Empty;
        public string? AddressAr { get; set; }
        public string? AddressEn { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Website { get; set; }
        public string? Country { get; set; }
        public string? City { get; set; }
        public string? Nationality { get; set; }
        public string? Language { get; set; }
        public string? LogoPath { get; set; }
        public bool IsActive { get; set; } = true;

        public ICollection<Branch> Branches { get; set; } = new List<Branch>();
    }
}
