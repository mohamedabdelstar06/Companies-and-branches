using System;
using System.Collections.Generic;
using ZAD.Domain.Enums.VehicleRental;

namespace ZAD.Application.Strategies.ContractTypeStrategies
{
    public static class ContractTypeStrategyFactory
    {
        private static readonly Dictionary<ContractType, IContractTypeStrategy> _strategies = new()
        {
            { ContractType.Daily, new DailyContractStrategy() },
            { ContractType.Weekly, new WeeklyContractStrategy() },
            { ContractType.Monthly, new MonthlyContractStrategy() },
            { ContractType.LongTerm, new LongTermContractStrategy() },
            { ContractType.Hourly, new HourlyContractStrategy() }
        };

        public static IContractTypeStrategy GetStrategy(ContractType type)
        {
            if (_strategies.TryGetValue(type, out var strategy))
            {
                return strategy;
            }
            throw new ArgumentException("Unknown contract type");
        }
    }
}
