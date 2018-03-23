namespace ComparerApp.Tests.CalculationStrategies.Concrete
{
    using System;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using ComparerApp.CalculationStrategies.Concrete;

    [TestClass]
    public class BasicAnnualCostsCalculationStrategyTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Argument should not be less than zero")]
        public void GetAnnualCostsShouldThrowArgumentExceptionWhenConsumptionLessThanZero()
        {
            // Arrange
            var basicAnnualCostsCalculationStrategy = new BasicAnnualCostsCalculationStrategy();
            double consumption = -900;

            // Act
            basicAnnualCostsCalculationStrategy.GetAnnualCosts(consumption);
        }
 
        [TestMethod]
        public void GetAnnualCostsShouldReturn1094()
        {
            // Arrange
            var basicAnnualCostsCalculationStrategy = new BasicAnnualCostsCalculationStrategy();
            double consumption = 4700;

            // Act
            var result = basicAnnualCostsCalculationStrategy.GetAnnualCosts(consumption);

            // Assert
            Assert.AreEqual(1094.00m, result);
        }
    }
}
