using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZAD.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class RemoveVehicleCompanyAndMaintenanceFromContract : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RentalVehicles_Branches_BranchId",
                table: "RentalVehicles");

            migrationBuilder.DropForeignKey(
                name: "FK_RentalVehicles_Companies_CompanyId",
                table: "RentalVehicles");

            migrationBuilder.DropIndex(
                name: "IX_RentalVehicles_BranchId",
                table: "RentalVehicles");

            migrationBuilder.DropIndex(
                name: "IX_RentalVehicles_CompanyId",
                table: "RentalVehicles");

            migrationBuilder.DropColumn(
                name: "BranchId",
                table: "RentalVehicles");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "RentalVehicles");

            migrationBuilder.DropColumn(
                name: "NextMaintenanceDate",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "NextMaintenanceKm",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "NotificationType",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "ReminderBeforePeriodicMaintenance",
                table: "Contracts");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BranchId",
                table: "RentalVehicles",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "RentalVehicles",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "NextMaintenanceDate",
                table: "Contracts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "NextMaintenanceKm",
                table: "Contracts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NotificationType",
                table: "Contracts",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ReminderBeforePeriodicMaintenance",
                table: "Contracts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BranchId", "CompanyId" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BranchId", "CompanyId" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "BranchId", "CompanyId" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "BranchId", "CompanyId" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "BranchId", "CompanyId" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "BranchId", "CompanyId" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "BranchId", "CompanyId" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "BranchId", "CompanyId" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "BranchId", "CompanyId" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "BranchId", "CompanyId" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "BranchId", "CompanyId" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "BranchId", "CompanyId" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "BranchId", "CompanyId" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "BranchId", "CompanyId" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "BranchId", "CompanyId" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "BranchId", "CompanyId" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "BranchId", "CompanyId" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "BranchId", "CompanyId" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "BranchId", "CompanyId" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "BranchId", "CompanyId" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "RentalVehicles",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "BranchId", "CompanyId" },
                values: new object[] { null, null });

            migrationBuilder.CreateIndex(
                name: "IX_RentalVehicles_BranchId",
                table: "RentalVehicles",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_RentalVehicles_CompanyId",
                table: "RentalVehicles",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_RentalVehicles_Branches_BranchId",
                table: "RentalVehicles",
                column: "BranchId",
                principalTable: "Branches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RentalVehicles_Companies_CompanyId",
                table: "RentalVehicles",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
