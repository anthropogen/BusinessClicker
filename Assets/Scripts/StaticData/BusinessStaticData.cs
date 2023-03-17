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
    }
}