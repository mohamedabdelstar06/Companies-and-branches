using System;
using ZAD.Domain.SeedWork;

namespace ZAD.Domain.Entities.VehicleRental.Drivers
{
    public class Driver : Entity
    {
        public string Name { get; private set; } = string.Empty;
        public string Nationality { get; private set; } = string.Empty;
        public string LicenseNumber { get; private set; } = string.Empty;
        public DateTime? LicenseExpireDate { get; private set; }
        public string IdNumber { get; private set; } = string.Empty;
        public DateTime? IdExpireDate { get; private set; }

        public decimal DriverFare { get; private set; }
        public int DriverWorkingHoursPerDay { get; private set; }
        public decimal DriverOvertimeAmountPerHour { get; private set; }
        public decimal DailyRate { get; private set; }

        private Driver() { } // EF Core

        public Driver(string name, string nationality, string licenseNumber, DateTime? licenseExpireDate, string idNumber, DateTime? idExpireDate,
            decimal driverFare, int driverWorkingHoursPerDay, decimal driverOvertimeAmountPerHour, decimal dailyRate)
        {
            Name = name;
            Nationality = nationality;
            LicenseNumber = licenseNumber;
            LicenseExpireDate = licenseExpireDate;
            IdNumber = idNumber;
            IdExpireDate = idExpireDate;
            DriverFare = driverFare;
            DriverWorkingHoursPerDay = driverWorkingHoursPerDay;
            DriverOvertimeAmountPerHour = driverOvertimeAmountPerHour;
            DailyRate = dailyRate;
        }

        public void Update(string name, string nationality, string licenseNumber, DateTime? licenseExpireDate, string idNumber, DateTime? idExpireDate,
            decimal driverFare, int driverWorkingHoursPerDay, decimal driverOvertimeAmountPerHour, decimal dailyRate)
        {
            Name = name;
            Nationality = nationality;
            LicenseNumber = licenseNumber;
            LicenseExpireDate = licenseExpireDate;
            IdNumber = idNumber;
            IdExpireDate = idExpireDate;
            DriverFare = driverFare;
            DriverWorkingHoursPerDay = driverWorkingHoursPerDay;
            DriverOvertimeAmountPerHour = driverOvertimeAmountPerHour;
            DailyRate = dailyRate;
        }
    }
}
