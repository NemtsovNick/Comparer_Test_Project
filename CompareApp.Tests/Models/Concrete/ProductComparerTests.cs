using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ComparerApp.Tests.Models.Concrete
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using ComparerApp.Models.Concrete;
    using ComparerApp.Utils;

    [TestClass]
    public class ProductComparerTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "Argument should be not null")]
        public void AddShouldThrowArgumentNullExceptionWhenOtherIsNull()
        {
            // Arrange
            var productComparer = new ProductComparer();

            // Act
            productComparer.Add(null);
        }

        [TestMethod]
        public void AddShouldSuccess()
        {
            // Arrange
            var name = TariffConstants.BasicTariffName;
            var product = new Product(name);
            var productComparer = new ProductComparer();

            // Act
            productComparer.Add(product);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Argument should not be less than zero")]
        public void CompareShouldThrowArgumentNullExceptionWhenConsumptionLessThanZero()
        {
            // Arrange
            var consumption = -300;
            var productComparer = new ProductComparer();

            // Act
            productComparer.Compare(consumption);
        }

        [TestMethod]
        public void CompareShouldReturnListWithCorrectOrder()
        {
            // Arrange
            var productComparer = new ProductComparer();
            var product1 = new Product(TariffConstants.BasicTariffName);
            var product2 = new Product(TariffConstants.PackagedTariffName);
            var expectedResult = new List<Product>();
            expectedResult.Add(product2);
            expectedResult.Add(product1);

            // Act
            productComparer.Add(product1);
            productComparer.Add(product2);
            var actualResult = productComparer.Compare(3400).ToList();

            // Assert
            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void CompareAndPrintShouldSuccess()
        {
            // Arrange
            var productComparer = new ProductComparer();
            var product1 = new Product(TariffConstants.BasicTariffName);
            var product2 = new Product(TariffConstants.PackagedTariffName);

            // Act
            productComparer.Add(product1);
            productComparer.Add(product2);
            productComparer.CompareAndPrint(3400);
        }
    }
}
