using AutoMapper;
using ZAD.Domain.Entities.VehicleRental.Tenants;
using ZAD.Domain.Entities.VehicleRental.Contracts;
using ZAD.Domain.Entities.VehicleRental.Drivers;
using ZAD.Domain.Entities.VehicleRental.Vehicles;
using ZAD.Application.DTOs.VehicleRental.Tenant;
using ZAD.Application.DTOs.VehicleRental.Contract;
using ZAD.Application.DTOs.VehicleRental.Driver;
using ZAD.Application.DTOs.VehicleRental.RentalVehicle;

namespace ZAD.Application.Mapping
{
    public class ContractProfile : Profile
    {
        public ContractProfile()
        {
            // Tenant
            CreateMap<Tenant, TenantListDto>();
            CreateMap<Tenant, TenantDropdownDto>();

            // Driver
            CreateMap<Driver, DriverDropdownDto>();

            // Rental Vehicle
            CreateMap<RentalVehicle, RentalVehicleDropdownDto>()
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => (int)src.Type))
                .ForMember(dest => dest.TypeName, opt => opt.MapFrom(src => src.Type.ToString()));

            // Contract
            CreateMap<Contract, ContractDetailDto>()
                .ForMember(dest => dest.TenantName, opt => opt.MapFrom(src => src.Tenant != null ? src.Tenant.Name : null))
                .ForMember(dest => dest.DriverName, opt => opt.MapFrom(src => src.Driver != null ? src.Driver.Name : null))
                .ForMember(dest => dest.PlateNo, opt => opt.MapFrom(src => src.RentalVehicle != null ? src.RentalVehicle.PlateNo : null))
                .ForMember(dest => dest.ModelYear, opt => opt.MapFrom(src => src.RentalVehicle != null ? src.RentalVehicle.ModelYear : (int?)null))
                .ForMember(dest => dest.FileNo, opt => opt.MapFrom(src => src.RentalVehicle != null ? src.RentalVehicle.FileNo : null))
                .ForMember(dest => dest.CompanyName, opt => opt.MapFrom(src => src.Company != null ? src.Company.NameEn : null))
                .ForMember(dest => dest.BranchName, opt => opt.MapFrom(src => src.Branch != null ? src.Branch.NameEn : null));

            CreateMap<Contract, ContractListDto>()
                .ForMember(dest => dest.TenantName, opt => opt.MapFrom(src => src.Tenant != null ? src.Tenant.Name : string.Empty))
                .ForMember(dest => dest.PlateNo, opt => opt.MapFrom(src => src.RentalVehicle != null ? src.RentalVehicle.PlateNo : string.Empty))
                .ForMember(dest => dest.Brand, opt => opt.MapFrom(src => src.RentalVehicle != null ? src.RentalVehicle.Brand : string.Empty))
                .ForMember(dest => dest.CompanyName, opt => opt.MapFrom(src => src.Company != null ? src.Company.NameEn : string.Empty))
                .ForMember(dest => dest.BranchName, opt => opt.MapFrom(src => src.Branch != null ? src.Branch.NameEn : string.Empty))
                .ForMember(dest => dest.ContractType, opt => opt.MapFrom(src => src.ContractType.ToString()))
                .ForMember(dest => dest.DeliveryStatus, opt => opt.MapFrom(src => src.DeliveryStatus.ToString()))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()))
                .ForMember(dest => dest.IsPosted, opt => opt.MapFrom(src => src.IsPosted ? "Yes" : "No"))
                .ForMember(dest => dest.ToDate, opt => opt.MapFrom(src => src.Date.AddDays(src.PeriodInDays)));
        }
    }
}
