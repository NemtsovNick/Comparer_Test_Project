namespace ComparerApp.Models.Abstract
{
    public interface IProduct
    {
        string Name { get; }

        decimal AnnualCosts { get; }

        void CalculateAnnualCosts(double consumption);
    }
}
