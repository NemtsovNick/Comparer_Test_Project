namespace ComparerApp.Tests.CalculationStrategies.Concrete
{
    using System;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using ComparerApp.CalculationStrategies.Concrete;

    [TestClass]
    public class PackagedAnnualCostsCalculationStrategyTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Argument should not be less than zero")]
        public void GetAnnualCostsShouldThrowArgumentExceptionWhenConsumptionLessThanZero()
        {
            // Arrange
            var packagedAnnualCostsCalculationStrategy = new PackagedAnnualCostsCalculationStrategy();
            double consumption = -900;

            // Act
            packagedAnnualCostsCalculationStrategy.GetAnnualCosts(consumption);
        }

        [TestMethod]
        public void GetAnnualCostsShouldReturn1010()
        {
            // Arrange
            var packagedAnnualCostsCalculationStrategy = new PackagedAnnualCostsCalculationStrategy();
            double consumption = 4700;

            // Act
            var result = packagedAnnualCostsCalculationStrategy.GetAnnualCosts(consumption);

            // Assert
            Assert.AreEqual(1010.00m, result);
        }
    }
}
