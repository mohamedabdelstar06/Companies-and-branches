using System;
using ZAD.Domain.Entities.VehicleRental.Vehicles;

namespace ZAD.Application.Strategies.ContractTypeStrategies
{
    public class LongTermContractStrategy : IContractTypeStrategy
    {
        public DateTime CalculateExpectedReceivingDateTime(DateTime startDateTime, int periodInDays) => startDateTime.AddYears(periodInDays);
        public decimal GetExpectedMinimumRent(RentalVehicle vehicle) => vehicle.YearlyRentPrice;
    }
}
