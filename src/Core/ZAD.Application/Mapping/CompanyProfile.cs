using AutoMapper;
using ZAD.Application.DTOs.Company;
using ZAD.Domain.Entities;

namespace ZAD.Application.Mapping
{
    public class CompanyProfile : Profile
    {
        public CompanyProfile()
        {
            CreateMap<Company, CompanyListDto>()
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.NameEn))
                .ForMember(d => d.Address, opt => opt.MapFrom(s => s.AddressEn));
                
            CreateMap<Company, CompanyDetailDto>();
            
            CreateMap<CreateCompanyDto, Company>()
                .ForMember(d => d.LogoPath, opt => opt.Ignore());
                
            CreateMap<UpdateCompanyDto, Company>()
                .ForMember(d => d.LogoPath, opt => opt.Ignore());
        }
    }
}
