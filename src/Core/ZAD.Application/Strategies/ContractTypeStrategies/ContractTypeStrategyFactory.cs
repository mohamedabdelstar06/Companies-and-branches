using System;
using System.Collections.Generic;
using ZAD.Domain.Enums.VehicleRental;

namespace ZAD.Application.Strategies.ContractTypeStrategies
{
    public class ContractTypeStrategyFactory
    {
        private static readonly Dictionary<ContractType, IContractTypeStrategy> _strategies = new()
        {
            { ContractType.Hourly, new HourlyContractStrategy() },
            { ContractType.Daily, new DailyContractStrategy() },
            { ContractType.Weekly, new WeeklyContractStrategy() },
            { ContractType.Monthly, new MonthlyContractStrategy() },
            { ContractType.LongTerm, new LongTermContractStrategy() }
        };

        public static IContractTypeStrategy GetStrategy(ContractType contractType)
        {
            if (_strategies.TryGetValue(contractType, out var strategy))
            {
                return strategy;
            }
            
            return new DailyContractStrategy(); 
        }
    }
}
