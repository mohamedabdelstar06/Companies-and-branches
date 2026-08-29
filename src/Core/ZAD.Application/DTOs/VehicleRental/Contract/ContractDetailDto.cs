using System;

namespace ZAD.Application.DTOs.VehicleRental.Contract
{
    public class ContractDetailDto
    {
        public int Id { get; set; }

        // Header
        public int? CompanyId { get; set; }
        public string? CompanyName { get; set; }
        public int? BranchId { get; set; }
        public string? BranchName { get; set; }

        public string? ReferenceNo { get; set; }

        public TimeSpan Time { get; set; }
        public DateTime Date { get; set; }
        public string? Day { get; set; }

        public int ContractType { get; set; }
        public string? ContractTypeName { get; set; }

        public int PaymentType { get; set; }
        public string? PaymentTypeName { get; set; }

        public int PeriodInDays { get; set; }
        public int ActualPeriodInDays { get; set; }

        public TimeSpan ExpectedReceivingTime { get; set; }
        public DateTime ExpectedReceivingDate { get; set; }
        public string? ExpectedReceivingDay { get; set; }

        public bool WithDriver { get; set; }
        public int? DriverId { get; set; }
        public string? DriverName { get; set; }

        // Status
        public string? Status { get; set; }
        public string? DeliveryStatus { get; set; }

        public decimal RemainingAmount { get; set; }

        // Tenant
        public int TenantId { get; set; }
        public string? TenantName { get; set; }

        // Sponsor (Part of Tenant Tab)
        public string? SponsorName { get; set; }
        public string? SponsorNationality { get; set; }
        public string? SponsorLicenseNumber { get; set; }
        public DateTime? SponsorLicenseExpireDate { get; set; }
        public string? SponsorIdNumber { get; set; }
        public DateTime? SponsorIdExpireDate { get; set; }

        // Second Driver
        public string? SecondDriverName { get; set; }
        public string? SecondDriverNationality { get; set; }
        public string? SecondDriverLicenseNumber { get; set; }
        public DateTime? SecondDriverLicenseExpireDate { get; set; }
        public string? SecondDriverIdNumber { get; set; }
        public DateTime? SecondDriverIdExpireDate { get; set; }

        // Vehicle Info
        public int RentalVehicleId { get; set; }
        public string? PlateNo { get; set; }
        public string? Brand { get; set; }
        public int? ModelYear { get; set; }
        public string? FileNo { get; set; }
        public int KilometerCounter { get; set; }
        public decimal RentPrice { get; set; }
        public decimal DiscountPercent { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal NetRentPrice { get; set; }

        // Penalties
        public decimal DelayPenaltyPerHour { get; set; }
        public int AllowedDelayHours { get; set; }
        public decimal MaintenancePenalty { get; set; }
        public decimal AccidentPenalty { get; set; }

        // Private Driver
        public decimal DriverFare { get; set; }
        public int DriverWorkingHoursPerDay { get; set; }
        public decimal DriverOvertimeAmountPerHour { get; set; }
        public decimal DailyRate { get; set; }

        // KM / Day
        public int KilometerPerDay { get; set; }
        public int MaximumKilometerPerDay { get; set; }
        public decimal AmountOfKmExceedingLimit { get; set; }

        // Metadata
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        // Receiving Fields
        public DateTime? ReceivingDate { get; set; }
        public TimeSpan? ReceivingTime { get; set; }
        public int? ReceivingKilometerCounter { get; set; }
        public bool? ReceiveProofDocuments { get; set; }
        public string? ReceiveNotes { get; set; }
        public decimal MaintenancePaidByTenant { get; set; }
        public decimal ReceiveDiscountAmount { get; set; }
        
        public bool IsMaintenanceDoneByTenant { get; set; }
        public ZAD.Domain.Enums.VehicleRental.VehicleReceivingStatus? VehicleReceivingStatus { get; set; }
        public bool IsVehicleStoppedUntilMaintenanceOrRepair { get; set; }
        public string? DamageNote { get; set; }

        public int? DelayHours { get; set; }
        public int? TotalConsumptionKilometers { get; set; }
        public int? FreeKM { get; set; }
        public int? KMExceededTheLimit { get; set; }
        public decimal? TotalAmountOfKMExceedingTheLimit { get; set; }
        public decimal? DelayPenaltyAmount { get; set; }
        public decimal? TotalRentalAmount { get; set; }
        public decimal? TotalDriverAmount { get; set; }
        public decimal? TotalDueAmount { get; set; }
        public decimal? FinalNetDueAmount { get; set; }
    }
}
