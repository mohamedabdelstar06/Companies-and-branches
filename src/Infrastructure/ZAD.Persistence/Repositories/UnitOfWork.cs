using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ZAD.Domain.Interfaces;
using ZAD.Persistence.Context;
using ZAD.Domain.SeedWork;
using ZAD.Domain.Interfaces.VehicleRental;
using ZAD.Domain.Entities.Lookups;
using ZAD.Domain.Entities.VehicleRental.Sponsors;
using ZAD.Domain.Entities.VehicleRental.Drivers;
using ZAD.Persistence.Repositories.VehicleRental;

namespace ZAD.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        
        public ICompanyRepository Companies { get; }
        public IBranchRepository Branches { get; }
        public IGenericRepository<Lookup> Lookups { get; }

        public IContractRepository Contracts { get; }
        public ITenantRepository Tenants { get; }
        public IDriverRepository Drivers { get; }
        public IRentalVehicleRepository RentalVehicles { get; }
        public IGenericRepository<Sponsor> Sponsors { get; }
        public IGenericRepository<SecondDriver> SecondDrivers { get; }

        public UnitOfWork(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            Companies = new CompanyRepository(_context, _mapper);
            Branches = new BranchRepository(_context, _mapper);
            Lookups = new GenericRepository<Lookup>(_context);

            Contracts = new ContractRepository(_context, _mapper);
            Tenants = new TenantRepository(_context, _mapper);
            Drivers = new DriverRepository(_context);
            RentalVehicles = new RentalVehicleRepository(_context);
            Sponsors = new GenericRepository<Sponsor>(_context);
            SecondDrivers = new GenericRepository<SecondDriver>(_context);
        }

        public async Task<int> SaveChangesAsync()
        {
            foreach (var entry in _context.ChangeTracker.Entries<Entity>())
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.SetCreatedAt(DateTime.UtcNow);
                }
                else if (entry.State == EntityState.Modified)
                {
                    entry.Entity.SetUpdatedAt(DateTime.UtcNow);
                }
            }

            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
