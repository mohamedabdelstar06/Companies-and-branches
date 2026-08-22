using ZAD.Domain.Entities.VehicleRental.Tenants;
using ZAD.Domain.Interfaces;

namespace ZAD.Domain.Interfaces.VehicleRental
{
    public interface ITenantRepository : IGenericRepository<Tenant>, IPaginationRepository<Tenant>
    {
    }
}
