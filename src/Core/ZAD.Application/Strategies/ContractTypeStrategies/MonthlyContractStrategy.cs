using System;
using ZAD.Domain.Entities.VehicleRental.Vehicles;

namespace ZAD.Application.Strategies.ContractTypeStrategies
{
    public class MonthlyContractStrategy : IContractTypeStrategy
    {
        public DateTime CalculateExpectedReceivingDateTime(DateTime startDateTime, int periodInDays) => startDateTime.AddMonths(periodInDays);
        public decimal GetExpectedMinimumRent(RentalVehicle vehicle) => vehicle.MonthlyRentPrice;
    }
}
