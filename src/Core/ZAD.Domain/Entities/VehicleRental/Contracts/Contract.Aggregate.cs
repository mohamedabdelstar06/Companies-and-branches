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
            decimal vehicleDailyRentPrice,
            DateTime? contractNextMaintenanceDate, int? contractNextMaintenanceKM,
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
            VehicleDailyRentPrice = vehicleDailyRentPrice;
            ContractNextMaintenanceDate = contractNextMaintenanceDate;
            ContractNextMaintenanceKM = contractNextMaintenanceKM;
            DeliveryStatus = deliveryStatus;
            Status = status;


            CalculateFields();
        }

        public void Update(
            TimeSpan time, DateTime date, ContractType contractType, PaymentType paymentType, int periodInDays,
            TimeSpan expectedReceivingTime, DateTime expectedReceivingDate, bool withDriver, int? driverId,
            int tenantId, string? sponsorName, string? sponsorNationality, string? sponsorLicenseNumber, 
            DateTime? sponsorLicenseExpireDate, string? sponsorIdNumber, DateTime? sponsorIdExpireDate,
            string? secondDriverName, string? secondDriverNationality, string? secondDriverLicenseNumber,
            DateTime? secondDriverLicenseExpireDate, string? secondDriverIdNumber, DateTime? secondDriverIdExpireDate,
            int rentalVehicleId, int kilometerCounter, decimal rentPrice, decimal discountPercent, 
            decimal delayPenaltyPerHour, int allowedDelayHours, decimal maintenancePenalty, decimal accidentPenalty,
            decimal driverFare, int driverWorkingHoursPerDay, decimal driverOvertimeAmountPerHour,
            int kilometerPerDay, int maximumKilometerPerDay, decimal amountOfKmExceedingLimit,
            decimal vehicleDailyRentPrice,
            DateTime? contractNextMaintenanceDate, int? contractNextMaintenanceKM,
            DeliveryStatus deliveryStatus, ContractStatus status)
        {
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
            VehicleDailyRentPrice = vehicleDailyRentPrice;
            ContractNextMaintenanceDate = contractNextMaintenanceDate;
            ContractNextMaintenanceKM = contractNextMaintenanceKM;
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
            decimal accidentPenaltyAmount,
            decimal maintenancePaidByTenant,
            decimal receiveDiscountAmount,
            bool isMaintenanceDoneByTenant,
            MaintenanceType? currentMaintenanceType,
            DateTime? currentMaintenanceDate,
            int? currentMaintenanceKM,
            string? currentMaintenanceNote,
            DateTime? newNextMaintenanceDate,
            int? newNextMaintenanceKM,
            VehicleReceivingStatus? vehicleReceivingStatus,
            bool isVehicleStoppedUntilMaintenanceOrRepair,
            string? damageNote)
        {
            ReceivingDate = receivingDate;
            ReceivingTime = receivingTime;
            ReceivingKilometerCounter = receivingKilometerCounter;
            ReceiveProofDocuments = receiveProofDocuments;
            ReceiveNotes = receiveNotes;
            AccidentPenalty = accidentPenaltyAmount;
            MaintenancePaidByTenant = maintenancePaidByTenant;
            ReceiveDiscountAmount = receiveDiscountAmount;
            IsMaintenanceDoneByTenant = isMaintenanceDoneByTenant;
            CurrentMaintenanceType = currentMaintenanceType;
            CurrentMaintenanceDate = currentMaintenanceDate;
            CurrentMaintenanceKM = currentMaintenanceKM;
            CurrentMaintenanceNote = currentMaintenanceNote;
            NewNextMaintenanceDate = newNextMaintenanceDate;
            NewNextMaintenanceKM = newNextMaintenanceKM;
            VehicleReceivingStatus = vehicleReceivingStatus;
            IsVehicleStoppedUntilMaintenanceOrRepair = isVehicleStoppedUntilMaintenanceOrRepair;
            DamageNote = damageNote;

            var expectedEnd = ExpectedReceivingDate.Date.Add(ExpectedReceivingTime);
            var actualEnd   = receivingDate.Date.Add(receivingTime);
            var rawDiffHours = (actualEnd - expectedEnd).TotalHours;
            int actualPeriodHours = (int)Math.Max(0, Math.Floor(rawDiffHours));
            int actualPeriodDays  = (int)Math.Max(0, Math.Floor(rawDiffHours / 24.0));
            int actualPeriod      = ContractType == ContractType.Hourly ? actualPeriodHours : actualPeriodDays;
         if (ContractType == ContractType.Hourly)
            {
                DelayHours = 0;
            }
            else
            {
                int totalLateHours = (int)Math.Ceiling(Math.Max(0, rawDiffHours));
                int totalLateAfterAllowed = Math.Max(0, totalLateHours - AllowedDelayHours);
                DelayHours = totalLateAfterAllowed > 0 ? totalLateAfterAllowed % 24 : 0;
            }

           TotalConsumptionKilometers = receivingKilometerCounter - KilometerCounter;

           AVGKilometersPerDay = ContractType == ContractType.Hourly
                ? (actualPeriodHours > 0 ? (decimal)TotalConsumptionKilometers.Value / actualPeriodHours * 24m : 0m)
                : (actualPeriodDays  > 0 ? (decimal)TotalConsumptionKilometers.Value / actualPeriodDays        : 0m);

           FreeKM = ContractType == ContractType.Hourly
                ? (int)(MaximumKilometerPerDay / 24.0 * actualPeriodHours)
                : MaximumKilometerPerDay * actualPeriodDays;

           KMExceededTheLimit = Math.Max(0, TotalConsumptionKilometers.Value - FreeKM.Value);

            TotalAmountOfKMExceedingTheLimit = KMExceededTheLimit.Value * AmountOfKmExceedingLimit;
           DelayPenaltyAmount = DelayHours.Value * DelayPenaltyPerHour;
     if (isMaintenanceDoneByTenant)
            {
                MaintenancePenalty = 0m;
            }
            else
            {
                bool maintenanceDue =
                    (ContractNextMaintenanceDate.HasValue && ContractNextMaintenanceDate.Value.Date < receivingDate.Date) ||
                    (ContractNextMaintenanceKM.HasValue   && ContractNextMaintenanceKM.Value < receivingKilometerCounter);
                MaintenancePenalty = maintenanceDue ? MaintenancePenalty : 0m;
            }

           TotalRentalAmount = ContractType switch
            {
                ContractType.Hourly   => actualPeriodHours * NetRentPrice,
                ContractType.Daily    => actualPeriodDays  * NetRentPrice,
                ContractType.Weekly   => (actualPeriodDays / 7)   * NetRentPrice + (actualPeriodDays % 7)   * VehicleDailyRentPrice,
                ContractType.Monthly  => (actualPeriodDays / 30)  * NetRentPrice + (actualPeriodDays % 30)  * VehicleDailyRentPrice,
                ContractType.LongTerm => (actualPeriodDays / 360) * NetRentPrice + (actualPeriodDays % 360) * VehicleDailyRentPrice,
                _                     => actualPeriodDays  * NetRentPrice
            };

           if (!WithDriver)
            {
                TotalDriverAmount = 0m;
            }
            else
            {
                TotalDriverAmount = ContractType switch
                {
                    ContractType.Hourly   => actualPeriodHours * DriverFare,
                    ContractType.Daily    => (actualPeriodDays + 1) * DriverFare,
                    ContractType.Weekly   => (actualPeriodDays / 7)   * DriverFare + ((actualPeriodDays % 7)   + 1) * DailyRate,
                    ContractType.Monthly  => (actualPeriodDays / 30)  * DriverFare + ((actualPeriodDays % 30)  + 1) * DailyRate,
                    ContractType.LongTerm => (actualPeriodDays / 360) * DriverFare + ((actualPeriodDays % 360) + 1) * DailyRate,
                    _                     => (actualPeriodDays + 1) * DriverFare
                };
            }

            TotalDueAmount = TotalRentalAmount + TotalDriverAmount +
                             TotalAmountOfKMExceedingTheLimit + DelayPenaltyAmount +
                             MaintenancePenalty + AccidentPenalty - MaintenancePaidByTenant;

           FinalNetDueAmount = TotalDueAmount - ReceiveDiscountAmount;
   }

        public void ConfirmReceiveVehicle()
        {
            if (DeliveryStatus != DeliveryStatus.Rented && DeliveryStatus != DeliveryStatus.LateThanExpected)
            {
                throw new InvalidOperationException("Contract must be in Rented or Late state to confirm vehicle receipt.");
            }
            if (!ReceivingDate.HasValue)
            {
                throw new InvalidOperationException("Vehicle receive details must be filled before confirming receipt.");
            }

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
