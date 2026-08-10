using ZAD.Domain.Entities.Companies;
using ZAD.Domain.SeedWork;

namespace ZAD.Domain.Interfaces
{
    public interface ICompanyRepository : IGenericRepository<Company>, IPaginationRepository<Company>
    {
    }
}
