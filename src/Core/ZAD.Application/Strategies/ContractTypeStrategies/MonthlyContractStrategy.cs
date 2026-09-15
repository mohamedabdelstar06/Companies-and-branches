using System;
using ZAD.Domain.Entities.VehicleRental.Vehicles;

namespace ZAD.Application.Strategies.ContractTypeStrategies
{
    public class MonthlyContractStrategy : IContractTypeStrategy
    {
        public decimal CalculateRentalAmount(int actualPeriodHours, int actualPeriodDays, decimal netRentPrice, decimal vehicleDailyRentPrice)
        {
            return (actualPeriodDays / 30) * netRentPrice + (actualPeriodDays % 30) * vehicleDailyRentPrice;
        }

        public decimal CalculateDriverAmount(int actualPeriodHours, int actualPeriodDays, decimal driverFare, decimal dailyRate, bool withDriver)
        {
            if (!withDriver) return 0m;
            return (actualPeriodDays / 30) * driverFare + ((actualPeriodDays % 30) + 1) * dailyRate;
        }

        public decimal GetExpectedMinimumRent(RentalVehicle vehicle) => vehicle.MonthlyRentPrice;

        public DateTime CalcExpectedReceivingDate(DateTime startDate, int period) => startDate.AddMonths(period);
    }
}
