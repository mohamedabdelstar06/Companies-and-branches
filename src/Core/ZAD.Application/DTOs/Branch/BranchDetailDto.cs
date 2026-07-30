using System;

namespace ZAD.Application.DTOs.Branch
{
    public class BranchDetailDto
    {
        public int Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? AddressAr { get; set; }
        public string? AddressEn { get; set; }
        public string NameAr { get; set; } = string.Empty;
        public string NameEn { get; set; } = string.Empty;
        public int CompanyId { get; set; }
        public string CompanyName { get; set; } = string.Empty;
        public string? CostCenter { get; set; }
        public bool IsMainBranch { get; set; }
        public string? Country { get; set; }
        public string? City { get; set; }
        public string? LogoPath { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
