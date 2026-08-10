using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using ZAD.Application.DTOs.Common;

namespace ZAD.Application.DTOs.Branch
{
    public class CreateBranchDto
    {
        public string Code { get; set; } = string.Empty;
        public string NameAr { get; set; } = string.Empty;
        public string NameEn { get; set; } = string.Empty;
        
        public int CompanyId { get; set; }

        public string? Country { get; set; }
        public string? City { get; set; }
        public string? AddressAr { get; set; }
        public string? AddressEn { get; set; }

        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? CostCenter { get; set; }
        public bool IsMainBranch { get; set; }

        public IFormFile? Logo { get; set; }

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
