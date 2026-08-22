using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZAD.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdateZeroPrices : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("UPDATE RentalVehicles SET HourlyRentPrice = 100, DailyRentPrice = 1000, WeeklyRentPrice = 6000, MonthlyRentPrice = 20000, YearlyRentPrice = 200000 WHERE DailyRentPrice = 0 OR DailyRentPrice IS NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
