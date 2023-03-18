using UnityEngine;

namespace Clicker.StaticData
{
    [System.Serializable]
    public class MultiplierData
    {
        [field: SerializeField] public int Price { get; private set; }
        [field: SerializeField] public float IncomeMultiplier { get; private set; }
    }

}