using System;
using System.Threading.Tasks;
using ZAD.Domain.Entities.Lookups;

namespace ZAD.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ICompanyRepository Companies { get; }
        IBranchRepository Branches { get; }
        IGenericRepository<Lookup> Lookups { get; }
        Task<int> SaveChangesAsync();
    }
}
