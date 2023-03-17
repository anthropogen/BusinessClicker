using UnityEngine;

namespace Clicker.StaticData
{
    public static class CalculateHelper
    {
        public static float CalculateIncome(int level, int baseIncome, float upgradeFirstPercent, float upgradeSecondPercent)
        {
            float income = level * baseIncome * (1 + upgradeFirstPercent + upgradeSecondPercent);
            return Mathf.Round(income);
        }

        public static float CalculateLevelPrice(int level, float basePrice)
            => (level + 1) * basePrice;
    }
}