using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ZAD.Domain.Entities.VehicleRental.Vehicles;

namespace ZAD.Persistence.Configurations.VehicleRental
{
    public class RentalVehicleConfiguration : IEntityTypeConfiguration<RentalVehicle>
    {
        public void Configure(EntityTypeBuilder<RentalVehicle> builder)
        {
            builder.ToTable("RentalVehicles");
            builder.HasKey(x => x.Id);
            
            builder.Property(x => x.Brand).HasMaxLength(100);
            builder.Property(x => x.PlateNo).IsRequired().HasMaxLength(50);
            builder.Property(x => x.FileNo).HasMaxLength(50);
            builder.Property(x => x.HourlyRentPrice).HasColumnType("decimal(18,2)");
            builder.Property(x => x.DailyRentPrice).HasColumnType("decimal(18,2)");
            builder.Property(x => x.WeeklyRentPrice).HasColumnType("decimal(18,2)");
            builder.Property(x => x.MonthlyRentPrice).HasColumnType("decimal(18,2)");
            builder.Property(x => x.YearlyRentPrice).HasColumnType("decimal(18,2)");



            var now = new System.DateTime(2026, 1, 1, 0, 0, 0, System.DateTimeKind.Utc);
            
            // Seed dummy vehicles with varied types and realistic EGP pricing
            builder.HasData(
                new { Id = 1, Brand = "KIA Cerato", PlateNo = "77777", ModelYear = 2026, FileNo = "F-001", KilometerCounter = 10000, Type = ZAD.Domain.Enums.VehicleRental.VehicleType.Private, HourlyRentPrice = 60m, DailyRentPrice = 600m, WeeklyRentPrice = 3600m, MonthlyRentPrice = 12000m, YearlyRentPrice = 120000m, IsRented = true, IsDeleted = false, CreatedAt = now },
                new { Id = 2, Brand = "KIA Sportage", PlateNo = "3030", ModelYear = 2026, FileNo = "F-002", KilometerCounter = 12000, Type = ZAD.Domain.Enums.VehicleRental.VehicleType.Private, HourlyRentPrice = 80m, DailyRentPrice = 800m, WeeklyRentPrice = 4800m, MonthlyRentPrice = 16000m, YearlyRentPrice = 160000m, IsRented = true, IsDeleted = false, CreatedAt = now },
                new { Id = 3, Brand = "Toyota Hiace", PlateNo = "EXT 1111", ModelYear = 2026, FileNo = "F-003", KilometerCounter = 15000, Type = ZAD.Domain.Enums.VehicleRental.VehicleType.Microbus, HourlyRentPrice = 120m, DailyRentPrice = 1200m, WeeklyRentPrice = 7200m, MonthlyRentPrice = 24000m, YearlyRentPrice = 240000m, IsRented = true, IsDeleted = false, CreatedAt = now },
                new { Id = 4, Brand = "Nissan Patrol", PlateNo = "ACB-4578", ModelYear = 2026, FileNo = "F-004", KilometerCounter = 20000, Type = ZAD.Domain.Enums.VehicleRental.VehicleType.Private, HourlyRentPrice = 150m, DailyRentPrice = 1500m, WeeklyRentPrice = 9000m, MonthlyRentPrice = 30000m, YearlyRentPrice = 300000m, IsRented = true, IsDeleted = false, CreatedAt = now },
                new { Id = 5, Brand = "Kia Sonet", PlateNo = "ABC 1245", ModelYear = 2026, FileNo = "F-005", KilometerCounter = 8000, Type = ZAD.Domain.Enums.VehicleRental.VehicleType.Private, HourlyRentPrice = 70m, DailyRentPrice = 700m, WeeklyRentPrice = 4200m, MonthlyRentPrice = 14000m, YearlyRentPrice = 140000m, IsRented = true, IsDeleted = false, CreatedAt = now },
                new { Id = 6, Brand = "Kia Sonet", PlateNo = "DEF 1478", ModelYear = 2011, FileNo = "DEF 1478", KilometerCounter = 40000, Type = ZAD.Domain.Enums.VehicleRental.VehicleType.Private, HourlyRentPrice = 40m, DailyRentPrice = 400m, WeeklyRentPrice = 2400m, MonthlyRentPrice = 8000m, YearlyRentPrice = 80000m, IsRented = false, IsDeleted = false, CreatedAt = now },
                new { Id = 7, Brand = "Toyota Corolla", PlateNo = "XYZ 999", ModelYear = 2026, FileNo = "F-007", KilometerCounter = 5000, Type = ZAD.Domain.Enums.VehicleRental.VehicleType.Private, HourlyRentPrice = 70m, DailyRentPrice = 700m, WeeklyRentPrice = 4200m, MonthlyRentPrice = 14000m, YearlyRentPrice = 140000m, IsRented = false, IsDeleted = false, CreatedAt = now },
                new { Id = 8, Brand = "Toyota Coaster", PlateNo = "LMN 456", ModelYear = 2026, FileNo = "F-008", KilometerCounter = 6000, Type = ZAD.Domain.Enums.VehicleRental.VehicleType.Microbus, HourlyRentPrice = 150m, DailyRentPrice = 1500m, WeeklyRentPrice = 9000m, MonthlyRentPrice = 30000m, YearlyRentPrice = 300000m, IsRented = false, IsDeleted = false, CreatedAt = now },
                new { Id = 9, Brand = "Honda Civic", PlateNo = "PQR 789", ModelYear = 2026, FileNo = "F-009", KilometerCounter = 7000, Type = ZAD.Domain.Enums.VehicleRental.VehicleType.Private, HourlyRentPrice = 75m, DailyRentPrice = 750m, WeeklyRentPrice = 4500m, MonthlyRentPrice = 15000m, YearlyRentPrice = 150000m, IsRented = false, IsDeleted = false, CreatedAt = now },
                new { Id = 10, Brand = "Hyundai Elantra", PlateNo = "STU 123", ModelYear = 2026, FileNo = "F-010", KilometerCounter = 9000, Type = ZAD.Domain.Enums.VehicleRental.VehicleType.Private, HourlyRentPrice = 65m, DailyRentPrice = 650m, WeeklyRentPrice = 3900m, MonthlyRentPrice = 13000m, YearlyRentPrice = 130000m, IsRented = false, IsDeleted = false, CreatedAt = now },
                new { Id = 11, Brand = "Chevrolet NPR", PlateNo = "VWX 456", ModelYear = 2026, FileNo = "F-011", KilometerCounter = 25000, Type = ZAD.Domain.Enums.VehicleRental.VehicleType.Truck, HourlyRentPrice = 200m, DailyRentPrice = 2000m, WeeklyRentPrice = 12000m, MonthlyRentPrice = 40000m, YearlyRentPrice = 400000m, IsRented = false, IsDeleted = false, CreatedAt = now },
                new { Id = 12, Brand = "Ford Explorer", PlateNo = "YZA 789", ModelYear = 2026, FileNo = "F-012", KilometerCounter = 22000, Type = ZAD.Domain.Enums.VehicleRental.VehicleType.Private, HourlyRentPrice = 120m, DailyRentPrice = 1200m, WeeklyRentPrice = 7200m, MonthlyRentPrice = 24000m, YearlyRentPrice = 240000m, IsRented = false, IsDeleted = false, CreatedAt = now },
                new { Id = 13, Brand = "Mazda CX-5", PlateNo = "BCD 012", ModelYear = 2026, FileNo = "F-013", KilometerCounter = 14000, Type = ZAD.Domain.Enums.VehicleRental.VehicleType.Private, HourlyRentPrice = 90m, DailyRentPrice = 900m, WeeklyRentPrice = 5400m, MonthlyRentPrice = 18000m, YearlyRentPrice = 180000m, IsRented = false, IsDeleted = false, CreatedAt = now },
                new { Id = 14, Brand = "Nissan Altima", PlateNo = "EFG 345", ModelYear = 2026, FileNo = "F-014", KilometerCounter = 11000, Type = ZAD.Domain.Enums.VehicleRental.VehicleType.Private, HourlyRentPrice = 75m, DailyRentPrice = 750m, WeeklyRentPrice = 4500m, MonthlyRentPrice = 15000m, YearlyRentPrice = 150000m, IsRented = false, IsDeleted = false, CreatedAt = now },
                new { Id = 15, Brand = "BMW 3 Series", PlateNo = "HIJ 678", ModelYear = 2026, FileNo = "F-015", KilometerCounter = 18000, Type = ZAD.Domain.Enums.VehicleRental.VehicleType.Private, HourlyRentPrice = 200m, DailyRentPrice = 2000m, WeeklyRentPrice = 12000m, MonthlyRentPrice = 40000m, YearlyRentPrice = 400000m, IsRented = false, IsDeleted = false, CreatedAt = now },
                new { Id = 16, Brand = "Mercedes S-Class", PlateNo = "KLM 901", ModelYear = 2026, FileNo = "F-016", KilometerCounter = 16000, Type = ZAD.Domain.Enums.VehicleRental.VehicleType.Private, HourlyRentPrice = 400m, DailyRentPrice = 4000m, WeeklyRentPrice = 24000m, MonthlyRentPrice = 80000m, YearlyRentPrice = 800000m, IsRented = false, IsDeleted = false, CreatedAt = now },
                new { Id = 17, Brand = "Audi A4", PlateNo = "NOP 234", ModelYear = 2026, FileNo = "F-017", KilometerCounter = 17000, Type = ZAD.Domain.Enums.VehicleRental.VehicleType.Private, HourlyRentPrice = 180m, DailyRentPrice = 1800m, WeeklyRentPrice = 10800m, MonthlyRentPrice = 36000m, YearlyRentPrice = 360000m, IsRented = false, IsDeleted = false, CreatedAt = now },
                new { Id = 18, Brand = "Lexus ES", PlateNo = "QRS 567", ModelYear = 2026, FileNo = "F-018", KilometerCounter = 13000, Type = ZAD.Domain.Enums.VehicleRental.VehicleType.Private, HourlyRentPrice = 160m, DailyRentPrice = 1600m, WeeklyRentPrice = 9600m, MonthlyRentPrice = 32000m, YearlyRentPrice = 320000m, IsRented = false, IsDeleted = false, CreatedAt = now },
                new { Id = 19, Brand = "Mercedes Sprinter", PlateNo = "TUV 890", ModelYear = 2026, FileNo = "F-019", KilometerCounter = 21000, Type = ZAD.Domain.Enums.VehicleRental.VehicleType.Microbus, HourlyRentPrice = 250m, DailyRentPrice = 2500m, WeeklyRentPrice = 15000m, MonthlyRentPrice = 50000m, YearlyRentPrice = 500000m, IsRented = false, IsDeleted = false, CreatedAt = now },
                new { Id = 20, Brand = "Volkswagen Tiguan", PlateNo = "WXY 123", ModelYear = 2026, FileNo = "F-020", KilometerCounter = 19000, Type = ZAD.Domain.Enums.VehicleRental.VehicleType.Private, HourlyRentPrice = 100m, DailyRentPrice = 1000m, WeeklyRentPrice = 6000m, MonthlyRentPrice = 20000m, YearlyRentPrice = 200000m, IsRented = false, IsDeleted = false, CreatedAt = now },
                new { Id = 21, Brand = "Mitsubishi Fuso", PlateNo = "ZAB 456", ModelYear = 2026, FileNo = "F-021", KilometerCounter = 24000, Type = ZAD.Domain.Enums.VehicleRental.VehicleType.Truck, HourlyRentPrice = 180m, DailyRentPrice = 1800m, WeeklyRentPrice = 10800m, MonthlyRentPrice = 36000m, YearlyRentPrice = 360000m, IsRented = false, IsDeleted = false, CreatedAt = now }
            );
        }
    }
}
