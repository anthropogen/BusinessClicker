using Clicker.Components;
using Clicker.Events;
using Clicker.PersistentData;
using Leopotam.Ecs;

namespace Clicker.Systems
{
    public class InitBusinessSystem : IEcsRunSystem
    {
        private readonly EcsWorld _ecsWorld;
        private readonly PlayerData _playerData;
        private readonly EcsFilter<BusinessView, BusinessStaticDataReference, NeedInitBusinessEvent>.Exclude<BusinessIncomeTimer> _filter = null;

        public void Run()
        {
            if (_filter.GetEntitiesCount() < 1)
                return;
            foreach (var index in _filter)
            {
                ref var entity = ref _filter.GetEntity(index);
                ref var business = ref entity.Get<BusinessLevel>();
                ref var staticData = ref entity.Get<BusinessStaticDataReference>();
                business = SetBusinessData(business, staticData);

                if (business.Level > 0)
                    entity.Get<BusinessIncomeTimer>();

                entity.Get<IncomeChangedEvent>();

                ref var view = ref entity.Get<BusinessView>();
                view.LevelText.text = business.Level.ToString();
                ConstructButtons(ref entity, ref view);
            }
            SendInitEvent();
        }

        private BusinessLevel SetBusinessData(BusinessLevel business, BusinessStaticDataReference staticData)
        {
            if (_playerData.Business.ContainsKey(staticData.StaticData.Name))
            {
                business = _playerData.Business[staticData.StaticData.Name];
            }
            else
            {
                business.UpgradeLevels = new int[staticData.StaticData.UpgradeData.Count];
                if (staticData.StaticData.IsAvailable)
                    business.Level++;
            }
            return business;
        }

        private void SendInitEvent()
        {
            var ent = _ecsWorld.NewEntity();
            ent.Get<BusinessInitializedEvent>();
        }

        private static void ConstructButtons(ref EcsEntity entity, ref BusinessView view)
        {
            view.UpLevelButton.Construct(entity);
            foreach (var b in view.UpgradeButtons)
                b.Construct(entity);
        }
    }
}