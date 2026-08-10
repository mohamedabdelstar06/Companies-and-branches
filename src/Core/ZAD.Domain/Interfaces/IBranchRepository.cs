using ZAD.Domain.Entities.Branches;
using ZAD.Domain.SeedWork;

namespace ZAD.Domain.Interfaces
{
    public interface IBranchRepository : IGenericRepository<Branch>, IPaginationRepository<Branch>
    {
    }
}
