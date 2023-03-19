using Clicker.Components;
using Clicker.Events;
using Leopotam.Ecs;

namespace Clicker.Systems
{
    public class InitBusinessSystem : IEcsRunSystem
    {
        private readonly EcsWorld _ecsWorld;
        private readonly EcsFilter<BusinessView, BusinessStaticDataReference, NeedInitBusinessEvent>.Exclude<BusinessLevel> _filter = null;

        public void Run()
        {
            if (_filter.GetEntitiesCount() < 1)
                return;
            foreach (var index in _filter)
            {
                ref var entity = ref _filter.GetEntity(index);
                ref var business = ref entity.Get<BusinessLevel>();
                business.UpgradeLevels = new int[2];
                entity.Get<BusinessIncomeTimer>();
                entity.Get<IncomeChangedEvent>();

                ref var view = ref entity.Get<BusinessView>();
                ConstructButtons(ref entity, ref view);
            }

            SendInitEvent();

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