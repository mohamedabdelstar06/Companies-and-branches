using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZAD.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddTenantMaintenanceFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "NextMaintenanceDate",
                table: "RentalVehicles",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NextMaintenanceKM",
                table: "RentalVehicles",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CurrentMaintenanceDate",
                table: "Contracts",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CurrentMaintenanceKM",
                table: "Contracts",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CurrentMaintenanceNote",
                table: "Contracts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CurrentMaintenanceType",
                table: "Contracts",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "NewNextMaintenanceDate",
                table: "Contracts",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NewNextMaintenanceKM",
                table: "Contracts",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "NextMaintenanceDate", "NextMaintenanceKM" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "NextMaintenanceDate", "NextMaintenanceKM" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "NextMaintenanceDate", "NextMaintenanceKM" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "NextMaintenanceDate", "NextMaintenanceKM" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "NextMaintenanceDate", "NextMaintenanceKM" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "NextMaintenanceDate", "NextMaintenanceKM" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "NextMaintenanceDate", "NextMaintenanceKM" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "NextMaintenanceDate", "NextMaintenanceKM" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "NextMaintenanceDate", "NextMaintenanceKM" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "NextMaintenanceDate", "NextMaintenanceKM" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "NextMaintenanceDate", "NextMaintenanceKM" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "NextMaintenanceDate", "NextMaintenanceKM" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "NextMaintenanceDate", "NextMaintenanceKM" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "NextMaintenanceDate", "NextMaintenanceKM" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "NextMaintenanceDate", "NextMaintenanceKM" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "NextMaintenanceDate", "NextMaintenanceKM" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "NextMaintenanceDate", "NextMaintenanceKM" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "NextMaintenanceDate", "NextMaintenanceKM" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "NextMaintenanceDate", "NextMaintenanceKM" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "NextMaintenanceDate", "NextMaintenanceKM" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "NextMaintenanceDate", "NextMaintenanceKM" },
                values: new object[] { null, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NextMaintenanceDate",
                table: "RentalVehicles");

            migrationBuilder.DropColumn(
                name: "NextMaintenanceKM",
                table: "RentalVehicles");

            migrationBuilder.DropColumn(
                name: "CurrentMaintenanceDate",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "CurrentMaintenanceKM",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "CurrentMaintenanceNote",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "CurrentMaintenanceType",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "NewNextMaintenanceDate",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "NewNextMaintenanceKM",
                table: "Contracts");
        }
    }
}
