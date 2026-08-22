using ZAD.Domain.SeedWork;

namespace ZAD.Domain.Entities.VehicleRental.Drivers
{
    public class Driver : Entity
    {
        public string Name { get; private set; } = string.Empty;

        private Driver() { } // EF Core

        public Driver(string name)
        {
            Name = name;
        }

        public void Update(string name)
        {
            Name = name;
        }
    }
}
