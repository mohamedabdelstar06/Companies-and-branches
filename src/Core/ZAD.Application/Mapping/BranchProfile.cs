using AutoMapper;
using ZAD.Application.DTOs.Branch;
using ZAD.Application.DTOs.Common;
using ZAD.Domain.Entities.Branches;
using ZAD.Domain.Entities.Common;

namespace ZAD.Application.Mapping
{
    public class BranchProfile : Profile
    {
        public BranchProfile()
        {
            CreateMap<Contact,ContactDto>();
            CreateMap<Document, DocumentDto>();

            CreateMap<Branch, BranchListDto>()
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.NameEn))
                .ForMember(d => d.Address, opt => opt.MapFrom(s => s.Address != null ? s.Address.AddressEn : null))
                .ForMember(d => d.Phone, opt => opt.MapFrom(s => s.Phone))
                .ForMember(d => d.Logo, opt => opt.MapFrom(s => s.LogoPath))
                .ForMember(d => d.CompanyName, opt => opt.MapFrom(s => s.Company != null ? s.Company.NameEn : string.Empty));
                
            CreateMap<Branch, BranchDetailDto>()
                .ForMember(d => d.Country, opt => opt.MapFrom(s => s.Address != null ? s.Address.Country : null))
                .ForMember(d => d.City, opt => opt.MapFrom(s => s.Address != null ? s.Address.City : null))
                .ForMember(d => d.AddressAr, opt => opt.MapFrom(s => s.Address != null ? s.Address.AddressAr : null))
                .ForMember(d => d.AddressEn, opt => opt.MapFrom(s => s.Address != null ? s.Address.AddressEn : null))
                .ForMember(d => d.Email, opt => opt.MapFrom(s => s.Email != null ? s.Email.Value : null))
                .ForMember(d => d.CompanyName, opt => opt.MapFrom(s => s.Company != null ? s.Company.NameEn : string.Empty));
        }
    }
}
