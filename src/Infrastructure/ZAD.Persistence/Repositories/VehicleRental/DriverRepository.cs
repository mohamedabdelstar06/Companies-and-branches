using ZAD.Domain.Entities.VehicleRental.Drivers;
using ZAD.Domain.Interfaces.VehicleRental;
using ZAD.Persistence.Context;

namespace ZAD.Persistence.Repositories.VehicleRental
{
    public class DriverRepository : GenericRepository<Driver>, IDriverRepository
    {
        public DriverRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
