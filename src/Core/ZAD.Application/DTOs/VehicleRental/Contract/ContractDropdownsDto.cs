using System.Collections.Generic;
using ZAD.Application.DTOs.Common;
using ZAD.Application.DTOs.VehicleRental.Tenant;
using ZAD.Application.DTOs.VehicleRental.RentalVehicle;
using ZAD.Application.DTOs.VehicleRental.Sponsor;
using ZAD.Application.DTOs.VehicleRental.Driver;

namespace ZAD.Application.DTOs.VehicleRental.Contract
{
    public class ContractDropdownsDto
    {
        public IEnumerable<ZAD.Application.DTOs.Company.CompanyDropdownDto> Companies { get; set; } = new List<ZAD.Application.DTOs.Company.CompanyDropdownDto>();
        public IEnumerable<ZAD.Application.DTOs.Branch.BranchDropdownDto> Branches { get; set; } = new List<ZAD.Application.DTOs.Branch.BranchDropdownDto>();
        public IEnumerable<TenantDropdownDto> Tenants { get; set; } = new List<TenantDropdownDto>();
        public IEnumerable<ZAD.Application.DTOs.VehicleRental.Driver.DriverDropdownDto> Drivers { get; set; } = new List<ZAD.Application.DTOs.VehicleRental.Driver.DriverDropdownDto>();
        public IEnumerable<RentalVehicleDropdownDto> Vehicles { get; set; } = new List<RentalVehicleDropdownDto>();
        
        public IEnumerable<SponsorDropdownDto> Sponsors { get; set; } = new List<SponsorDropdownDto>();
    }
}
