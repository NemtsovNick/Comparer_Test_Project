namespace ComparerApp.Utils
{
    public static class TariffConstants
    {
        public const string BasicTariffName = "basic electricity tariff";
        public const string PackagedTariffName = "Packaged tariff";

        public const decimal BasicTariffBaseCosts = 5;
        public const decimal BasicTariffConsumptionCostsCoefficient = 0.22m;

        public const decimal PackagedTariffBaseCosts = 800;
        public const decimal PackagedTariffPricePerUnitAboveLimit = 0.3m;
        public const double PackagedTariffLimit = 4000;
    }
}