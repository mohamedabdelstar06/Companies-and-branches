using System;

using ZAD.Domain.Entities.VehicleRental.Vehicles;

namespace ZAD.Application.Strategies.ContractTypeStrategies
{
    public class WeeklyContractStrategy : IContractTypeStrategy
    {
        public DateTime CalculateExpectedReceivingDateTime(DateTime startDateTime, int periodInDays) => startDateTime.AddDays(periodInDays * 7);
        public decimal GetExpectedMinimumRent(RentalVehicle vehicle) => vehicle.WeeklyRentPrice;
    }
}
