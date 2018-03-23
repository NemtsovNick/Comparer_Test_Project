using ComparerApp.CalculationStrategies.Abstract;
using ComparerApp.Utils;

namespace ComparerApp.CalculationStrategies.Concrete
{
    using System;

    public class PackagedAnnualCostsCalculationStrategy : IAnnualCostsCalculationStrategy
    {
        public decimal GetAnnualCosts(double consumption)
        {
            if (consumption < 0)
            {
                throw new ArgumentException("Argument should not be less than zero", nameof(consumption));
            }

            decimal result; 

            if (consumption > TariffConstants.PackagedTariffLimit)
            {
                result = TariffConstants.PackagedTariffBaseCosts
                         + ((decimal)(consumption - TariffConstants.PackagedTariffLimit)
                         * TariffConstants.PackagedTariffPricePerUnitAboveLimit);
            }
            else
            {
                result = TariffConstants.PackagedTariffBaseCosts;
            }

            return result;
        }
    }
}