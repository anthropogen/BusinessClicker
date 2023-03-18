using Clicker.Providers;
using UnityEngine;

namespace Clicker.Infrastructure
{
    public class AssetProvider : MonoBehaviour, IAssetProvider
    {
        [field: SerializeField] public BusinessViewProvider BusinessViewTemplate { get; private set; }
    }
}