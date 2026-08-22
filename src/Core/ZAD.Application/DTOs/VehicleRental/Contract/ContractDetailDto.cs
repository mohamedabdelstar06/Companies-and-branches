using System;
using ZAD.Domain.Enums.VehicleRental;

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

        public TimeSpan Time { get; set; }
        public DateTime Date { get; set; }
        public ContractType ContractType { get; set; }
        public int PeriodInDays { get; set; }
        public int ActualPeriodInDays { get; set; }
        public TimeSpan ExpectedReceivingTime { get; set; }
        public DateTime ExpectedReceivingDate { get; set; }
        public bool WithDriver { get; set; }
        public int? DriverId { get; set; }
        public string? DriverName { get; set; }

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

        // Vehicle Info
        public int RentalVehicleId { get; set; }
        public string? PlateNo { get; set; }
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


    }
}
