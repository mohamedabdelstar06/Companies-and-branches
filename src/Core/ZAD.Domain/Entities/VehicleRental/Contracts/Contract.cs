using System;
using ZAD.Domain.Enums.VehicleRental;
using ZAD.Domain.SeedWork;
using ZAD.Domain.Entities.VehicleRental.Tenants;
using ZAD.Domain.Entities.VehicleRental.Drivers;
using ZAD.Domain.Entities.VehicleRental.Vehicles;
using ZAD.Domain.Entities.Companies;
using ZAD.Domain.Entities.Branches;

namespace ZAD.Domain.Entities.VehicleRental.Contracts
{
    public partial class Contract : Entity
    {
        // Header
        public int? CompanyId { get; private set; }
        
        public Company? Company { get; private set; }

        public int? BranchId { get; private set; }
        
        public Branch? Branch { get; private set; }

        public TimeSpan Time { get; private set; }

        public DateTime Date { get; private set; }
        
        public ContractType ContractType { get; private set; }
        public PaymentType PaymentType { get; private set; }
        
        public int PeriodInDays { get; private set; }
        
        public int ActualPeriodInDays { get; private set; }
        
        public TimeSpan ExpectedReceivingTime { get; private set; }
        
        public DateTime ExpectedReceivingDate { get; private set; }
        
        public bool WithDriver { get; private set; }
        
        
        public int? DriverId { get; private set; }
        
        public Driver? Driver { get; private set; }

        public int TenantId { get; private set; }

        public Tenant? Tenant { get; private set; }
        // Sponsor (Part of Tenant Tab)
        public string? SponsorName { get; private set; }
        
        public string? SponsorNationality { get; private set; }
        
        public string? SponsorLicenseNumber { get; private set; }
        
        public DateTime? SponsorLicenseExpireDate { get; private set; }
        
        public string? SponsorIdNumber { get; private set; }
        
        public DateTime? SponsorIdExpireDate { get; private set; }
        
        // Second Driver
        public string? SecondDriverName { get; private set; }
        
        public string? SecondDriverNationality { get; private set; }
        
        public string? SecondDriverLicenseNumber { get; private set; }
        
        public DateTime? SecondDriverLicenseExpireDate { get; private set; }
        
        public string? SecondDriverIdNumber { get; private set; }
        public DateTime? SecondDriverIdExpireDate { get; private set; }
        // Vehicle Info
        public int RentalVehicleId { get; private set; }
        
        public RentalVehicle? RentalVehicle { get; private set; }

        public int KilometerCounter { get; private set; }
        
        public decimal RentPrice { get; private set; }
        
        public decimal DiscountPercent { get; private set; }
        
        public decimal DiscountAmount { get; private set; }
        
        public decimal NetRentPrice { get; private set; }
        // Penalties
        public decimal DelayPenaltyPerHour { get; private set; }
        
        public int AllowedDelayHours { get; private set; }
        
        public decimal MaintenancePenalty { get; private set; }
        
        public decimal AccidentPenalty { get; private set; }

        // Private Driver
        
        public decimal DriverFare { get; private set; }
        
        public int DriverWorkingHoursPerDay { get; private set; }
        
        public decimal DriverOvertimeAmountPerHour { get; private set; }
        
        public decimal DailyRate { get; private set; }

        // KM / Day
        
        public int KilometerPerDay { get; private set; }
        
        public int MaximumKilometerPerDay { get; private set; }
        
        public decimal AmountOfKmExceedingLimit { get; private set; }

        // Status and Payment
        public DeliveryStatus DeliveryStatus { get; private set; }
        
        public ContractStatus Status { get; private set; }

        public decimal RemainingAmount { get; private set; }

        // Receiving Fields
        public DateTime? ReceivingDate { get; private set; }
        
        public TimeSpan? ReceivingTime { get; private set; }
        
        public int? ReceivingKilometerCounter { get; private set; }
        
        public bool? ReceiveProofDocuments { get; private set; }
        
        public string? ReceiveNotes { get; private set; }
        
        public decimal MaintenancePaidByTenant { get; private set; }
        
        public bool IsMaintenanceDoneByTenant { get; private set; }
        
        public VehicleReceivingStatus? VehicleReceivingStatus { get; private set; }
        
        public bool IsVehicleStoppedUntilMaintenanceOrRepair { get; private set; }
        
        public string? DamageNote { get; private set; }
        
        public decimal ReceiveDiscountAmount { get; private set; }
        // Computed Receiving Totals
        public int? DelayHours { get; private set; }
        
        public int? TotalConsumptionKilometers { get; private set; }
        
        public int? FreeKM { get; private set; }
        
        public int? KMExceededTheLimit { get; private set; }
        
        public decimal? TotalAmountOfKMExceedingTheLimit { get; private set; }
        
        public decimal? DelayPenaltyAmount { get; private set; }
        
        public decimal? TotalRentalAmount { get; private set; }
        
        public decimal? TotalDriverAmount { get; private set; }
        
        public decimal? TotalDueAmount { get; private set; }

        public decimal? FinalNetDueAmount { get; private set; } // Distinct from existing NetRentPrice

    }
}
