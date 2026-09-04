using System;

using ZAD.Domain.Entities.VehicleRental.Vehicles;

namespace ZAD.Application.Strategies.ContractTypeStrategies
{
    public class DailyContractStrategy : IContractTypeStrategy
    {
        public DateTime CalculateExpectedReceivingDateTime(DateTime startDateTime, int periodInDays) => startDateTime.AddDays(periodInDays);
        public decimal GetExpectedMinimumRent(RentalVehicle vehicle) => vehicle.DailyRentPrice;
    }
}
