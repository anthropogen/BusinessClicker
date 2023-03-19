using System;

namespace Clicker.StaticData
{
    public static class CalculateHelper
    {
        public static int CalculateIncome(int level, int baseIncome, float upgradeFirstPercent, float upgradeSecondPercent)
        {
            float income = level * baseIncome * (1 + upgradeFirstPercent + upgradeSecondPercent);
            return (int)income;
        }

        public static int CalculateLevelPrice(int level, float basePrice)
            => Convert.ToInt32((level + 1) * basePrice);
    }
}