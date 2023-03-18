using Clicker.Components;
using Clicker.Events;
using Clicker.PersistentData;
using Clicker.StaticData;
using Leopotam.Ecs;
using UnityEditor.Search;
using UnityEngine;

namespace Clicker.Systems
{
    public class BusinessIncomeSystem : IEcsRunSystem
    {
        private readonly EcsFilter<BusinessLevel, BusinessStaticDataReference, AddIncomeEvent> _filter;
        private readonly PlayerData _playerData;

        public void Run()
        {
            foreach (var index in _filter)
            {
                ref var entity = ref _filter.GetEntity(index);
                ref var staticData = ref entity.Get<BusinessStaticDataReference>();
                ref var business = ref entity.Get<BusinessLevel>();

                var firstPercent = staticData.StaticData.GetMultiplier(UpgradeType.UpgradeFirst, business.UpgradeLevels[0]);
                var secondPercent = staticData.StaticData.GetMultiplier(UpgradeType.UpgradeSecond, business.UpgradeLevels[1]);

                var income = CalculateHelper.CalculateIncome(business.Level, staticData.StaticData.BaseIncome, firstPercent, secondPercent);
                _playerData.Balance = Mathf.Max(0, _playerData.Balance + income);
            }
        }
    }
}
