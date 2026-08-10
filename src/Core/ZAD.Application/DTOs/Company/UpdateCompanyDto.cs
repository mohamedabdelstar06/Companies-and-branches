using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using ZAD.Application.DTOs.Common;

namespace ZAD.Application.DTOs.Company
{
    public class UpdateCompanyDto
    {
        public int Id { get; set; }
        public string NameAr { get; set; } = string.Empty;
        public string NameEn { get; set; } = string.Empty;

        public string? Country { get; set; }
        public string? City { get; set; }
        public string? AddressAr { get; set; }
        public string? AddressEn { get; set; }

        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Website { get; set; }

        public string? Nationality { get; set; }
        public string? Language { get; set; }

        public IFormFile? Logo { get; set; }
        public bool IsActive { get; set; }

        // Contacts
        public List<ZAD.Domain.Enums.ContactType>? ContactTypes { get; set; }
        public List<string>? ContactValues { get; set; }
        public List<string>? ContactNames { get; set; }

        // Documents
        public List<ZAD.Domain.Enums.DocumentType>? DocumentTypes { get; set; }
        public List<string>? DocumentNumbers { get; set; }
        public List<IFormFile>? DocumentFiles { get; set; }
        public List<System.DateTime?>? DocumentExpiryDates { get; set; }
    }
}
