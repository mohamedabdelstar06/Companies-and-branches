using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using ZAD.Application.DTOs.Common;

namespace ZAD.Application.DTOs.Branch
{
    public class UpdateBranchDto
    {
        public int Id { get; set; }
        public string NameAr { get; set; } = string.Empty;
        public string NameEn { get; set; } = string.Empty;
        
        public int CompanyId { get; set; }

        public string? Country { get; set; }
        public string? City { get; set; }
        public string? AddressAr { get; set; }
        public string? AddressEn { get; set; }



        public string? CostCenter { get; set; }
        public bool IsMainBranch { get; set; }

        public IFormFile? Logo { get; set; }
        public bool IsActive { get; set; }

        public List<CreateContactDto>? Contacts { get; set; }
        public List<CreateDocumentDto>? Documents { get; set; }
    }
}
