using Clicker.Components;
using UnityEngine;

namespace Clicker.Providers
{
    public class UpgradeButton : MonoBehaviour
    {
        [field: SerializeField] public UpgradeType Type { get; private set; }
    }
}