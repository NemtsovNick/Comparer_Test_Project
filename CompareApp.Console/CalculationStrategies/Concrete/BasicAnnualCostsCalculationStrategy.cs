using ComparerApp.CalculationStrategies.Abstract;
using ComparerApp.Utils;

namespace ComparerApp.CalculationStrategies.Concrete
{
    using System;

    public class BasicAnnualCostsCalculationStrategy : IAnnualCostsCalculationStrategy
    {
        public decimal GetAnnualCosts(double consumption)
        {
            if (consumption < 0)
            {
                throw new ArgumentException("Argument should not be less than zero", nameof(consumption));
            }

            var result = (TariffConstants.BasicTariffBaseCosts * 12) + 
                         (TariffConstants.BasicTariffConsumptionCostsCoefficient * 
                         (decimal)consumption);

            return result;
        }
    }
}