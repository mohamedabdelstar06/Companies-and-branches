using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ZAD.Domain.Entities.VehicleRental.Contracts;
using ZAD.Domain.Interfaces.VehicleRental;
using ZAD.Persistence.Context;

namespace ZAD.Persistence.Repositories.VehicleRental
{
    public class ContractRepository : GenericRepository<Contract>, IContractRepository
    {
        private readonly PaginationRepositoryImpl _pagination;

        public ContractRepository(ApplicationDbContext context, IMapper mapper) : base(context)
        {
            _pagination = new PaginationRepositoryImpl(context, mapper, this);
        }

        public override async Task<Contract?> GetByIdAsync(int id)
        {
            return await _dbSet
                .IgnoreQueryFilters()
                .Include(c => c.Tenant)
                .Include(c => c.Driver)
                .Include(c => c.RentalVehicle)
                .Include(c => c.Company)
                .Include(c => c.Branch)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public Task<(IEnumerable<TResult> Items, int TotalCount)> GetPageAsync<TResult>(
            int pageIndex, int pageSize, string? searchTerm, string? sortColumn, string? sortDirection, bool? isActive)
        {
            return _pagination.GetPageAsync<TResult>(pageIndex, pageSize, searchTerm, sortColumn, sortDirection, isActive);
        }

        private class PaginationRepositoryImpl : PaginationRepository<Contract>
        {
            private readonly ContractRepository _repo;

            public PaginationRepositoryImpl(ApplicationDbContext context, IMapper mapper, ContractRepository repo) : base(context, mapper)
            {
                _repo = repo;
            }

            public override async Task<(IEnumerable<TResult> Items, int TotalCount)> GetPageAsync<TResult>(
                int pageIndex, int pageSize, string? searchTerm, string? sortColumn, string? sortDirection, bool? isActive)
            {
                IQueryable<Contract> query = _repo.FindAllNoTracking()
                    .IgnoreQueryFilters()
                    .Include(c => c.Tenant)
                    .Include(c => c.RentalVehicle);

                if (!string.IsNullOrEmpty(searchTerm))
                {
                    query = query.Where(c => 
                        (c.Tenant != null && c.Tenant.Name.Contains(searchTerm)) || 
                        (c.RentalVehicle != null && c.RentalVehicle.PlateNo.Contains(searchTerm)));
                }

                return await GetPageInternalAsync<TResult>(query, pageIndex, pageSize, sortColumn, sortDirection);
            }

            public async Task<(IEnumerable<TResult> Items, int TotalCount)> GetPageWithContextAsync<TResult>(
                int pageIndex, int pageSize, string? searchTerm, string? sortColumn, string? sortDirection, int? companyId, int? branchId)
            {
                IQueryable<Contract> query = _repo.FindAllNoTracking()
                    .IgnoreQueryFilters()
                    .Include(c => c.Tenant)
                    .Include(c => c.RentalVehicle)
                    .Include(c => c.Company)
                    .Include(c => c.Branch);

                if (companyId.HasValue)
                {
                    query = query.Where(c => c.CompanyId == companyId.Value);
                }

                if (branchId.HasValue)
                {
                    query = query.Where(c => c.BranchId == branchId.Value);
                }

                if (!string.IsNullOrEmpty(searchTerm))
                {
                    query = query.Where(c => 
                        (c.Tenant != null && c.Tenant.Name.Contains(searchTerm)) || 
                        (c.RentalVehicle != null && c.RentalVehicle.PlateNo.Contains(searchTerm)));
                }

                return await GetPageInternalAsync<TResult>(query, pageIndex, pageSize, sortColumn, sortDirection);
            }
        }

        public Task<(IEnumerable<TResult> Items, int TotalCount)> GetPageWithContextAsync<TResult>(
            int pageIndex, int pageSize, string? searchTerm, string? sortColumn, string? sortDirection, int? companyId, int? branchId)
        {
            return _pagination.GetPageWithContextAsync<TResult>(pageIndex, pageSize, searchTerm, sortColumn, sortDirection, companyId, branchId);
        }
    }
}
