using Clicker.Components;
using Clicker.Events;
using Clicker.PersistentData;
using Clicker.StaticData;
using Leopotam.Ecs;
using UnityEngine;

namespace Clicker.Systems
{
    public class LevelUpBusinessSystem : IEcsRunSystem
    {
        private readonly PlayerData _playerData = null;
        private readonly EcsWorld _ecsWorld = null;
        private readonly EcsFilter<BusinessView, BusinessStaticDataReference, BusinessLevel, UpBusinessLevelEvent> _filter;

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

                var price = CalculateHelper.CalculateLevelPrice(levelData.Level, staticData.StaticData.BasePrice);
                if (price > _playerData.Balance)
                    continue;
                _playerData.Balance = Mathf.Max(0, _playerData.Balance - price);
                levelData.Level++;
                if (levelData.Level == 1)
                    ent.Get<NeedInitBusinessEvent>();

                view.LevelText.text = $"{levelData.Level}";
                ent.Get<IncomeChangedEvent>();
                _playerData.Business[staticData.StaticData.Name] = levelData;
            }

            var entity = _ecsWorld.NewEntity();
            entity.Get<BalanceChangedEvent>();
        }
    }
}
