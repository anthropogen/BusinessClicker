using Clicker.Components;
using UnityEngine;

namespace Clicker.StaticData
{
    [CreateAssetMenu(fileName = "NewBusiness", menuName = "Static Data/Business Data", order = 51)]
    public class BusinessStaticData : ScriptableObject
    {
        [field: SerializeField] public string Name { get; private set; }
        [field: SerializeField, Min(0)] public float IncomeDelay { get; private set; }
        [field: SerializeField, Min(0)] public int BasePrice { get; private set; }
        [field: SerializeField, Min(0)] public int BaseIncome { get; private set; }
        [field: SerializeField] public BusinessUpgradeStaticData UpgradeData { get; private set; }
        [field: SerializeField] public bool IsAvailable { get; private set; }

        public bool HasMultiplier(UpgradeType type, int level)
            => UpgradeData.HasUpgradeFor(type, level);


        public float GetPercentMultiplier(UpgradeType type, int level)
        {
            level--;
            if (!UpgradeData.HasUpgradeFor(type, level))
                return 0;

            return UpgradeData.GetMultiplier(type, level).IncomeMultiplier / 100;
        }

        public MultiplierData GetMultipier(UpgradeType type, int level)
        {
            if (!UpgradeData.HasUpgradeFor(type, level))
                return null;

            return UpgradeData.GetMultiplier(type, level);
        }
    }
}