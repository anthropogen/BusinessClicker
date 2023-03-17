using Clicker.Components;
using UnityEngine;

namespace Clicker.StaticData
{
    [System.Serializable]
    public class UpgradeData
    {
        [field: SerializeField] public UpgradeType Type { get; private set; }
        [field: SerializeField] public MultiplierData[] MultiplierDatas { get; private set; }
    }

}