using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ZAD.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class SeedVehicleRentalTenants : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Drivers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drivers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RentalVehicles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlateNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModelYear = table.Column<int>(type: "int", nullable: false),
                    FileNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    KilometerCounter = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentalVehicles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tenants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    LicenseNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PassportNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UnifiedNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IdNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Mobile = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tenants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contracts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Time = table.Column<TimeSpan>(type: "time", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ContractType = table.Column<int>(type: "int", nullable: false),
                    PeriodInDays = table.Column<int>(type: "int", nullable: false),
                    ActualPeriodInDays = table.Column<int>(type: "int", nullable: false),
                    ExpectedReceivingTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    ExpectedReceivingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WithDriver = table.Column<bool>(type: "bit", nullable: false),
                    DriverId = table.Column<int>(type: "int", nullable: true),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    SponsorName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    SponsorNationality = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    SponsorLicenseNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SponsorLicenseExpireDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SponsorIdNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SponsorIdExpireDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RentalVehicleId = table.Column<int>(type: "int", nullable: false),
                    KilometerCounter = table.Column<int>(type: "int", nullable: false),
                    RentPrice = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    DiscountPercent = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    DiscountAmount = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    NetRentPrice = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    DelayPenaltyPerHour = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    AllowedDelayHours = table.Column<int>(type: "int", nullable: false),
                    MaintenancePenalty = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    AccidentPenalty = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    DriverFare = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    DriverWorkingHoursPerDay = table.Column<int>(type: "int", nullable: false),
                    DriverOvertimeAmountPerHour = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    DailyRate = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    KilometerPerDay = table.Column<int>(type: "int", nullable: false),
                    MaximumKilometerPerDay = table.Column<int>(type: "int", nullable: false),
                    AmountOfKmExceedingLimit = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    NextMaintenanceDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NextMaintenanceKm = table.Column<int>(type: "int", nullable: false),
                    ReminderBeforePeriodicMaintenance = table.Column<bool>(type: "bit", nullable: false),
                    NotificationType = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contracts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contracts_Drivers_DriverId",
                        column: x => x.DriverId,
                        principalTable: "Drivers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Contracts_RentalVehicles_RentalVehicleId",
                        column: x => x.RentalVehicleId,
                        principalTable: "RentalVehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Contracts_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Tenants",
                columns: new[] { "Id", "Birthday", "CreatedAt", "IdNumber", "IsDeleted", "LicenseNumber", "Mobile", "Name", "PassportNumber", "UnifiedNumber", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 8, 21, 6, 34, 20, 429, DateTimeKind.Utc).AddTicks(7859), "I1001", false, "L1001", "01000000001", "أحمد محمود", "P1001", "U1001", null },
                    { 2, new DateTime(1985, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 8, 21, 6, 34, 20, 430, DateTimeKind.Utc).AddTicks(1326), "I1002", false, "L1002", "01000000002", "محمد علي", "P1002", "U1002", null },
                    { 3, new DateTime(1992, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 8, 21, 6, 34, 20, 430, DateTimeKind.Utc).AddTicks(1334), "I1003", false, "L1003", "01000000003", "محمود حسن", "P1003", "U1003", null },
                    { 4, new DateTime(1988, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 8, 21, 6, 34, 20, 430, DateTimeKind.Utc).AddTicks(1336), "I1004", false, "L1004", "01000000004", "عمر فاروق", "P1004", "U1004", null },
                    { 5, new DateTime(1995, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 8, 21, 6, 34, 20, 430, DateTimeKind.Utc).AddTicks(1340), "I1005", false, "L1005", "01000000005", "عبد الله إبراهيم", "P1005", "U1005", null },
                    { 6, new DateTime(1980, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 8, 21, 6, 34, 20, 430, DateTimeKind.Utc).AddTicks(1342), "I1006", false, "L1006", "01000000006", "يوسف مصطفى", "P1006", "U1006", null },
                    { 7, new DateTime(1975, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 8, 21, 6, 34, 20, 430, DateTimeKind.Utc).AddTicks(1344), "I1007", false, "L1007", "01000000007", "حسين عبد الرحمن", "P1007", "U1007", null },
                    { 8, new DateTime(1999, 9, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 8, 21, 6, 34, 20, 430, DateTimeKind.Utc).AddTicks(1346), "I1008", false, "L1008", "01000000008", "سعيد سليمان", "P1008", "U1008", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_DriverId",
                table: "Contracts",
                column: "DriverId");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_RentalVehicleId",
                table: "Contracts",
                column: "RentalVehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_TenantId",
                table: "Contracts",
                column: "TenantId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contracts");

            migrationBuilder.DropTable(
                name: "Drivers");

            migrationBuilder.DropTable(
                name: "RentalVehicles");

            migrationBuilder.DropTable(
                name: "Tenants");
        }
    }
}
