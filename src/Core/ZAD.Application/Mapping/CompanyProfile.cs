using AutoMapper;
using ZAD.Application.DTOs.Company;
using ZAD.Application.DTOs.Common;
using ZAD.Domain.Entities.Companies;
using ZAD.Domain.Entities.Common;

namespace ZAD.Application.Mapping
{
    public class CompanyProfile : Profile
    {
        public CompanyProfile()
        {
            CreateMap<Contact, ContactDto>();
            CreateMap<Document, DocumentDto>();

            CreateMap<Company, CompanyListDto>()
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.NameEn))
                .ForMember(d => d.Address, opt => opt.MapFrom(s => s.Address != null ? s.Address.AddressEn : null))
                .ForMember(d => d.Email, opt => opt.MapFrom(s => s.Email != null ? s.Email.Value : null))
                .ForMember(d => d.Website, opt => opt.MapFrom(s => s.Website))
                .ForMember(d => d.Logo, opt => opt.MapFrom(s => s.LogoPath));
                
            CreateMap<Company, CompanyDetailDto>()
                .ForMember(d => d.Country, opt => opt.MapFrom(s => s.Address != null ? s.Address.Country : null))
                .ForMember(d => d.City, opt => opt.MapFrom(s => s.Address != null ? s.Address.City : null))
                .ForMember(d => d.AddressAr, opt => opt.MapFrom(s => s.Address != null ? s.Address.AddressAr : null))
                .ForMember(d => d.AddressEn, opt => opt.MapFrom(s => s.Address != null ? s.Address.AddressEn : null))
                .ForMember(d => d.Email, opt => opt.MapFrom(s => s.Email != null ? s.Email.Value : null));
            
            // We won't map CreateCompanyDto/UpdateCompanyDto directly to Company anymore
            // because we are using DDD with rich aggregates and constructors.
            // DTO -> Entity mapping is best handled manually or via factories in DDD.
        }
    }
}
