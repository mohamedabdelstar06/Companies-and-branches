namespace ZAD.Application.DTOs.Common
{
    public class PageQuery
    {
        public int PageIndex { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public string? SearchTerm { get; set; }
        public string? SortColumn { get; set; }
        public string? SortDirection { get; set; }
        public bool? IsActive { get; set; }
        public int? CompanyId { get; set; }
        public int? BranchId { get; set; }
    }
}
