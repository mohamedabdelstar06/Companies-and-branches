using System.Reflection;
using Microsoft.EntityFrameworkCore;
using ZAD.Domain.Entities.Branches;
using ZAD.Domain.Entities.Companies;
using ZAD.Domain.Entities.Lookups;
using ZAD.Domain.SeedWork;
using ZAD.Domain.Entities.VehicleRental.Tenants;
using ZAD.Domain.Entities.VehicleRental.Drivers;
using ZAD.Domain.Entities.VehicleRental.Sponsors;
using ZAD.Domain.Entities.VehicleRental.Vehicles;
using ZAD.Domain.Entities.VehicleRental.Contracts;

namespace ZAD.Persistence.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        // Settings module 
        public DbSet<Company> Companies { get; set; } = null!;
        public DbSet<Branch> Branches { get; set; } = null!;
        public DbSet<Lookup> Lookups { get; set; } = null!;
        // Vehicle Rental Module
        public DbSet<Tenant> Tenants { get; set; } = null!;
        public DbSet<Driver> Drivers { get; set; } = null!;
        public DbSet<Sponsor> Sponsors { get; set; } = null!;
        public DbSet<RentalVehicle> RentalVehicles { get; } = null!;
        public DbSet<Contract> Contracts { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Entity<Company>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<Branch>().HasQueryFilter(x => !x.IsDeleted);

            modelBuilder.Entity<Tenant>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<Driver>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<Sponsor>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<RentalVehicle>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<Contract>().HasQueryFilter(x => !x.IsDeleted);
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
