using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZAD.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class DynamicPricingAndVehicleType2026 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MinimumRentPrice",
                table: "RentalVehicles",
                newName: "YearlyRentPrice");

            migrationBuilder.AddColumn<decimal>(
                name: "DailyRentPrice",
                table: "RentalVehicles",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "HourlyRentPrice",
                table: "RentalVehicles",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "MonthlyRentPrice",
                table: "RentalVehicles",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "RentalVehicles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "WeeklyRentPrice",
                table: "RentalVehicles",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Brand", "DailyRentPrice", "HourlyRentPrice", "MonthlyRentPrice", "Type", "WeeklyRentPrice", "YearlyRentPrice" },
                values: new object[] { "KIA Cerato", 600m, 60m, 12000m, 1, 3600m, 120000m });

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Brand", "DailyRentPrice", "HourlyRentPrice", "MonthlyRentPrice", "Type", "WeeklyRentPrice", "YearlyRentPrice" },
                values: new object[] { "KIA Sportage", 800m, 80m, 16000m, 1, 4800m, 160000m });

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Brand", "DailyRentPrice", "HourlyRentPrice", "MonthlyRentPrice", "Type", "WeeklyRentPrice", "YearlyRentPrice" },
                values: new object[] { "Toyota Hiace", 1200m, 120m, 24000m, 2, 7200m, 240000m });

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DailyRentPrice", "HourlyRentPrice", "MonthlyRentPrice", "Type", "WeeklyRentPrice", "YearlyRentPrice" },
                values: new object[] { 1500m, 150m, 30000m, 1, 9000m, 300000m });

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DailyRentPrice", "HourlyRentPrice", "MonthlyRentPrice", "Type", "WeeklyRentPrice", "YearlyRentPrice" },
                values: new object[] { 700m, 70m, 14000m, 1, 4200m, 140000m });

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DailyRentPrice", "HourlyRentPrice", "MonthlyRentPrice", "Type", "WeeklyRentPrice", "YearlyRentPrice" },
                values: new object[] { 400m, 40m, 8000m, 1, 2400m, 80000m });

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DailyRentPrice", "HourlyRentPrice", "MonthlyRentPrice", "Type", "WeeklyRentPrice", "YearlyRentPrice" },
                values: new object[] { 700m, 70m, 14000m, 1, 4200m, 140000m });

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Brand", "DailyRentPrice", "HourlyRentPrice", "MonthlyRentPrice", "Type", "WeeklyRentPrice", "YearlyRentPrice" },
                values: new object[] { "Toyota Coaster", 1500m, 150m, 30000m, 2, 9000m, 300000m });

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DailyRentPrice", "HourlyRentPrice", "MonthlyRentPrice", "Type", "WeeklyRentPrice", "YearlyRentPrice" },
                values: new object[] { 750m, 75m, 15000m, 1, 4500m, 150000m });

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "DailyRentPrice", "HourlyRentPrice", "MonthlyRentPrice", "Type", "WeeklyRentPrice", "YearlyRentPrice" },
                values: new object[] { 650m, 65m, 13000m, 1, 3900m, 130000m });

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Brand", "DailyRentPrice", "HourlyRentPrice", "MonthlyRentPrice", "Type", "WeeklyRentPrice", "YearlyRentPrice" },
                values: new object[] { "Chevrolet NPR", 2000m, 200m, 40000m, 3, 12000m, 400000m });

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "DailyRentPrice", "HourlyRentPrice", "MonthlyRentPrice", "Type", "WeeklyRentPrice", "YearlyRentPrice" },
                values: new object[] { 1200m, 120m, 24000m, 1, 7200m, 240000m });

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "DailyRentPrice", "HourlyRentPrice", "MonthlyRentPrice", "Type", "WeeklyRentPrice", "YearlyRentPrice" },
                values: new object[] { 900m, 90m, 18000m, 1, 5400m, 180000m });

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "DailyRentPrice", "HourlyRentPrice", "MonthlyRentPrice", "Type", "WeeklyRentPrice", "YearlyRentPrice" },
                values: new object[] { 750m, 75m, 15000m, 1, 4500m, 150000m });

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "DailyRentPrice", "HourlyRentPrice", "MonthlyRentPrice", "Type", "WeeklyRentPrice", "YearlyRentPrice" },
                values: new object[] { 2000m, 200m, 40000m, 1, 12000m, 400000m });

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "Brand", "DailyRentPrice", "HourlyRentPrice", "MonthlyRentPrice", "Type", "WeeklyRentPrice", "YearlyRentPrice" },
                values: new object[] { "Mercedes S-Class", 4000m, 400m, 80000m, 1, 24000m, 800000m });

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "DailyRentPrice", "HourlyRentPrice", "MonthlyRentPrice", "Type", "WeeklyRentPrice", "YearlyRentPrice" },
                values: new object[] { 1800m, 180m, 36000m, 1, 10800m, 360000m });

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "DailyRentPrice", "HourlyRentPrice", "MonthlyRentPrice", "Type", "WeeklyRentPrice", "YearlyRentPrice" },
                values: new object[] { 1600m, 160m, 32000m, 1, 9600m, 320000m });

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "Brand", "DailyRentPrice", "HourlyRentPrice", "MonthlyRentPrice", "Type", "WeeklyRentPrice", "YearlyRentPrice" },
                values: new object[] { "Mercedes Sprinter", 2500m, 250m, 50000m, 2, 15000m, 500000m });

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "DailyRentPrice", "HourlyRentPrice", "MonthlyRentPrice", "Type", "WeeklyRentPrice", "YearlyRentPrice" },
                values: new object[] { 1000m, 100m, 20000m, 1, 6000m, 200000m });

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "Brand", "DailyRentPrice", "HourlyRentPrice", "MonthlyRentPrice", "Type", "WeeklyRentPrice", "YearlyRentPrice" },
                values: new object[] { "Mitsubishi Fuso", 1800m, 180m, 36000m, 3, 10800m, 360000m });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DailyRentPrice",
                table: "RentalVehicles");

            migrationBuilder.DropColumn(
                name: "HourlyRentPrice",
                table: "RentalVehicles");

            migrationBuilder.DropColumn(
                name: "MonthlyRentPrice",
                table: "RentalVehicles");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "RentalVehicles");

            migrationBuilder.DropColumn(
                name: "WeeklyRentPrice",
                table: "RentalVehicles");

            migrationBuilder.RenameColumn(
                name: "YearlyRentPrice",
                table: "RentalVehicles",
                newName: "MinimumRentPrice");

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Brand", "MinimumRentPrice" },
                values: new object[] { "KIA", 10.00m });

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Brand", "MinimumRentPrice" },
                values: new object[] { "KIA", 12.00m });

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Brand", "MinimumRentPrice" },
                values: new object[] { "KIA", 11.00m });

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 4,
                column: "MinimumRentPrice",
                value: 30.00m);

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 5,
                column: "MinimumRentPrice",
                value: 15.00m);

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 6,
                column: "MinimumRentPrice",
                value: 8.00m);

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 7,
                column: "MinimumRentPrice",
                value: 20.00m);

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Brand", "MinimumRentPrice" },
                values: new object[] { "Toyota Camry", 25.00m });

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 9,
                column: "MinimumRentPrice",
                value: 18.00m);

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 10,
                column: "MinimumRentPrice",
                value: 17.00m);

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Brand", "MinimumRentPrice" },
                values: new object[] { "Chevrolet Tahoe", 40.00m });

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 12,
                column: "MinimumRentPrice",
                value: 35.00m);

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 13,
                column: "MinimumRentPrice",
                value: 22.00m);

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 14,
                column: "MinimumRentPrice",
                value: 19.00m);

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 15,
                column: "MinimumRentPrice",
                value: 45.00m);

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "Brand", "MinimumRentPrice" },
                values: new object[] { "Mercedes C-Class", 48.00m });

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 17,
                column: "MinimumRentPrice",
                value: 42.00m);

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 18,
                column: "MinimumRentPrice",
                value: 38.00m);

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "Brand", "MinimumRentPrice" },
                values: new object[] { "Jeep Grand Cherokee", 36.00m });

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 20,
                column: "MinimumRentPrice",
                value: 24.00m);

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "Brand", "MinimumRentPrice" },
                values: new object[] { "Subaru Outback", 28.00m });
        }
    }
}
