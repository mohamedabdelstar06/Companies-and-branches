using System;

namespace ZAD.Application.DTOs.VehicleRental.Tenant
{
    public class CreateTenantDto
    {
        public string Name { get; set; } = string.Empty;
        public string LicenseNumber { get; set; } = string.Empty;
        public string PassportNumber { get; set; } = string.Empty;
        public string UnifiedNumber { get; set; } = string.Empty;
        public string IdNumber { get; set; } = string.Empty;
        public string Mobile { get; set; } = string.Empty;
        public DateTime Birthday { get; set; }
    }
}
