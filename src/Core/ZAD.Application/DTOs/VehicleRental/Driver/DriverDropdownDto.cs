using System;

namespace ZAD.Application.DTOs.VehicleRental.Driver
{
    public class DriverDropdownDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Nationality { get; set; } = string.Empty;
        public string LicenseNumber { get; set; } = string.Empty;
        public DateTime? LicenseExpireDate { get; set; }
        public string IdNumber { get; set; } = string.Empty;
        public DateTime? IdExpireDate { get; set; }

        public decimal DriverFare { get; set; }
        public int DriverWorkingHoursPerDay { get; set; }
        public decimal DriverOvertimeAmountPerHour { get; set; }
        public decimal DailyRate { get; set; }
    }
}
