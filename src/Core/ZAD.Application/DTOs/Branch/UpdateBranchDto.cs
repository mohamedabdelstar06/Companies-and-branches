using Microsoft.AspNetCore.Http;

namespace ZAD.Application.DTOs.Branch
{
    public class UpdateBranchDto
    {
        public int Id { get; set; }
        public string NameAr { get; set; } = string.Empty;
        public string NameEn { get; set; } = string.Empty;
        public string? AddressAr { get; set; }
        public string? AddressEn { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Country { get; set; }
        public string? City { get; set; }
        public string? CostCenter { get; set; }
        public bool IsMainBranch { get; set; }
        public bool IsActive { get; set; }
        public int CompanyId { get; set; }
        public IFormFile? Logo { get; set; }
    }
}
