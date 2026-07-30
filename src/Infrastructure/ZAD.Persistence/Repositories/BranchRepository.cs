using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ZAD.Domain.Entities;
using ZAD.Domain.Interfaces;
using ZAD.Persistence.Context;
using Microsoft.EntityFrameworkCore;

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
            return await _dbSet.Include(b => b.Company).FirstOrDefaultAsync(b => b.Id == id);
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
                var query = _repo.FindAllNoTracking().Include(b => b.Company).AsQueryable();

                if (!string.IsNullOrEmpty(searchTerm))
                {
                    query = query.Where(b => 
                        b.Code.Contains(searchTerm) || 
                        b.NameAr.Contains(searchTerm) || 
                        b.NameEn.Contains(searchTerm) || 
                        (b.Phone != null && b.Phone.Contains(searchTerm)));
                }

                if (isActive.HasValue)
                {
                    query = query.Where(b => b.IsActive == isActive.Value);
                }

                return await GetPageInternalAsync<TResult>(query, pageIndex, pageSize, sortColumn, sortDirection);
            }
        }
    }
}
