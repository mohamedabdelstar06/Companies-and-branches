using System;
using ZAD.Domain.SeedWork;

namespace ZAD.Domain.Entities.VehicleRental.Tenants
{
    public class Tenant : Entity
    {
        public string Name { get; private set; } = string.Empty;
        public string LicenseNumber { get; private set; } = string.Empty;
        public string PassportNumber { get; private set; } = string.Empty;
        public string UnifiedNumber { get; private set; } = string.Empty;
        public string IdNumber { get; private set; } = string.Empty;
        public string Mobile { get; private set; } = string.Empty;
        public DateTime Birthday { get; private set; }

        private Tenant() { } // EF Core

        public Tenant(string name, string licenseNumber, string passportNumber, string unifiedNumber, string idNumber, string mobile, DateTime birthday)
        {
            Name = name;
            LicenseNumber = licenseNumber;
            PassportNumber = passportNumber;
            UnifiedNumber = unifiedNumber;
            IdNumber = idNumber;
            Mobile = mobile;
            Birthday = birthday;
        }

        public void Update(string name, string licenseNumber, string passportNumber, string unifiedNumber, string idNumber, string mobile, DateTime birthday)
        {
            Name = name;
            LicenseNumber = licenseNumber;
            PassportNumber = passportNumber;
            UnifiedNumber = unifiedNumber;
            IdNumber = idNumber;
            Mobile = mobile;
            Birthday = birthday;
        }
    }
}
