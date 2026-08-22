using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ZAD.Domain.Entities.VehicleRental.Tenants;
using ZAD.Domain.Interfaces.VehicleRental;
using ZAD.Persistence.Context;

namespace ZAD.Persistence.Repositories.VehicleRental
{
    public class TenantRepository : GenericRepository<Tenant>, ITenantRepository
    {
        private readonly PaginationRepositoryImpl _pagination;

        public TenantRepository(ApplicationDbContext context, IMapper mapper) : base(context)
        {
            _pagination = new PaginationRepositoryImpl(context, mapper, this);
        }

        public Task<(IEnumerable<TResult> Items, int TotalCount)> GetPageAsync<TResult>(
            int pageIndex, int pageSize, string? searchTerm, string? sortColumn, string? sortDirection, bool? isActive)
        {
            return _pagination.GetPageAsync<TResult>(pageIndex, pageSize, searchTerm, sortColumn, sortDirection, isActive);
        }

        private class PaginationRepositoryImpl : PaginationRepository<Tenant>
        {
            private readonly TenantRepository _repo;

            public PaginationRepositoryImpl(ApplicationDbContext context, IMapper mapper, TenantRepository repo) : base(context, mapper)
            {
                _repo = repo;
            }

            public override async Task<(IEnumerable<TResult> Items, int TotalCount)> GetPageAsync<TResult>(
                int pageIndex, int pageSize, string? searchTerm, string? sortColumn, string? sortDirection, bool? isActive)
            {
                IQueryable<Tenant> query = _repo.FindAllNoTracking();

                if (!string.IsNullOrEmpty(searchTerm))
                {
                    query = query.Where(t => 
                        t.Name.Contains(searchTerm) || 
                        t.LicenseNumber.Contains(searchTerm) || 
                        t.IdNumber.Contains(searchTerm) ||
                        t.Mobile.Contains(searchTerm));
                }

                // IsActive filter not applicable for Tenant as it doesn't have IsActive property in this model, but keeping it for signature
                
                return await GetPageInternalAsync<TResult>(query, pageIndex, pageSize, sortColumn, sortDirection);
            }
        }
    }
}
