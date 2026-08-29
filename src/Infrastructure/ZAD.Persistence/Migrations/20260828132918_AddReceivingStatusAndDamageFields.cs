using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZAD.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddReceivingStatusAndDamageFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DamageNote",
                table: "Contracts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsMaintenanceDoneByTenant",
                table: "Contracts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsVehicleStoppedUntilMaintenanceOrRepair",
                table: "Contracts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "VehicleReceivingStatus",
                table: "Contracts",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DamageNote",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "IsMaintenanceDoneByTenant",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "IsVehicleStoppedUntilMaintenanceOrRepair",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "VehicleReceivingStatus",
                table: "Contracts");
        }
    }
}
