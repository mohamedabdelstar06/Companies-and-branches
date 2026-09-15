using System;
using ZAD.Domain.Entities.VehicleRental.Vehicles;

namespace ZAD.Application.Strategies.ContractTypeStrategies
{
    public interface IContractTypeStrategy
    {
        decimal CalculateRentalAmount(int actualPeriodHours, int actualPeriodDays, decimal netRentPrice, decimal vehicleDailyRentPrice);
        decimal CalculateDriverAmount(int actualPeriodHours, int actualPeriodDays, decimal driverFare, decimal dailyRate, bool withDriver);
        decimal GetExpectedMinimumRent(RentalVehicle vehicle);
        DateTime CalcExpectedReceivingDate(DateTime startDate, int period);
    }
}
