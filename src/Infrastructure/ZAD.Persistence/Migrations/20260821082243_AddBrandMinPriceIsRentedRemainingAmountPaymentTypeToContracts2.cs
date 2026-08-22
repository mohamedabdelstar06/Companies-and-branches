using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ZAD.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddBrandMinPriceIsRentedRemainingAmountPaymentTypeToContracts2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Brand",
                table: "RentalVehicles",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsRented",
                table: "RentalVehicles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "MinimumRentPrice",
                table: "RentalVehicles",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "AccountingNo",
                table: "Contracts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DeliveryStatus",
                table: "Contracts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsPosted",
                table: "Contracts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "PaymentType",
                table: "Contracts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "RemainingAmount",
                table: "Contracts",
                type: "decimal(18,4)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Contracts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "RentalVehicles",
                columns: new[] { "Id", "Brand", "CreatedAt", "FileNo", "IsDeleted", "IsRented", "KilometerCounter", "MinimumRentPrice", "ModelYear", "PlateNo", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, "KIA", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "F-001", false, true, 10000, 10.00m, 2026, "77777", null },
                    { 2, "KIA", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "F-002", false, true, 12000, 12.00m, 2026, "3030", null },
                    { 3, "KIA", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "F-003", false, true, 15000, 11.00m, 2026, "EXT 1111", null },
                    { 4, "Nissan Patrol", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "F-004", false, true, 20000, 30.00m, 2026, "ACB-4578", null },
                    { 5, "Kia Sonet", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "F-005", false, true, 8000, 15.00m, 2026, "ABC 1245", null },
                    { 6, "Kia Sonet", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "DEF 1478", false, false, 40000, 8.00m, 2011, "DEF 1478", null },
                    { 7, "Toyota Corolla", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "F-007", false, false, 5000, 20.00m, 2026, "XYZ 999", null },
                    { 8, "Toyota Camry", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "F-008", false, false, 6000, 25.00m, 2026, "LMN 456", null },
                    { 9, "Honda Civic", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "F-009", false, false, 7000, 18.00m, 2026, "PQR 789", null },
                    { 10, "Hyundai Elantra", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "F-010", false, false, 9000, 17.00m, 2026, "STU 123", null },
                    { 11, "Chevrolet Tahoe", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "F-011", false, false, 25000, 40.00m, 2026, "VWX 456", null },
                    { 12, "Ford Explorer", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "F-012", false, false, 22000, 35.00m, 2026, "YZA 789", null },
                    { 13, "Mazda CX-5", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "F-013", false, false, 14000, 22.00m, 2026, "BCD 012", null },
                    { 14, "Nissan Altima", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "F-014", false, false, 11000, 19.00m, 2026, "EFG 345", null },
                    { 15, "BMW 3 Series", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "F-015", false, false, 18000, 45.00m, 2026, "HIJ 678", null },
                    { 16, "Mercedes C-Class", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "F-016", false, false, 16000, 48.00m, 2026, "KLM 901", null },
                    { 17, "Audi A4", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "F-017", false, false, 17000, 42.00m, 2026, "NOP 234", null },
                    { 18, "Lexus ES", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "F-018", false, false, 13000, 38.00m, 2026, "QRS 567", null },
                    { 19, "Jeep Grand Cherokee", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "F-019", false, false, 21000, 36.00m, 2026, "TUV 890", null },
                    { 20, "Volkswagen Tiguan", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "F-020", false, false, 19000, 24.00m, 2026, "WXY 123", null },
                    { 21, "Subaru Outback", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "F-021", false, false, 24000, 28.00m, 2026, "ZAB 456", null }
                });

            migrationBuilder.InsertData(
                table: "Tenants",
                columns: new[] { "Id", "Birthday", "CreatedAt", "IdNumber", "IsDeleted", "LicenseNumber", "Mobile", "Name", "PassportNumber", "UnifiedNumber", "UpdatedAt" },
                values: new object[,]
                {
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DropColumn(
                name: "Brand",
                table: "RentalVehicles");

            migrationBuilder.DropColumn(
                name: "IsRented",
                table: "RentalVehicles");

            migrationBuilder.DropColumn(
                name: "MinimumRentPrice",
                table: "RentalVehicles");

            migrationBuilder.DropColumn(
                name: "AccountingNo",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "DeliveryStatus",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "IsPosted",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "PaymentType",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "RemainingAmount",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Contracts");
        }
    }
}
