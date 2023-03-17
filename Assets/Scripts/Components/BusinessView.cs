using UnityEngine.UI;
using UnityEngine;
using TMPro;

namespace Clicker.Components
{
    [System.Serializable]
    public struct BusinessView
    {
        [field: SerializeField] public TMP_Text Title { get; private set; }
        [field: SerializeField] public Slider ProgressFill { get; private set; }
    }
}