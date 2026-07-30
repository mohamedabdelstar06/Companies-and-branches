using System.Threading.Tasks;

namespace ZAD.Domain.Interfaces
{
    public interface IPaginationRepository<T>
    {
        Task<(System.Collections.Generic.IEnumerable<TResult> Items, int TotalCount)> GetPageAsync<TResult>(
            int pageIndex, 
            int pageSize, 
            string? searchTerm, 
            string? sortColumn, 
            string? sortDirection, 
            bool? isActive);
    }
}
