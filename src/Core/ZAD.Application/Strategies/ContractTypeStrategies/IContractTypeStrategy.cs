using System;

using ZAD.Domain.Entities.VehicleRental.Vehicles;

namespace ZAD.Application.Strategies.ContractTypeStrategies
{
    public interface IContractTypeStrategy
    {
        DateTime CalculateExpectedReceivingDateTime(DateTime startDateTime, int periodInDays);
        decimal GetExpectedMinimumRent(RentalVehicle vehicle);
    }
}
