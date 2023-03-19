using Clicker.Components;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Clicker.StaticData
{
    [CreateAssetMenu(fileName = "NewBusinessUpgrade", menuName = "Static Data/Business Upgrade Data", order = 51)]
    public class BusinessUpgradeStaticData : ScriptableObject
    {
        [SerializeField] private UpgradeData[] _upgradesDatas;

        private Dictionary<UpgradeType, Dictionary<int, MultiplierData>> _upgradesDictionary;

        public int Count => _upgradesDatas.Length;

        public bool HasUpgradeFor(UpgradeType type, int level)
        {
            CheckValidUpgradeDictionary();

            if (!_upgradesDictionary.ContainsKey(type))
                return false;
            if (!_upgradesDictionary[type].ContainsKey(level))
                return false;

            return true;
        }

        public MultiplierData GetMultiplier(UpgradeType type, int level)
        {
            CheckValidUpgradeDictionary();
            return _upgradesDictionary[type][level];
        }

        private Dictionary<UpgradeType, Dictionary<int, MultiplierData>> CreateUpgradeDictionary()
        {
            return _upgradesDatas.ToDictionary(u => u.Type,
                  k => Enumerable.Range(0, k.MultiplierDatas.Length).
                  ToDictionary(x => x, x => k.MultiplierDatas[x]));
        }

        private void CheckValidUpgradeDictionary()
        {
            if (_upgradesDictionary == null)
                _upgradesDictionary = CreateUpgradeDictionary();
        }
    }

}