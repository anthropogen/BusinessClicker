using Clicker.Components;
using Clicker.Events;
using Clicker.PersistentData;
using Leopotam.Ecs;
using UnityEngine;

namespace Clicker.Systems
{
    public class UpgradeSystem : IEcsRunSystem
    {
        private readonly PlayerData _playerData = null;
        private readonly EcsWorld _ecsWorld = null;
        private readonly EcsFilter<BusinessView, BusinessStaticDataReference, BusinessLevel, UpgradeBusinessEvent> _filter;

        public void Run()
        {
            if (_filter.GetEntitiesCount() < 1)
                return;

            foreach (var index in _filter)
            {
                ref var ent = ref _filter.GetEntity(index);
                ref var view = ref _filter.Get1(index);
                ref var staticData = ref _filter.Get2(index);
                ref var levelData = ref _filter.Get3(index);
                ref var upEvent = ref ent.Get<UpgradeBusinessEvent>();
                var upgradeType = upEvent.UpgradeType;
                if (!staticData.StaticData.HasMultiplier(upgradeType, levelData.UpgradeLevels[(int)upgradeType]))
                    continue;
                var multiplier = staticData.StaticData.GetMultipier(upgradeType, levelData.UpgradeLevels[(int)upgradeType]);
                if (multiplier.Price > _playerData.Balance)
                    continue;
                _playerData.Balance = Mathf.Max(0, _playerData.Balance - multiplier.Price);
                levelData.UpgradeLevels[(int)upgradeType]++;
                _playerData.Business[staticData.StaticData.Name] = levelData;
                ent.Get<IncomeChangedEvent>();
            }

            var entity = _ecsWorld.NewEntity();
            entity.Get<BalanceChangedEvent>();
        }
    }
}
