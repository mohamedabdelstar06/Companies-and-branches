using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ZAD.Domain.Entities.VehicleRental.Drivers;

namespace ZAD.Persistence.Configurations.VehicleRental
{
    public class DriverConfiguration : IEntityTypeConfiguration<Driver>
    {
        public void Configure(EntityTypeBuilder<Driver> builder)
        {
            builder.ToTable("Drivers");
            builder.HasKey(x => x.Id);
            
            builder.Property(x => x.Name).IsRequired().HasMaxLength(200);
        }
    }
}
