using System;

namespace ZAD.Application.DTOs.Company
{
    public class CompanyDetailDto
    {
        public int Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? AddressAr { get; set; }
        public string? AddressEn { get; set; }
        public string NameAr { get; set; } = string.Empty;
        public string NameEn { get; set; } = string.Empty;
        public string? Website { get; set; }
        public string? Country { get; set; }
        public string? City { get; set; }
        public string? Nationality { get; set; }
        public string? Language { get; set; }
        public string? LogoPath { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
