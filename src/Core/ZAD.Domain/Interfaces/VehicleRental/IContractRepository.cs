using ZAD.Domain.Entities.VehicleRental.Contracts;
using ZAD.Domain.Interfaces;

namespace ZAD.Domain.Interfaces.VehicleRental
{
    public interface IContractRepository : IGenericRepository<Contract>, IPaginationRepository<Contract>
    {
        Task<(System.Collections.Generic.IEnumerable<TResult> Items, int TotalCount)> GetPageWithContextAsync<TResult>(
            int pageIndex, int pageSize, string? searchTerm, string? sortColumn, string? sortDirection, int? companyId, int? branchId);
    }
}
