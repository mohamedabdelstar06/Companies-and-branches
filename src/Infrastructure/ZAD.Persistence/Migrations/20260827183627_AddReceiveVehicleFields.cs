using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZAD.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddReceiveVehicleFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DelayHours",
                table: "Contracts",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "DelayPenaltyAmount",
                table: "Contracts",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "FinalNetDueAmount",
                table: "Contracts",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FreeKM",
                table: "Contracts",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "KMExceededTheLimit",
                table: "Contracts",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "MaintenancePaidByTenant",
                table: "Contracts",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ReceiveDiscountAmount",
                table: "Contracts",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "ReceiveNotes",
                table: "Contracts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ReceiveProofDocuments",
                table: "Contracts",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ReceivingDate",
                table: "Contracts",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ReceivingKilometerCounter",
                table: "Contracts",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "ReceivingTime",
                table: "Contracts",
                type: "time",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalAmountOfKMExceedingTheLimit",
                table: "Contracts",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TotalConsumptionKilometers",
                table: "Contracts",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalDriverAmount",
                table: "Contracts",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalDueAmount",
                table: "Contracts",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalRentalAmount",
                table: "Contracts",
                type: "decimal(18,2)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DelayHours",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "DelayPenaltyAmount",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "FinalNetDueAmount",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "FreeKM",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "KMExceededTheLimit",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "MaintenancePaidByTenant",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "ReceiveDiscountAmount",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "ReceiveNotes",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "ReceiveProofDocuments",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "ReceivingDate",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "ReceivingKilometerCounter",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "ReceivingTime",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "TotalAmountOfKMExceedingTheLimit",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "TotalConsumptionKilometers",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "TotalDriverAmount",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "TotalDueAmount",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "TotalRentalAmount",
                table: "Contracts");
        }
    }
}
