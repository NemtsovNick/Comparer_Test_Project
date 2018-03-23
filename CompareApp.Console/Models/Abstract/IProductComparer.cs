using System.Collections.Generic;

namespace ComparerApp.Models.Abstract
{
    using ComparerApp.Models.Concrete;

    public interface IProductComparer
    {
        void Add(Product product);

        IEnumerable<Product> Compare(double consumption);

        void CompareAndPrint(double consumption);
    }
}
