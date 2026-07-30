using System.Threading.Tasks;

namespace ZAD.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        ICompanyRepository Companies { get; }
        IBranchRepository Branches { get; }
        Task<int> SaveChangesAsync();
    }
}
