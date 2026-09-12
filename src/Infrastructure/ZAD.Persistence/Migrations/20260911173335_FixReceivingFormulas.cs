using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ZAD.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class FixReceivingFormulas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NameAr = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    NameEn = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    AddressAr = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    AddressEn = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Nationality = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Language = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LogoPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Drivers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Nationality = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LicenseNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LicenseExpireDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdExpireDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DriverFare = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DriverWorkingHoursPerDay = table.Column<int>(type: "int", nullable: false),
                    DriverOvertimeAmountPerHour = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DailyRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drivers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lookups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LookupKey = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Culture = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lookups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RentalVehicles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Brand = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PlateNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModelYear = table.Column<int>(type: "int", nullable: false),
                    FileNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    KilometerCounter = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    HourlyRentPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DailyRentPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    WeeklyRentPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MonthlyRentPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    YearlyRentPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsRented = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentalVehicles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sponsors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nationality = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LicenseNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LicenseExpireDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdExpireDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sponsors", x => x.Id);
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
                name: "Branches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NameAr = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    NameEn = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    AddressAr = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    AddressEn = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CostCenter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsMainBranch = table.Column<bool>(type: "bit", nullable: false),
                    LogoPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Branches_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CompanyContacts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyContacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanyContacts_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CompanyDocuments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<int>(type: "int", nullable: false),
                    DocumentNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyDocuments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanyDocuments_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BranchContacts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    BranchId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BranchContacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BranchContacts_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BranchDocuments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<int>(type: "int", nullable: false),
                    DocumentNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BranchId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BranchDocuments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BranchDocuments_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Contracts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<int>(type: "int", nullable: true),
                    BranchId = table.Column<int>(type: "int", nullable: true),
                    Time = table.Column<TimeSpan>(type: "time", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ContractType = table.Column<int>(type: "int", nullable: false),
                    PaymentType = table.Column<int>(type: "int", nullable: false),
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
                    SecondDriverName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecondDriverNationality = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecondDriverLicenseNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecondDriverLicenseExpireDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SecondDriverIdNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecondDriverIdExpireDate = table.Column<DateTime>(type: "datetime2", nullable: true),
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
                    DeliveryStatus = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    RemainingAmount = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    ReceivingDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ReceivingTime = table.Column<TimeSpan>(type: "time", nullable: true),
                    ReceivingKilometerCounter = table.Column<int>(type: "int", nullable: true),
                    ReceiveProofDocuments = table.Column<bool>(type: "bit", nullable: true),
                    ReceiveNotes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaintenancePaidByTenant = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsMaintenanceDoneByTenant = table.Column<bool>(type: "bit", nullable: false),
                    VehicleReceivingStatus = table.Column<int>(type: "int", nullable: true),
                    IsVehicleStoppedUntilMaintenanceOrRepair = table.Column<bool>(type: "bit", nullable: false),
                    DamageNote = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReceiveDiscountAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    VehicleDailyRentPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ContractNextMaintenanceDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ContractNextMaintenanceKM = table.Column<int>(type: "int", nullable: true),
                    AVGKilometersPerDay = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DelayHours = table.Column<int>(type: "int", nullable: true),
                    TotalConsumptionKilometers = table.Column<int>(type: "int", nullable: true),
                    FreeKM = table.Column<int>(type: "int", nullable: true),
                    KMExceededTheLimit = table.Column<int>(type: "int", nullable: true),
                    TotalAmountOfKMExceedingTheLimit = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DelayPenaltyAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TotalRentalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TotalDriverAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TotalDueAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    FinalNetDueAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contracts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contracts_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Contracts_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                table: "RentalVehicles",
                columns: new[] { "Id", "Brand", "CreatedAt", "DailyRentPrice", "FileNo", "HourlyRentPrice", "IsDeleted", "IsRented", "KilometerCounter", "ModelYear", "MonthlyRentPrice", "PlateNo", "Type", "UpdatedAt", "WeeklyRentPrice", "YearlyRentPrice" },
                values: new object[,]
                {
                    { 1, "KIA Cerato", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 600m, "F-001", 60m, false, true, 10000, 2026, 12000m, "77777", 1, null, 3600m, 120000m },
                    { 2, "KIA Sportage", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 800m, "F-002", 80m, false, true, 12000, 2026, 16000m, "3030", 1, null, 4800m, 160000m },
                    { 3, "Toyota Hiace", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1200m, "F-003", 120m, false, true, 15000, 2026, 24000m, "EXT 1111", 2, null, 7200m, 240000m },
                    { 4, "Nissan Patrol", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1500m, "F-004", 150m, false, true, 20000, 2026, 30000m, "ACB-4578", 1, null, 9000m, 300000m },
                    { 5, "Kia Sonet", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 700m, "F-005", 70m, false, true, 8000, 2026, 14000m, "ABC 1245", 1, null, 4200m, 140000m },
                    { 6, "Kia Sonet", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 400m, "DEF 1478", 40m, false, false, 40000, 2011, 8000m, "DEF 1478", 1, null, 2400m, 80000m },
                    { 7, "Toyota Corolla", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 700m, "F-007", 70m, false, false, 5000, 2026, 14000m, "XYZ 999", 1, null, 4200m, 140000m },
                    { 8, "Toyota Coaster", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1500m, "F-008", 150m, false, false, 6000, 2026, 30000m, "LMN 456", 2, null, 9000m, 300000m },
                    { 9, "Honda Civic", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 750m, "F-009", 75m, false, false, 7000, 2026, 15000m, "PQR 789", 1, null, 4500m, 150000m },
                    { 10, "Hyundai Elantra", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 650m, "F-010", 65m, false, false, 9000, 2026, 13000m, "STU 123", 1, null, 3900m, 130000m },
                    { 11, "Chevrolet NPR", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 2000m, "F-011", 200m, false, false, 25000, 2026, 40000m, "VWX 456", 3, null, 12000m, 400000m },
                    { 12, "Ford Explorer", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1200m, "F-012", 120m, false, false, 22000, 2026, 24000m, "YZA 789", 1, null, 7200m, 240000m },
                    { 13, "Mazda CX-5", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 900m, "F-013", 90m, false, false, 14000, 2026, 18000m, "BCD 012", 1, null, 5400m, 180000m },
                    { 14, "Nissan Altima", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 750m, "F-014", 75m, false, false, 11000, 2026, 15000m, "EFG 345", 1, null, 4500m, 150000m },
                    { 15, "BMW 3 Series", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 2000m, "F-015", 200m, false, false, 18000, 2026, 40000m, "HIJ 678", 1, null, 12000m, 400000m },
                    { 16, "Mercedes S-Class", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 4000m, "F-016", 400m, false, false, 16000, 2026, 80000m, "KLM 901", 1, null, 24000m, 800000m },
                    { 17, "Audi A4", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1800m, "F-017", 180m, false, false, 17000, 2026, 36000m, "NOP 234", 1, null, 10800m, 360000m },
                    { 18, "Lexus ES", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1600m, "F-018", 160m, false, false, 13000, 2026, 32000m, "QRS 567", 1, null, 9600m, 320000m },
                    { 19, "Mercedes Sprinter", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 2500m, "F-019", 250m, false, false, 21000, 2026, 50000m, "TUV 890", 2, null, 15000m, 500000m },
                    { 20, "Volkswagen Tiguan", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1000m, "F-020", 100m, false, false, 19000, 2026, 20000m, "WXY 123", 1, null, 6000m, 200000m },
                    { 21, "Mitsubishi Fuso", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1800m, "F-021", 180m, false, false, 24000, 2026, 36000m, "ZAB 456", 3, null, 10800m, 360000m }
                });

            migrationBuilder.InsertData(
                table: "Tenants",
                columns: new[] { "Id", "Birthday", "CreatedAt", "IdNumber", "IsDeleted", "LicenseNumber", "Mobile", "Name", "PassportNumber", "UnifiedNumber", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "I1001", false, "L1001", "01000000001", "أحمد محمود", "P1001", "U1001", null },
                    { 2, new DateTime(1985, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "I1002", false, "L1002", "01000000002", "محمد علي", "P1002", "U1002", null },
                    { 3, new DateTime(1992, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "I1003", false, "L1003", "01000000003", "محمود حسن", "P1003", "U1003", null },
                    { 4, new DateTime(1988, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "I1004", false, "L1004", "01000000004", "عمر فاروق", "P1004", "U1004", null },
                    { 5, new DateTime(1995, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "I1005", false, "L1005", "01000000005", "عبد الله إبراهيم", "P1005", "U1005", null },
                    { 6, new DateTime(1980, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "I1006", false, "L1006", "01000000006", "يوسف مصطفى", "P1006", "U1006", null },
                    { 7, new DateTime(1975, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "I1007", false, "L1007", "01000000007", "حسين عبد الرحمن", "P1007", "U1007", null },
                    { 8, new DateTime(1999, 9, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "I1008", false, "L1008", "01000000008", "سعيد سليمان", "P1008", "U1008", null },
                    { 9, new DateTime(1971, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "I1009", false, "L1009", "01000000009", "طارق يحيى", "P1009", "U1009", null },
                    { 10, new DateTime(1982, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "I1010", false, "L1010", "01000000010", "حسن حمدي", "P1010", "U1010", null },
                    { 11, new DateTime(1993, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "I1011", false, "L1011", "01000000011", "خالد زكي", "P1011", "U1011", null },
                    { 12, new DateTime(1978, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "I1012", false, "L1012", "01000000012", "ماجد الكدواني", "P1012", "U1012", null },
                    { 13, new DateTime(1989, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "I1013", false, "L1013", "01000000013", "أمير كرارة", "P1013", "U1013", null },
                    { 14, new DateTime(1996, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "I1014", false, "L1014", "01000000014", "صالح جمعة", "P1014", "U1014", null },
                    { 15, new DateTime(1997, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "I1015", false, "L1015", "01000000015", "عبد الله جمعة", "P1015", "U1015", null },
                    { 16, new DateTime(1991, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "I1016", false, "L1016", "01000000016", "باسم مرسي", "P1016", "U1016", null },
                    { 17, new DateTime(1979, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "I1017", false, "L1017", "01000000017", "حازم إمام", "P1017", "U1017", null },
                    { 18, new DateTime(1973, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "I1018", false, "L1018", "01000000018", "عصام الحضري", "P1018", "U1018", null },
                    { 19, new DateTime(1976, 8, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "I1019", false, "L1019", "01000000019", "وائل جمعة", "P1019", "U1019", null },
                    { 20, new DateTime(1978, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "I1020", false, "L1020", "01000000020", "محمد أبو تريكة", "P1020", "U1020", null },
                    { 21, new DateTime(1975, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "I1021", false, "L1021", "01000000021", "أحمد حسن", "P1021", "U1021", null },
                    { 22, new DateTime(1992, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "I1022", false, "L1022", "01000000022", "محمد صلاح", "P1022", "U1022", null },
                    { 23, new DateTime(1994, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "I1023", false, "L1023", "01000000023", "محمود تريزيجيه", "P1023", "U1023", null },
                    { 24, new DateTime(1999, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "I1024", false, "L1024", "01000000024", "عمر مرموش", "P1024", "U1024", null },
                    { 25, new DateTime(1997, 11, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "I1025", false, "L1025", "01000000025", "مصطفى محمد", "P1025", "U1025", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BranchContacts_BranchId",
                table: "BranchContacts",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_BranchDocuments_BranchId",
                table: "BranchDocuments",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Branches_Code",
                table: "Branches",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Branches_CompanyId",
                table: "Branches",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_Code",
                table: "Companies",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CompanyContacts_CompanyId",
                table: "CompanyContacts",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyDocuments_CompanyId",
                table: "CompanyDocuments",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_BranchId",
                table: "Contracts",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_CompanyId",
                table: "Contracts",
                column: "CompanyId");

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

            migrationBuilder.CreateIndex(
                name: "IX_Lookups_LookupKey_Culture",
                table: "Lookups",
                columns: new[] { "LookupKey", "Culture" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BranchContacts");

            migrationBuilder.DropTable(
                name: "BranchDocuments");

            migrationBuilder.DropTable(
                name: "CompanyContacts");

            migrationBuilder.DropTable(
                name: "CompanyDocuments");

            migrationBuilder.DropTable(
                name: "Contracts");

            migrationBuilder.DropTable(
                name: "Lookups");

            migrationBuilder.DropTable(
                name: "Sponsors");

            migrationBuilder.DropTable(
                name: "Branches");

            migrationBuilder.DropTable(
                name: "Drivers");

            migrationBuilder.DropTable(
                name: "RentalVehicles");

            migrationBuilder.DropTable(
                name: "Tenants");

            migrationBuilder.DropTable(
                name: "Companies");
        }
    }
}
