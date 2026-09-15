using System;
using ZAD.Domain.Entities.VehicleRental.Vehicles;

namespace ZAD.Application.Strategies.ContractTypeStrategies
{
    public class LongTermContractStrategy : IContractTypeStrategy
    {
        public decimal CalculateRentalAmount(int actualPeriodHours, int actualPeriodDays, decimal netRentPrice, decimal vehicleDailyRentPrice)
        {
            return (actualPeriodDays / 360) * netRentPrice + (actualPeriodDays % 360) * vehicleDailyRentPrice;
        }

        public decimal CalculateDriverAmount(int actualPeriodHours, int actualPeriodDays, decimal driverFare, decimal dailyRate, bool withDriver)
        {
            if (!withDriver) return 0m;
            return (actualPeriodDays / 360) * driverFare + ((actualPeriodDays % 360) + 1) * dailyRate;
        }

        public decimal GetExpectedMinimumRent(RentalVehicle vehicle) => vehicle.YearlyRentPrice;

        public DateTime CalcExpectedReceivingDate(DateTime startDate, int period) => startDate.AddYears(period);
    }
}
