using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ZAD.Domain.Entities;
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
//Sorting
// Paging
// Mapping
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
                        c.NameEn.Contains(searchTerm) || 
                        (c.Phone != null && c.Phone.Contains(searchTerm)));
                }

                if (isActive.HasValue)
                {
                    query = query.Where(c => c.IsActive == isActive.Value);
                }

                return await GetPageInternalAsync<TResult>(query, pageIndex, pageSize, sortColumn, sortDirection);
            }
        }
    }
}
