using System;

namespace ZAD.Application.DTOs.VehicleRental.Tenant
{
    public class TenantDropdownDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime Birthday { get; set; }
        public string LicenseNumber { get; set; } = string.Empty;
        public string PassportNumber { get; set; } = string.Empty;
        public string UnifiedNumber { get; set; } = string.Empty;
        public string IdNumber { get; set; } = string.Empty;
        public string Mobile { get; set; } = string.Empty;
        
        public int Age => Math.Max(0, (DateTime.Today - Birthday).Days / 365);
    }
}
