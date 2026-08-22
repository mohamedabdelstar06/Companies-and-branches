using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZAD.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddSponsorsAndSecondDrivers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "SecondDriverIdExpireDate",
                table: "Contracts",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SecondDriverIdNumber",
                table: "Contracts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "SecondDriverLicenseExpireDate",
                table: "Contracts",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SecondDriverLicenseNumber",
                table: "Contracts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SecondDriverName",
                table: "Contracts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SecondDriverNationality",
                table: "Contracts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SecondDrivers",
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
                    table.PrimaryKey("PK_SecondDrivers", x => x.Id);
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
                
            migrationBuilder.InsertData(
                table: "Sponsors",
                columns: new[] { "Id", "Name", "Nationality", "LicenseNumber", "LicenseExpireDate", "IdNumber", "IdExpireDate", "IsDeleted", "CreatedAt" },
                values: new object[,]
                {
                    { 1, "حسين محمد المصري", "مصري", "123456789", new DateTime(2030, 1, 1), "274859865446554", new DateTime(2030, 1, 1), false, DateTime.UtcNow },
                    { 2, "محمود عبد الله حسين", "سعودي", "987654321", new DateTime(2028, 5, 20), "123456789012345", new DateTime(2028, 5, 20), false, DateTime.UtcNow }
                });

            migrationBuilder.InsertData(
                table: "SecondDrivers",
                columns: new[] { "Id", "Name", "Nationality", "LicenseNumber", "LicenseExpireDate", "IdNumber", "IdExpireDate", "IsDeleted", "CreatedAt" },
                values: new object[,]
                {
                    { 1, "أحمد علي محمود", "سوري", "111222333", new DateTime(2029, 12, 31), "111222333444555", new DateTime(2029, 12, 31), false, DateTime.UtcNow },
                    { 2, "خالد عمر عثمان", "أردني", "444555666", new DateTime(2027, 8, 15), "555444333222111", new DateTime(2027, 8, 15), false, DateTime.UtcNow }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SecondDrivers");

            migrationBuilder.DropTable(
                name: "Sponsors");

            migrationBuilder.DropColumn(
                name: "SecondDriverIdExpireDate",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "SecondDriverIdNumber",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "SecondDriverLicenseExpireDate",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "SecondDriverLicenseNumber",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "SecondDriverName",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "SecondDriverNationality",
                table: "Contracts");
        }
    }
}
