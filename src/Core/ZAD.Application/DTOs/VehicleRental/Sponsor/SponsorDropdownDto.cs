using System;

namespace ZAD.Application.DTOs.VehicleRental.Sponsor
{
    public class SponsorDropdownDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Nationality { get; set; } = string.Empty;
        public string LicenseNumber { get; set; } = string.Empty;
        public DateTime LicenseExpireDate { get; set; }
        public string IdNumber { get; set; } = string.Empty;
        public DateTime IdExpireDate { get; set; }
    }
}
