using AutoMapper;
using ZAD.Application.DTOs.Branch;
using ZAD.Domain.Entities;

namespace ZAD.Application.Mapping
{
    public class BranchProfile : Profile
    {
        public BranchProfile()
        {
            CreateMap<Branch, BranchListDto>()
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.NameEn))
                .ForMember(d => d.Address, opt => opt.MapFrom(s => s.AddressEn))
                .ForMember(d => d.CompanyName, opt => opt.MapFrom(s => s.Company.NameEn));
                
            CreateMap<Branch, BranchDetailDto>()
                .ForMember(d => d.CompanyName, opt => opt.MapFrom(s => s.Company.NameEn));
            
            CreateMap<CreateBranchDto, Branch>()
                .ForMember(d => d.LogoPath, opt => opt.Ignore());
                
            CreateMap<UpdateBranchDto, Branch>()
                .ForMember(d => d.LogoPath, opt => opt.Ignore());
        }
    }
}
