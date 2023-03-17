using UnityEngine;

namespace Clicker.StaticData
{
    [System.Serializable]
    public class MultiplierData
    {
        [field: SerializeField] public int Price { get; private set; }
        [field: SerializeField] public int IncomeMultiplier { get; private set; }
    }

}