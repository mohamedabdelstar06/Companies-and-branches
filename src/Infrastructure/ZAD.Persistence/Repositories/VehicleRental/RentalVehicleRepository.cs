using ZAD.Domain.Entities.VehicleRental.Vehicles;
using ZAD.Domain.Interfaces.VehicleRental;
using ZAD.Persistence.Context;

namespace ZAD.Persistence.Repositories.VehicleRental
{
    public class RentalVehicleRepository : GenericRepository<RentalVehicle>, IRentalVehicleRepository
    {
        public RentalVehicleRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
