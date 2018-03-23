namespace ComparerApp.Models.Concrete
{
    using System;

    using ComparerApp.CalculationStrategies.Abstract;
    using ComparerApp.CalculationStrategies.Concrete;
    using ComparerApp.Models.Abstract;
    using ComparerApp.Utils;

    public class Product : IProduct
    {
        public Product(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                if (name == null)
                {
                    throw new ArgumentNullException(nameof(name), "Argument should be not null");
                }

                throw new ArgumentException("Argument should be not empty", nameof(name));
            }

            Name = name;
        }

        public string Name { get; }

        public decimal AnnualCosts { get; private set; }

        public void CalculateAnnualCosts(double consumption)
        {
            if (consumption < 0)
            {
                throw new ArgumentException("Argument should not be less than zero", nameof(consumption));
            }

            IAnnualCostsCalculationStrategy annualCostsCalculationStrategy;

            switch (Name)
            {
                case TariffConstants.BasicTariffName:
                    annualCostsCalculationStrategy = new BasicAnnualCostsCalculationStrategy();
                    break;
                case TariffConstants.PackagedTariffName:
                    annualCostsCalculationStrategy = new PackagedAnnualCostsCalculationStrategy();
                    break;
                default:
                    throw new Exception("Unexpected name of tariff");
            }

            AnnualCosts = annualCostsCalculationStrategy.GetAnnualCosts(consumption);
        }
    }
}