using ZAD.Domain.Entities;

namespace ZAD.Domain.Interfaces
{
    public interface IBranchRepository : IGenericRepository<Branch>, IPaginationRepository<Branch>
    {
    }
}
