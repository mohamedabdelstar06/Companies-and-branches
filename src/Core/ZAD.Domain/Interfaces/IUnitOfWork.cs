using System;
using System.Threading.Tasks;
using ZAD.Domain.Entities.Lookups;

namespace ZAD.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ICompanyRepository Companies { get; }
        IBranchRepository Branches { get; }
        IGenericRepository<Lookup> Lookups { get; }

        // Vehicle Rental Module
        ZAD.Domain.Interfaces.VehicleRental.IContractRepository Contracts { get; }
        ZAD.Domain.Interfaces.VehicleRental.ITenantRepository Tenants { get; }
        ZAD.Domain.Interfaces.VehicleRental.IDriverRepository Drivers { get; }
        ZAD.Domain.Interfaces.VehicleRental.IRentalVehicleRepository RentalVehicles { get; }
        IGenericRepository<ZAD.Domain.Entities.VehicleRental.Sponsors.Sponsor> Sponsors { get; }
        IGenericRepository<ZAD.Domain.Entities.VehicleRental.Drivers.SecondDriver> SecondDrivers { get; }

        Task<int> SaveChangesAsync();
    }
}
