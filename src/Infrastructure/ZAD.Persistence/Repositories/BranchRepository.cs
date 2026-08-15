using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ZAD.Domain.Entities.Branches;
using ZAD.Domain.Interfaces;
using ZAD.Persistence.Context;

namespace ZAD.Persistence.Repositories
{
    public class BranchRepository : GenericRepository<Branch>, IBranchRepository
    {
        private readonly PaginationRepositoryImpl _pagination;

        public BranchRepository(ApplicationDbContext context, IMapper mapper) : base(context)
        {
            _pagination = new PaginationRepositoryImpl(context, mapper, this);
        }

        public override async Task<Branch?> GetByIdAsync(int id)
        {
            return await _dbSet
                .Include(b => b.Contacts)
                .Include(b => b.Documents)
                .Include(b => b.Company)
                .FirstOrDefaultAsync(b => b.Id == id);
        }

        public Task<(IEnumerable<TResult> Items, int TotalCount)> GetPageAsync<TResult>(
            int pageIndex, int pageSize, string? searchTerm, string? sortColumn, string? sortDirection, bool? isActive)
        {
            return _pagination.GetPageAsync<TResult>(pageIndex, pageSize, searchTerm, sortColumn, sortDirection, isActive);
        }

        private class PaginationRepositoryImpl : PaginationRepository<Branch>
        {
            private readonly BranchRepository _repo;

            public PaginationRepositoryImpl(ApplicationDbContext context, IMapper mapper, BranchRepository repo) : base(context, mapper)
            {
                _repo = repo;
            }

            public override async Task<(IEnumerable<TResult> Items, int TotalCount)> GetPageAsync<TResult>(
                int pageIndex, int pageSize, string? searchTerm, string? sortColumn, string? sortDirection, bool? isActive)
            {
                IQueryable<Branch> query = _repo.FindAllNoTracking().Include(b => b.Company);

                if (!string.IsNullOrEmpty(searchTerm))
                {
                    query = query.Where(b => 
                        b.Code.Contains(searchTerm) || 
                        b.NameAr.Contains(searchTerm) || 
                        b.NameEn.Contains(searchTerm));
                }

                if (isActive.HasValue)
                {
                    query = query.Where(b => b.IsActive == isActive.Value);
                }

                if (string.Equals(sortColumn, "phone", System.StringComparison.OrdinalIgnoreCase))
                {
                    bool isDesc = sortDirection?.ToLower() == "desc";
                    query = isDesc 
                        ? query.OrderByDescending(c => c.Contacts.FirstOrDefault() != null ? c.Contacts.FirstOrDefault()!.Value : "") 
                        : query.OrderBy(c => c.Contacts.FirstOrDefault() != null ? c.Contacts.FirstOrDefault()!.Value : "");
                    sortColumn = null; // Prevent dynamic sorting
                }
                else if (string.Equals(sortColumn, "address", System.StringComparison.OrdinalIgnoreCase))
                {
                    bool isDesc = sortDirection?.ToLower() == "desc";
                    query = isDesc 
                        ? query.OrderByDescending(c => c.Address != null ? c.Address.AddressEn : "") 
                        : query.OrderBy(c => c.Address != null ? c.Address.AddressEn : "");
                    sortColumn = null; // Prevent dynamic sorting
                }

                return await GetPageInternalAsync<TResult>(query, pageIndex, pageSize, sortColumn, sortDirection);
            }
        }
    }
}
