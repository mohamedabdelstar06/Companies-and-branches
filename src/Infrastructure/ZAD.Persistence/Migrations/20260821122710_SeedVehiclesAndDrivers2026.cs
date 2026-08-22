using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZAD.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class SeedVehiclesAndDrivers2026 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var now = new DateTime(2026, 8, 21, 0, 0, 0, DateTimeKind.Unspecified).ToString("yyyy-MM-dd HH:mm:ss");
            var systemUser = "System";

            // Seed 7 Dummy Drivers
            migrationBuilder.Sql($@"
                SET IDENTITY_INSERT Drivers ON;
                INSERT INTO Drivers (Id, Name, IsDeleted, CreatedAt) VALUES
                (101, 'Ahmed Yassin', 0, '{now}'),
                (102, 'Mohamed Ibrahim', 0, '{now}'),
                (103, 'Khaled Nabil', 0, '{now}'),
                (104, 'Ali Hassan', 0, '{now}'),
                (105, 'Omar Sayed', 0, '{now}'),
                (106, 'Youssef Tarek', 0, '{now}'),
                (107, 'Mahmoud Fawzy', 0, '{now}');
                SET IDENTITY_INSERT Drivers OFF;
            ");

            // Seed 25 Dummy Vehicles
            migrationBuilder.Sql($@"
                SET IDENTITY_INSERT RentalVehicles ON;
                INSERT INTO RentalVehicles (Id, PlateNo, Brand, ModelYear, FileNo, KilometerCounter, MinimumRentPrice, IsRented, IsDeleted, CreatedAt) VALUES
                (101, 'ABC-1234', 'Toyota Camry', '2026', 'CAM-101', 15000, 200, 0, 0, '{now}'),
                (102, 'DEF-5678', 'Honda Accord', '2026', 'ACC-102', 22000, 180, 1, 0, '{now}'),
                (103, 'GHI-9012', 'Tesla Model 3', '2026', 'TES-103', 5000, 350, 0, 0, '{now}'),
                (104, 'JKL-3456', 'Hyundai Tucson', '2026', 'TUC-104', 30000, 250, 0, 0, '{now}'),
                (105, 'MNO-7890', 'Kia Sportage', '2026', 'SPO-105', 12000, 240, 1, 0, '{now}'),
                (106, 'PQR-1234', 'Nissan Altima', '2026', 'ALT-106', 18000, 170, 0, 0, '{now}'),
                (107, 'STU-5678', 'Ford Explorer', '2026', 'EXP-107', 45000, 400, 0, 0, '{now}'),
                (108, 'VWX-9012', 'Chevrolet Tahoe', '2026', 'TAH-108', 60000, 500, 1, 0, '{now}'),
                (109, 'YZA-3456', 'BMW 5 Series', '2026', 'BMW-109', 8000, 600, 0, 0, '{now}'),
                (110, 'BCD-7890', 'Mercedes-Benz E-Class', '2026', 'MER-110', 7500, 650, 0, 0, '{now}'),
                (111, 'EFG-1234', 'Audi A6', '2026', 'AUD-111', 11000, 550, 1, 0, '{now}'),
                (112, 'HIJ-5678', 'Lexus ES', '2026', 'LEX-112', 14000, 450, 0, 0, '{now}'),
                (113, 'KLM-9012', 'Jeep Grand Cherokee', '2026', 'JEP-113', 25000, 380, 0, 0, '{now}'),
                (114, 'NOP-3456', 'Mazda CX-5', '2026', 'MAZ-114', 32000, 210, 0, 0, '{now}'),
                (115, 'QRS-7890', 'Subaru Outback', '2026', 'SUB-115', 28000, 220, 1, 0, '{now}'),
                (116, 'TUV-1234', 'Volkswagen Tiguan', '2026', 'VOL-116', 19000, 230, 0, 0, '{now}'),
                (117, 'WXY-5678', 'Volvo XC60', '2026', 'VOL-117', 9000, 480, 0, 0, '{now}'),
                (118, 'ZAB-9012', 'Porsche Macan', '2026', 'POR-118', 6000, 750, 1, 0, '{now}'),
                (119, 'CDE-3456', 'Land Rover Defender', '2026', 'LAN-119', 13000, 700, 0, 0, '{now}'),
                (120, 'FGH-7890', 'Genesis GV70', '2026', 'GEN-120', 16000, 420, 0, 0, '{now}'),
                (121, 'IJK-1234', 'Acura MDX', '2026', 'ACU-121', 21000, 400, 1, 0, '{now}'),
                (122, 'LMN-5678', 'Infiniti QX60', '2026', 'INF-122', 24000, 390, 0, 0, '{now}'),
                (123, 'OPQ-9012', 'Cadillac Escalade', '2026', 'CAD-123', 40000, 800, 0, 0, '{now}'),
                (124, 'RST-3456', 'Lincoln Aviator', '2026', 'LIN-124', 35000, 780, 1, 0, '{now}'),
                (125, 'UVW-7890', 'GMC Yukon', '2026', 'GMC-125', 50000, 650, 0, 0, '{now}');
                SET IDENTITY_INSERT RentalVehicles OFF;
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Drivers WHERE Id BETWEEN 101 AND 107;");
            migrationBuilder.Sql("DELETE FROM RentalVehicles WHERE Id BETWEEN 101 AND 125;");
        }
    }
}
