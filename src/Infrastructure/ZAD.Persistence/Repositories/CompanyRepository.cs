using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ZAD.Domain.Entities.Companies;
using ZAD.Domain.Interfaces;
using ZAD.Persistence.Context;

namespace ZAD.Persistence.Repositories
{
    public class CompanyRepository : GenericRepository<Company>, ICompanyRepository
    {
        private readonly PaginationRepositoryImpl _pagination;

        public CompanyRepository(ApplicationDbContext context, IMapper mapper) : base(context)
        {
            _pagination = new PaginationRepositoryImpl(context, mapper, this);
        }

        public override async Task<Company?> GetByIdAsync(int id)
        {
            return await _dbSet
                .Include(c => c.Contacts)
                .Include(c => c.Documents)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public Task<(IEnumerable<TResult> Items, int TotalCount)> GetPageAsync<TResult>(
            int pageIndex, int pageSize, string? searchTerm, string? sortColumn, string? sortDirection, bool? isActive)
        {
            return _pagination.GetPageAsync<TResult>(pageIndex, pageSize, searchTerm, sortColumn, sortDirection, isActive);
        }

        private class PaginationRepositoryImpl : PaginationRepository<Company>
        {
            private readonly CompanyRepository _repo;

            public PaginationRepositoryImpl(ApplicationDbContext context, IMapper mapper, CompanyRepository repo) : base(context, mapper)
            {
                _repo = repo;
            }

            public override async Task<(IEnumerable<TResult> Items, int TotalCount)> GetPageAsync<TResult>(
                int pageIndex, int pageSize, string? searchTerm, string? sortColumn, string? sortDirection, bool? isActive)
            {
                var query = _repo.FindAllNoTracking();

                if (!string.IsNullOrEmpty(searchTerm))
                {
                    query = query.Where(c => 
                        c.Code.Contains(searchTerm) || 
                        c.NameAr.Contains(searchTerm) || 
                        c.NameEn.Contains(searchTerm));
                }

                if (isActive.HasValue)
                {
                    query = query.Where(c => c.IsActive == isActive.Value);
                }

                if (string.Equals(sortColumn, "phone", StringComparison.OrdinalIgnoreCase))
                {
                    bool isDesc = sortDirection?.ToLower() == "desc";
                    query = isDesc 
                        ? query.OrderByDescending(c => c.Contacts.FirstOrDefault() != null ? c.Contacts.FirstOrDefault()!.Value : "") 
                        : query.OrderBy(c => c.Contacts.FirstOrDefault() != null ? c.Contacts.FirstOrDefault()!.Value : "");
                    sortColumn = null; // Prevent dynamic sorting
                }
                else if (string.Equals(sortColumn, "address", StringComparison.OrdinalIgnoreCase))
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
