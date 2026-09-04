using System;

using ZAD.Domain.Entities.VehicleRental.Vehicles;

namespace ZAD.Application.Strategies.ContractTypeStrategies
{
    public class HourlyContractStrategy : IContractTypeStrategy
    {
        public DateTime CalculateExpectedReceivingDateTime(DateTime startDateTime, int periodInDays) => startDateTime.AddHours(periodInDays);
        public decimal GetExpectedMinimumRent(RentalVehicle vehicle) => vehicle.HourlyRentPrice;
    }
}
