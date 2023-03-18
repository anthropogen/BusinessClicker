namespace Clicker.StaticData
{
    public static class CalculateHelper
    {
        public static int CalculateIncome(int level, int baseIncome, float upgradeFirstPercent, float upgradeSecondPercent)
        {
            float income = level * baseIncome * (1 + upgradeFirstPercent + upgradeSecondPercent);
            return (int)income;
        }

        public static float CalculateLevelPrice(int level, float basePrice)
            => (level + 1) * basePrice;
    }
}