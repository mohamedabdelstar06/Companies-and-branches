using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ZAD.Domain.Entities.Branches;
using ZAD.Domain.Entities.Companies;
using ZAD.Domain.Entities.Lookups;
using ZAD.Domain.SeedWork;

namespace ZAD.Persistence.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Company> Companies { get; set; } = null!;
        public DbSet<Branch> Branches { get; set; } = null!;
        public DbSet<Lookup> Lookups { get; set; } = null!;

        // Vehicle Rental Module
        public DbSet<ZAD.Domain.Entities.VehicleRental.Tenants.Tenant> Tenants { get; set; } = null!;
        public DbSet<ZAD.Domain.Entities.VehicleRental.Drivers.Driver> Drivers { get; set; } = null!;
        public DbSet<ZAD.Domain.Entities.VehicleRental.Sponsors.Sponsor> Sponsors { get; set; } = null!;
        public DbSet<ZAD.Domain.Entities.VehicleRental.Drivers.SecondDriver> SecondDrivers { get; set; } = null!;
        public DbSet<ZAD.Domain.Entities.VehicleRental.Vehicles.RentalVehicle> RentalVehicles { get; } = null!;
        public DbSet<ZAD.Domain.Entities.VehicleRental.Contracts.Contract> Contracts { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Entity<Company>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<Branch>().HasQueryFilter(x => !x.IsDeleted);

            modelBuilder.Entity<ZAD.Domain.Entities.VehicleRental.Tenants.Tenant>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<ZAD.Domain.Entities.VehicleRental.Drivers.Driver>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<ZAD.Domain.Entities.VehicleRental.Sponsors.Sponsor>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<ZAD.Domain.Entities.VehicleRental.Drivers.SecondDriver>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<ZAD.Domain.Entities.VehicleRental.Vehicles.RentalVehicle>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<ZAD.Domain.Entities.VehicleRental.Contracts.Contract>().HasQueryFilter(x => !x.IsDeleted);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entitiesWithEvents = ChangeTracker.Entries<Entity>()
                .Select(e => e.Entity)
                .Where(e => e.DomainEvents != null && e.DomainEvents.Any())
                .ToList();

            int result = await base.SaveChangesAsync(cancellationToken);

            foreach (var entity in entitiesWithEvents)
            {
                entity.ClearDomainEvents();
            }

            return result;
        }
    }
}
