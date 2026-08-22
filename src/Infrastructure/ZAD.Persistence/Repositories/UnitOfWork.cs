using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ZAD.Domain.Interfaces;
using ZAD.Persistence.Context;
using ZAD.Domain.SeedWork;

namespace ZAD.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        
        public ICompanyRepository Companies { get; }
        public IBranchRepository Branches { get; }
        public IGenericRepository<ZAD.Domain.Entities.Lookups.Lookup> Lookups { get; }

        public ZAD.Domain.Interfaces.VehicleRental.IContractRepository Contracts { get; }
        public ZAD.Domain.Interfaces.VehicleRental.ITenantRepository Tenants { get; }
        public ZAD.Domain.Interfaces.VehicleRental.IDriverRepository Drivers { get; }
        public ZAD.Domain.Interfaces.VehicleRental.IRentalVehicleRepository RentalVehicles { get; }
        public IGenericRepository<ZAD.Domain.Entities.VehicleRental.Sponsors.Sponsor> Sponsors { get; }
        public IGenericRepository<ZAD.Domain.Entities.VehicleRental.Drivers.SecondDriver> SecondDrivers { get; }

        public UnitOfWork(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            Companies = new CompanyRepository(_context, _mapper);
            Branches = new BranchRepository(_context, _mapper);
            Lookups = new GenericRepository<ZAD.Domain.Entities.Lookups.Lookup>(_context);

            Contracts = new ZAD.Persistence.Repositories.VehicleRental.ContractRepository(_context, _mapper);
            Tenants = new ZAD.Persistence.Repositories.VehicleRental.TenantRepository(_context, _mapper);
            Drivers = new ZAD.Persistence.Repositories.VehicleRental.DriverRepository(_context);
            RentalVehicles = new ZAD.Persistence.Repositories.VehicleRental.RentalVehicleRepository(_context);
            Sponsors = new GenericRepository<ZAD.Domain.Entities.VehicleRental.Sponsors.Sponsor>(_context);
            SecondDrivers = new GenericRepository<ZAD.Domain.Entities.VehicleRental.Drivers.SecondDriver>(_context);
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
