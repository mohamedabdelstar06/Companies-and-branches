using AutoMapper;
using ZAD.Application.DTOs.Branch;
using ZAD.Application.DTOs.Common;
using ZAD.Domain.Entities.Branches;
using ZAD.Domain.Entities.Common;
using System.Linq;

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
                .ForMember(d => d.Website, opt => opt.MapFrom(s => s.Contacts.FirstOrDefault(c => c.Type == ZAD.Domain.Enums.ContactType.Website) != null ? s.Contacts.FirstOrDefault(c => c.Type == ZAD.Domain.Enums.ContactType.Website)!.Value : null))
                .ForMember(d => d.Phone, opt => opt.MapFrom(s => s.Contacts.FirstOrDefault(c => c.Type == ZAD.Domain.Enums.ContactType.Phone) != null ? s.Contacts.FirstOrDefault(c => c.Type == ZAD.Domain.Enums.ContactType.Phone)!.Value : null))
                .ForMember(d => d.Address, opt => opt.MapFrom(s => s.Address != null ? s.Address.AddressEn : null))
                .ForMember(d => d.Logo, opt => opt.MapFrom(s => s.LogoPath))
                .ForMember(d => d.CompanyName, opt => opt.MapFrom(s => s.Company != null ? s.Company.NameEn : string.Empty));
                
            CreateMap<Branch, BranchDetailDto>()
                .ForMember(d => d.Country, opt => opt.MapFrom(s => s.Address != null ? s.Address.Country : null))
                .ForMember(d => d.City, opt => opt.MapFrom(s => s.Address != null ? s.Address.City : null))
                .ForMember(d => d.AddressAr, opt => opt.MapFrom(s => s.Address != null ? s.Address.AddressAr : null))
                .ForMember(d => d.AddressEn, opt => opt.MapFrom(s => s.Address != null ? s.Address.AddressEn : null))
                .ForMember(d => d.CompanyName, opt => opt.MapFrom(s => s.Company != null ? s.Company.NameEn : string.Empty));
        }
    }
}
