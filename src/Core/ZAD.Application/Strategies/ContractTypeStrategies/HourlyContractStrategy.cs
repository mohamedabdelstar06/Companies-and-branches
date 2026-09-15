using System;
using ZAD.Domain.Entities.VehicleRental.Vehicles;

namespace ZAD.Application.Strategies.ContractTypeStrategies
{
    public class HourlyContractStrategy : IContractTypeStrategy
    {
        public decimal CalculateRentalAmount(int actualPeriodHours, int actualPeriodDays, decimal netRentPrice, decimal vehicleDailyRentPrice)
        {
            return actualPeriodHours * netRentPrice;
        }

        public decimal CalculateDriverAmount(int actualPeriodHours, int actualPeriodDays, decimal driverFare, decimal dailyRate, bool withDriver)
        {
            if (!withDriver) return 0m;
            return actualPeriodHours * driverFare;
        }

        public decimal GetExpectedMinimumRent(RentalVehicle vehicle) => vehicle.HourlyRentPrice;

        public DateTime CalcExpectedReceivingDate(DateTime startDate, int period) => startDate.AddHours(period);
    }
}
