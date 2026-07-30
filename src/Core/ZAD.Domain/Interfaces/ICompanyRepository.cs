using ZAD.Domain.Entities;

namespace ZAD.Domain.Interfaces
{
    public interface ICompanyRepository : IGenericRepository<Company>, IPaginationRepository<Company>
    {
    }
}
