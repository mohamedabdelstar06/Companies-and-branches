namespace ZAD.Application.DTOs.Branch
{
    public class BranchListDto
    {
        public int Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string CompanyName { get; set; } = string.Empty;
        public string? Address { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Logo { get; set; }
        public bool IsActive { get; set; }
    }
}
