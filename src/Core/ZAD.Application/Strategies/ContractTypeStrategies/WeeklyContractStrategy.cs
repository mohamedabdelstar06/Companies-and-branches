using System;
using ZAD.Domain.Entities.VehicleRental.Vehicles;

namespace ZAD.Application.Strategies.ContractTypeStrategies
{
    public class WeeklyContractStrategy : IContractTypeStrategy
    {
        public decimal CalculateRentalAmount(int actualPeriodHours, int actualPeriodDays, decimal netRentPrice, decimal vehicleDailyRentPrice)
        {
            return (actualPeriodDays / 7) * netRentPrice + (actualPeriodDays % 7) * vehicleDailyRentPrice;
        }

        public decimal CalculateDriverAmount(int actualPeriodHours, int actualPeriodDays, decimal driverFare, decimal dailyRate, bool withDriver)
        {
            if (!withDriver) return 0m;
            return (actualPeriodDays / 7) * driverFare + ((actualPeriodDays % 7) + 1) * dailyRate;
        }

        public decimal GetExpectedMinimumRent(RentalVehicle vehicle) => vehicle.WeeklyRentPrice;

        public DateTime CalcExpectedReceivingDate(DateTime startDate, int period) => startDate.AddDays(period * 7);
    }
}
