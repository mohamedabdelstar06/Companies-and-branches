using System;
using ZAD.Domain.SeedWork;

namespace ZAD.Domain.Entities.VehicleRental.Drivers
{
    public class SecondDriver : Entity
    {
        public string Name { get; private set; } = string.Empty;
        public string Nationality { get; private set; } = string.Empty;
        public string LicenseNumber { get; private set; } = string.Empty;
        public DateTime LicenseExpireDate { get; private set; }
        public string IdNumber { get; private set; } = string.Empty;
        public DateTime IdExpireDate { get; private set; }

        private SecondDriver() { } // EF Core

        public SecondDriver(string name, string nationality, string licenseNumber, DateTime licenseExpireDate, string idNumber, DateTime idExpireDate)
        {
            Name = name;
            Nationality = nationality;
            LicenseNumber = licenseNumber;
            LicenseExpireDate = licenseExpireDate;
            IdNumber = idNumber;
            IdExpireDate = idExpireDate;
        }

        public void Update(string name, string nationality, string licenseNumber, DateTime licenseExpireDate, string idNumber, DateTime idExpireDate)
        {
            Name = name;
            Nationality = nationality;
            LicenseNumber = licenseNumber;
            LicenseExpireDate = licenseExpireDate;
            IdNumber = idNumber;
            IdExpireDate = idExpireDate;
        }
    }
}
