namespace ComparerApp.Tests.Models.Concrete
{
    using System;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using ComparerApp.Models.Concrete;
    using ComparerApp.Utils;

    [TestClass]
    public class ProductTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "Argument should be not null")]
        public void ShouldThrowArgumentNullExceptionWhenNameIsNull()
        {
            // Act
            new Product(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Argument should be not empty")]
        public void ShouldThrowArgumentExceptionWhenNameIsEmpty()
        {
            // Act
            new Product(String.Empty);
        }

        [TestMethod]
        public void NamePropertyShouldReturnBasicTariffName()
        {
            // Arrange
            string name = TariffConstants.BasicTariffName;

            // Act
            var product = new Product(name);

            // Assert
            Assert.AreEqual(name, product.Name);
        }

        [TestMethod]
        public void AnnualCostsPropertyShouldReturn830()
        {
            // Arrange
            string name = TariffConstants.BasicTariffName;
            double consumption = 3500;

            // Act
            var product = new Product(name);
            product.CalculateAnnualCosts(consumption);

            // Assert
            Assert.AreEqual(830, product.AnnualCosts);
        }

        [TestMethod]
        public void AnnualCostsPropertyShouldReturn800()
        {
            // Arrange
            string name = TariffConstants.PackagedTariffName;
            double consumption = 3500;

            // Act
            var product = new Product(name);
            product.CalculateAnnualCosts(consumption);

            // Assert
            Assert.AreEqual(800, product.AnnualCosts);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Argument should not be less than zero")]
        public void CalculateAnnualCostsShouldThrowArgumentExceptionWhenConsumptionIsLessThanZero()
        {
            // Arrange
            string name = "MyTariffName";
            double consumption = -600;

            // Act
            var product = new Product(name);
            product.CalculateAnnualCosts(consumption);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Unexpected name of tariff")]
        public void CalculateAnnualCostsShouldThrowExceptionWhenNameIsMyTariffName()
        {
            // Arrange
            string name = "MyTariffName";
            double consumption = 3500;

            // Act
            var product = new Product(name);
            product.CalculateAnnualCosts(consumption);
        }
    }
}
