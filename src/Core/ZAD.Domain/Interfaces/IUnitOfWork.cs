using System;
using System.Threading.Tasks;
using ZAD.Domain.Entities.Lookups;
using ZAD.Domain.Interfaces.VehicleRental;
using ZAD.Domain.Entities.VehicleRental.Sponsors;
using ZAD.Domain.Entities.VehicleRental.Drivers;
namespace ZAD.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ICompanyRepository Companies { get; }
        IBranchRepository Branches { get; }
        IGenericRepository<Lookup> Lookups { get; }

        // Vehicle Rental Module
        IContractRepository Contracts { get; }
        ITenantRepository Tenants { get; }
        IDriverRepository Drivers { get; }
        IRentalVehicleRepository RentalVehicles { get; }
        IGenericRepository<Sponsor> Sponsors { get; }
        IGenericRepository<SecondDriver> SecondDrivers { get; }

        Task<int> SaveChangesAsync();
    }
}
