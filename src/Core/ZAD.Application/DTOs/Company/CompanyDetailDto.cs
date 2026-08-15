using System.Collections.Generic;
using ZAD.Application.DTOs.Common;

namespace ZAD.Application.DTOs.Company
{
    public class CompanyDetailDto
    {
        public int Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public string NameAr { get; set; } = string.Empty;
        public string NameEn { get; set; } = string.Empty;

        public string? Country { get; set; }
        public string? City { get; set; }
        public string? AddressAr { get; set; }
        public string? AddressEn { get; set; }





        public string? Nationality { get; set; }
        public string? Language { get; set; }
        public string? LogoPath { get; set; }
        public bool IsActive { get; set; }

        public System.DateTime CreatedAt { get; set; }
        public System.DateTime? UpdatedAt { get; set; }

        public List<ContactDto> Contacts { get; set; } = new();
        public List<DocumentDto> Documents { get; set; } = new();
    }
}
