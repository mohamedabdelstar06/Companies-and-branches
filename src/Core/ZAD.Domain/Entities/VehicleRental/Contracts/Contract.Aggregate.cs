using System;
using ZAD.Domain.Enums.VehicleRental;

namespace ZAD.Domain.Entities.VehicleRental.Contracts
{
    public partial class Contract
    {
        private Contract() { } 

        public Contract(
            int? companyId, int? branchId, TimeSpan time, DateTime date, ContractType contractType, PaymentType paymentType, int periodInDays,
            TimeSpan expectedReceivingTime, DateTime expectedReceivingDate, bool withDriver, int? driverId,
            int tenantId, string? sponsorName, string? sponsorNationality, string? sponsorLicenseNumber, 
            DateTime? sponsorLicenseExpireDate, string? sponsorIdNumber, DateTime? sponsorIdExpireDate,
            string? secondDriverName, string? secondDriverNationality, string? secondDriverLicenseNumber,
            DateTime? secondDriverLicenseExpireDate, string? secondDriverIdNumber, DateTime? secondDriverIdExpireDate,
            int rentalVehicleId, int kilometerCounter, decimal rentPrice, decimal discountPercent, 
            decimal delayPenaltyPerHour, int allowedDelayHours, decimal maintenancePenalty, decimal accidentPenalty,
            decimal driverFare, int driverWorkingHoursPerDay, decimal driverOvertimeAmountPerHour,
            int kilometerPerDay, int maximumKilometerPerDay, decimal amountOfKmExceedingLimit,
            DeliveryStatus deliveryStatus = DeliveryStatus.Rented, ContractStatus status = ContractStatus.Draft)
        {
            CompanyId = companyId;
            BranchId = branchId;
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


            CalculateFields();
        }

        public void Update(
            int? companyId, int? branchId, TimeSpan time, DateTime date, ContractType contractType, PaymentType paymentType, int periodInDays,
            TimeSpan expectedReceivingTime, DateTime expectedReceivingDate, bool withDriver, int? driverId,
            int tenantId, string? sponsorName, string? sponsorNationality, string? sponsorLicenseNumber, 
            DateTime? sponsorLicenseExpireDate, string? sponsorIdNumber, DateTime? sponsorIdExpireDate,
            string? secondDriverName, string? secondDriverNationality, string? secondDriverLicenseNumber,
            DateTime? secondDriverLicenseExpireDate, string? secondDriverIdNumber, DateTime? secondDriverIdExpireDate,
            int rentalVehicleId, int kilometerCounter, decimal rentPrice, decimal discountPercent, 
            decimal delayPenaltyPerHour, int allowedDelayHours, decimal maintenancePenalty, decimal accidentPenalty,
            decimal driverFare, int driverWorkingHoursPerDay, decimal driverOvertimeAmountPerHour,
            int kilometerPerDay, int maximumKilometerPerDay, decimal amountOfKmExceedingLimit,
            DeliveryStatus deliveryStatus, ContractStatus status)
        {
            CompanyId = companyId;
            BranchId = branchId;
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


            CalculateFields();
        }

        private void CalculateFields()
        {
            ActualPeriodInDays = Math.Max(0, (DateTime.Today - Date.Date).Days);
            DiscountAmount = RentPrice * DiscountPercent / 100m;
            NetRentPrice = RentPrice - DiscountAmount;
            DailyRate = DriverFare + (DriverWorkingHoursPerDay * DriverOvertimeAmountPerHour);
            // RemainingAmount is computed from Journal Entries (set externally via SetRemainingAmount)
            // Default to NetRentPrice if not yet set
            if (RemainingAmount == 0)
                RemainingAmount = NetRentPrice;

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

        public void SetRemainingAmount(decimal amount)
        {
            RemainingAmount = amount;
        }

        public void SoftDelete()
        {
            MarkAsDeleted();
            Status = ContractStatus.Deleted;
        }

        public void Restore()
        {
            RestoreFromDeleted();
            Status = ContractStatus.Draft;
        }

        public void Confirm()
        {
            Status = ContractStatus.Confirmed;
        }

        public void Unconfirm()
        {
            Status = ContractStatus.Draft;
        }

        public void ReceiveVehicle(
            DateTime receivingDate,
            TimeSpan receivingTime,
            int receivingKilometerCounter,
            bool receiveProofDocuments,
            string? receiveNotes,
            decimal maintenancePenaltyAmount,
            decimal accidentPenaltyAmount,
            decimal maintenancePaidByTenant,
            decimal receiveDiscountAmount,
            bool isMaintenanceDoneByTenant,
            ZAD.Domain.Enums.VehicleRental.VehicleReceivingStatus? vehicleReceivingStatus,
            bool isVehicleStoppedUntilMaintenanceOrRepair,
            string? damageNote)
        {
            ReceivingDate = receivingDate;
            ReceivingTime = receivingTime;
            ReceivingKilometerCounter = receivingKilometerCounter;
            ReceiveProofDocuments = receiveProofDocuments;
            ReceiveNotes = receiveNotes;
            MaintenancePenalty = maintenancePenaltyAmount;
            AccidentPenalty = accidentPenaltyAmount;
            MaintenancePaidByTenant = maintenancePaidByTenant;
            ReceiveDiscountAmount = receiveDiscountAmount;
            
            IsMaintenanceDoneByTenant = isMaintenanceDoneByTenant;
            VehicleReceivingStatus = vehicleReceivingStatus;
            IsVehicleStoppedUntilMaintenanceOrRepair = isVehicleStoppedUntilMaintenanceOrRepair;
            DamageNote = damageNote;
            var actualPeriod = Math.Max(0, (receivingDate.Date - Date.Date).Days);  
            var expectedEnd = Date.Date.AddDays(PeriodInDays).Add(ExpectedReceivingTime);
            var actualEnd = receivingDate.Date.Add(receivingTime);
            var diffHours = (int)(actualEnd - expectedEnd).TotalHours;
            DelayHours = diffHours > AllowedDelayHours ? diffHours - AllowedDelayHours : 0;
            if (DelayHours < 0) DelayHours = 0;
            TotalConsumptionKilometers = receivingKilometerCounter - KilometerCounter;
            
            var avgKmPerDay = actualPeriod > 0 ? TotalConsumptionKilometers.Value / actualPeriod : 0;
            
            FreeKM = actualPeriod * KilometerPerDay;
            KMExceededTheLimit = Math.Max(0, TotalConsumptionKilometers.Value - FreeKM.Value);
            TotalAmountOfKMExceedingTheLimit = KMExceededTheLimit.Value * AmountOfKmExceedingLimit;
            
            DelayPenaltyAmount = DelayHours.Value * DelayPenaltyPerHour;
            
            TotalRentalAmount = actualPeriod * NetRentPrice;
            TotalDriverAmount = actualPeriod * DriverFare; // Assuming fixed driver fare per day for simplicity

            TotalDueAmount = TotalRentalAmount + TotalDriverAmount + 
                             TotalAmountOfKMExceedingTheLimit + DelayPenaltyAmount + 
                             MaintenancePenalty + AccidentPenalty - MaintenancePaidByTenant;
                             
            FinalNetDueAmount = TotalDueAmount - ReceiveDiscountAmount;
            
            DeliveryStatus = DeliveryStatus.Delivered;
        }

        public void UnreceiveVehicle()
        {
            var now = DateTime.Now;
            if (now.Date > ExpectedReceivingDate.Date ||
                (now.Date == ExpectedReceivingDate.Date && now.TimeOfDay > ExpectedReceivingTime))
            {
                DeliveryStatus = DeliveryStatus.LateThanExpected;
            }
            else
            {
                DeliveryStatus = DeliveryStatus.Rented;
            }
        }
    }
}
