using System;
using ZAD.Domain.Enums.VehicleRental;

namespace ZAD.Domain.Entities.VehicleRental.Contracts
{
    public partial class Contract
    {
        private Contract() { } 

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

        private void CalculateFields()
        {
            ActualPeriodInDays = Math.Max(0, (DateTime.Today - Date.Date).Days);
            DiscountAmount = RentPrice * DiscountPercent / 100m;
            NetRentPrice = RentPrice - DiscountAmount;
            DailyRate = DriverFare + (DriverWorkingHoursPerDay * DriverOvertimeAmountPerHour);
            RemainingAmount = NetRentPrice; // Default logic for now

            var startDateTime = Date.Date + Time;
            DateTime expectedDateTime = startDateTime;

            switch (ContractType)
            {
                case ContractType.Daily:
                    expectedDateTime = startDateTime.AddDays(PeriodInDays);
                    break;
                case ContractType.Weekly:
                    expectedDateTime = startDateTime.AddDays(PeriodInDays * 7);
                    break;
                case ContractType.Monthly:
                    expectedDateTime = startDateTime.AddMonths(PeriodInDays);
                    break;
                case ContractType.LongTerm:
                    expectedDateTime = startDateTime.AddYears(PeriodInDays);
                    break;
                case ContractType.Hourly:
                    expectedDateTime = startDateTime.AddHours(PeriodInDays);
                    break;
            }

            ExpectedReceivingDate = expectedDateTime.Date;
            ExpectedReceivingTime = expectedDateTime.TimeOfDay;
        }
    }
}
