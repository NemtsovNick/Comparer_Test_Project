using ComparerApp.Utils;

namespace ComparerApp
{
    using ComparerApp.Models.Concrete;

    public static class Program
    {
        public static void Main()
        {
            var productComparer = new ProductComparer();

            productComparer.Add(new Product(TariffConstants.BasicTariffName));
            productComparer.Add(new Product(TariffConstants.PackagedTariffName));

            productComparer.CompareAndPrint(3500);
            productComparer.CompareAndPrint(4500);
            productComparer.CompareAndPrint(6000);
        }
    }
}
