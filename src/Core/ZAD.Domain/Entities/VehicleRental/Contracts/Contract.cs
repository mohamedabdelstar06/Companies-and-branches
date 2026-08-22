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
    public class Contract : Entity
    {
        // Header
        public int? CompanyId { get; private set; }
        public Company? Company { get; private set; }

        public int? BranchId { get; private set; }
        public Branch? Branch { get; private set; }

        public int AccountingNo { get; private set; }
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
       
        public bool IsPosted { get; private set; }

        public decimal RemainingAmount { get; private set; }

        private Contract() { } 

     private void CalculateFields()
        {
            ActualPeriodInDays = Math.Max(0, (DateTime.Today - Date.Date).Days);
            DiscountAmount = RentPrice * DiscountPercent / 100m;
            NetRentPrice = RentPrice - DiscountAmount;
            DailyRate = DriverFare + (DriverWorkingHoursPerDay * DriverOvertimeAmountPerHour);
            RemainingAmount = NetRentPrice; // Default logic for now
        }  
        
         public Contract(
            int? companyId, int? branchId, int accountingNo, TimeSpan time, DateTime date, ContractType contractType, PaymentType paymentType, int periodInDays,
            TimeSpan expectedReceivingTime, DateTime expectedReceivingDate, bool withDriver, int? driverId,
            int tenantId, string? sponsorName, string? sponsorNationality, string? sponsorLicenseNumber, 
            DateTime? sponsorLicenseExpireDate, string? sponsorIdNumber, DateTime? sponsorIdExpireDate,
            string? secondDriverName, string? secondDriverNationality, string? secondDriverLicenseNumber,
            DateTime? secondDriverLicenseExpireDate, string? secondDriverIdNumber, DateTime? secondDriverIdExpireDate,
            int rentalVehicleId, int kilometerCounter, decimal rentPrice, decimal discountPercent, 
            decimal delayPenaltyPerHour, int allowedDelayHours, decimal maintenancePenalty, decimal accidentPenalty,
            decimal driverFare, int driverWorkingHoursPerDay, decimal driverOvertimeAmountPerHour,
            int kilometerPerDay, int maximumKilometerPerDay, decimal amountOfKmExceedingLimit,
            DeliveryStatus deliveryStatus = DeliveryStatus.Rented, ContractStatus status = ContractStatus.Draft, bool isPosted = false)
        {
            CompanyId = companyId;
            BranchId = branchId;
            AccountingNo = accountingNo;
            Time = time;
            Date = date;
            ContractType = contractType;
            PaymentType = paymentType;
            PeriodInDays = periodInDays;
            ExpectedReceivingTime = expectedReceivingTime;
            ExpectedReceivingDate = expectedReceivingDate;
            WithDriver = withDriver;
            DriverId = driverId;
            TenantId = tenantId;
            
            SponsorName = sponsorName;
            SponsorNationality = sponsorNationality;
            SponsorLicenseNumber = sponsorLicenseNumber;
            SponsorLicenseExpireDate = sponsorLicenseExpireDate;
            SponsorIdNumber = sponsorIdNumber;
            SponsorIdExpireDate = sponsorIdExpireDate;

            SecondDriverName = secondDriverName;
            SecondDriverNationality = secondDriverNationality;
            SecondDriverLicenseNumber = secondDriverLicenseNumber;
            SecondDriverLicenseExpireDate = secondDriverLicenseExpireDate;
            SecondDriverIdNumber = secondDriverIdNumber;
            SecondDriverIdExpireDate = secondDriverIdExpireDate;

            RentalVehicleId = rentalVehicleId;
            KilometerCounter = kilometerCounter;
            RentPrice = rentPrice;
            DiscountPercent = discountPercent;

            DelayPenaltyPerHour = delayPenaltyPerHour;
            AllowedDelayHours = allowedDelayHours;
            MaintenancePenalty = maintenancePenalty;
            AccidentPenalty = accidentPenalty;

            DriverFare = driverFare;
            DriverWorkingHoursPerDay = driverWorkingHoursPerDay;
            DriverOvertimeAmountPerHour = driverOvertimeAmountPerHour;

            KilometerPerDay = kilometerPerDay;
            MaximumKilometerPerDay = maximumKilometerPerDay;
            AmountOfKmExceedingLimit = amountOfKmExceedingLimit;



            DeliveryStatus = deliveryStatus;
            Status = status;
            IsPosted = isPosted;

            CalculateFields();
        }

        public void Update(
            int? companyId, int? branchId, int accountingNo, TimeSpan time, DateTime date, ContractType contractType, PaymentType paymentType, int periodInDays,
            TimeSpan expectedReceivingTime, DateTime expectedReceivingDate, bool withDriver, int? driverId,
            int tenantId, string? sponsorName, string? sponsorNationality, string? sponsorLicenseNumber, 
            DateTime? sponsorLicenseExpireDate, string? sponsorIdNumber, DateTime? sponsorIdExpireDate,
            string? secondDriverName, string? secondDriverNationality, string? secondDriverLicenseNumber,
            DateTime? secondDriverLicenseExpireDate, string? secondDriverIdNumber, DateTime? secondDriverIdExpireDate,
            int rentalVehicleId, int kilometerCounter, decimal rentPrice, decimal discountPercent, 
            decimal delayPenaltyPerHour, int allowedDelayHours, decimal maintenancePenalty, decimal accidentPenalty,
            decimal driverFare, int driverWorkingHoursPerDay, decimal driverOvertimeAmountPerHour,
            int kilometerPerDay, int maximumKilometerPerDay, decimal amountOfKmExceedingLimit,
            DeliveryStatus deliveryStatus, ContractStatus status, bool isPosted)
        {
            CompanyId = companyId;
            BranchId = branchId;
            AccountingNo = accountingNo;
            Time = time;
            Date = date;
            ContractType = contractType;
            PaymentType = paymentType;
            PeriodInDays = periodInDays;
            ExpectedReceivingTime = expectedReceivingTime;
            ExpectedReceivingDate = expectedReceivingDate;
            WithDriver = withDriver;
            DriverId = driverId;
            TenantId = tenantId;
            
            SponsorName = sponsorName;
            SponsorNationality = sponsorNationality;
            SponsorLicenseNumber = sponsorLicenseNumber;
            SponsorLicenseExpireDate = sponsorLicenseExpireDate;
            SponsorIdNumber = sponsorIdNumber;
            SponsorIdExpireDate = sponsorIdExpireDate;

            SecondDriverName = secondDriverName;
            SecondDriverNationality = secondDriverNationality;
            SecondDriverLicenseNumber = secondDriverLicenseNumber;
            SecondDriverLicenseExpireDate = secondDriverLicenseExpireDate;
            SecondDriverIdNumber = secondDriverIdNumber;
            SecondDriverIdExpireDate = secondDriverIdExpireDate;

            RentalVehicleId = rentalVehicleId;
            KilometerCounter = kilometerCounter;
            RentPrice = rentPrice;
            DiscountPercent = discountPercent;

            DelayPenaltyPerHour = delayPenaltyPerHour;
            AllowedDelayHours = allowedDelayHours;
            MaintenancePenalty = maintenancePenalty;
            AccidentPenalty = accidentPenalty;

            DriverFare = driverFare;
            DriverWorkingHoursPerDay = driverWorkingHoursPerDay;
            DriverOvertimeAmountPerHour = driverOvertimeAmountPerHour;

            KilometerPerDay = kilometerPerDay;
            MaximumKilometerPerDay = maximumKilometerPerDay;
            AmountOfKmExceedingLimit = amountOfKmExceedingLimit;



            DeliveryStatus = deliveryStatus;
            Status = status;
            IsPosted = isPosted;

            CalculateFields();
        }

        
    }
}
