namespace ZAD.Application.DTOs.Company
{
    public class CompanyListDto
    {
        public int Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public string? Website { get; set; }
        public string? Logo { get; set; }
        public bool IsActive { get; set; }
    }
}
