namespace ComparerApp.Models.Concrete
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using ComparerApp.Models.Abstract;

    public class ProductComparer : IProductComparer
    {
        private readonly List<Product> products = new List<Product>();

        public void Add(Product product)
        {
            if(product == null)
            {
                throw new ArgumentNullException(nameof(product), "Argument should be not null");
            }

            products.Add(product);
        }

        public IEnumerable<Product> Compare(double consumption)
        {
            if (consumption < 0)
            {
                throw new ArgumentException("Argument should not be less than zero", nameof(consumption));
            }

            products.ForEach(product => product.CalculateAnnualCosts(consumption));

            return products.OrderBy(product => product.AnnualCosts);
        }

        public void CompareAndPrint(double consumption)
        {
            PrintProductsToConsole(Compare(consumption));
        }

        private void PrintProductsToConsole(IEnumerable<Product> productsToPrint)
        {
            productsToPrint.ToList().ForEach(
                (product) =>
                {
                    Console.WriteLine($"{ product.Name } : { product.AnnualCosts }");
                });

            Console.WriteLine();
        }
    }
}
