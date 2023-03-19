using Clicker.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Clicker.Components
{
    [System.Serializable]
    public struct BusinessView
    {
        [field: SerializeField] public TMP_Text Title { get; private set; }
        [field: SerializeField] public Slider ProgressFill { get; private set; }
        [field: SerializeField] public UpBusinessLevelButton UpLevelButton { get; private set; }
        [field: SerializeField] public UpgradeBusinessButton[] UpgradeButtons { get; private set; }
    }
}