using System;
using ZAD.Domain.Entities.VehicleRental.Vehicles;

namespace ZAD.Application.Strategies.ContractTypeStrategies
{
    public class DailyContractStrategy : IContractTypeStrategy
    {
        public decimal CalculateRentalAmount(int actualPeriodHours, int actualPeriodDays, decimal netRentPrice, decimal vehicleDailyRentPrice)
        {
            return actualPeriodDays * netRentPrice;
        }

        public decimal CalculateDriverAmount(int actualPeriodHours, int actualPeriodDays, decimal driverFare, decimal dailyRate, bool withDriver)
        {
            if (!withDriver) return 0m;
            return (actualPeriodDays + 1) * driverFare;
        }

        public decimal GetExpectedMinimumRent(RentalVehicle vehicle) => vehicle.DailyRentPrice;

        public DateTime CalcExpectedReceivingDate(DateTime startDate, int period) => startDate.AddDays(period);
    }
}
