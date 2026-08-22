using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ZAD.Domain.Entities.VehicleRental.Contracts;

namespace ZAD.Persistence.Configurations.VehicleRental
{
    public class ContractConfiguration : IEntityTypeConfiguration<Contract>
    {
        public void Configure(EntityTypeBuilder<Contract> builder)
        {
            builder.ToTable("Contracts");
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Tenant)
                   .WithMany()
                   .HasForeignKey(x => x.TenantId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Driver)
                   .WithMany()
                   .HasForeignKey(x => x.DriverId)
                   .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(x => x.RentalVehicle)
                   .WithMany()
                   .HasForeignKey(x => x.RentalVehicleId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Company)
                   .WithMany()
                   .HasForeignKey(x => x.CompanyId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Branch)
                   .WithMany()
                   .HasForeignKey(x => x.BranchId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Money properties precise decimal types
            builder.Property(x => x.RentPrice).HasColumnType("decimal(18,4)");
            builder.Property(x => x.DiscountPercent).HasColumnType("decimal(18,4)");
            builder.Property(x => x.DiscountAmount).HasColumnType("decimal(18,4)");
            builder.Property(x => x.NetRentPrice).HasColumnType("decimal(18,4)");
            
            builder.Property(x => x.DelayPenaltyPerHour).HasColumnType("decimal(18,4)");
            builder.Property(x => x.MaintenancePenalty).HasColumnType("decimal(18,4)");
            builder.Property(x => x.AccidentPenalty).HasColumnType("decimal(18,4)");
            
            builder.Property(x => x.DriverFare).HasColumnType("decimal(18,4)");
            builder.Property(x => x.DriverOvertimeAmountPerHour).HasColumnType("decimal(18,4)");
            builder.Property(x => x.DailyRate).HasColumnType("decimal(18,4)");
            
            builder.Property(x => x.AmountOfKmExceedingLimit).HasColumnType("decimal(18,4)");
            builder.Property(x => x.RemainingAmount).HasColumnType("decimal(18,4)");

            // Sponsor properties length
            builder.Property(x => x.SponsorName).HasMaxLength(200);
            builder.Property(x => x.SponsorNationality).HasMaxLength(100);
            builder.Property(x => x.SponsorLicenseNumber).HasMaxLength(50);
            builder.Property(x => x.SponsorIdNumber).HasMaxLength(50);
        }
    }
}
