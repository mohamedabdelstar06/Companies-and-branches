using System;
using ZAD.Domain.Enums.VehicleRental;

namespace ZAD.Application.DTOs.VehicleRental.Contract
{
    public class ContractListDto
    {
        public int Id { get; set; }
        public int AccountingNo { get; set; }
        public int? CompanyId { get; set; }
        public int? BranchId { get; set; }
        public string CompanyName { get; set; } = string.Empty;
        public string BranchName { get; set; } = string.Empty;
        public string PlateNo { get; set; } = string.Empty;
        public string Brand { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public DateTime ToDate { get; set; }
        public int PeriodInDays { get; set; }
        public int ActualPeriodInDays { get; set; }
        public string ContractType { get; set; } = string.Empty;
        public string TenantName { get; set; } = string.Empty;
        public decimal RemainingAmount { get; set; }
        public string DeliveryStatus { get; set; } = string.Empty;
        public string IsPosted { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
    }
}
