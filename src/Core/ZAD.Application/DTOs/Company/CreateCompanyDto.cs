using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using ZAD.Application.DTOs.Common;
using ZAD.Domain.Enums;

namespace ZAD.Application.DTOs.Company
{
    public class CreateCompanyDto
    {
        public string Code { get; set; } = string.Empty;
        public string NameAr { get; set; } = string.Empty;
        public string NameEn { get; set; } = string.Empty;

        public string? Country { get; set; }
        public string? City { get; set; }
        public string? AddressAr { get; set; }
        public string? AddressEn { get; set; }





        public string? Nationality { get; set; }
        public string? Language { get; set; }

        public IFormFile? Logo { get; set; }

        public List<CreateContactDto>? Contacts { get; set; }
        public List<CreateDocumentDto>? Documents { get; set; }
    }
}
