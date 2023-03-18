using Clicker.Components;
using Clicker.Events;
using Leopotam.Ecs;

namespace Clicker.Systems
{
    public class InitBusinessSystem : IEcsRunSystem
    {
        private readonly EcsFilter<BusinessView, BusinessStaticDataReference, NeedInitBusinessEvent>.Exclude<BusinessLevel> _filter = null;

        public void Run()
        {
            foreach (var index in _filter)
            {
                ref var entity = ref _filter.GetEntity(index);
                ref var business = ref entity.Get<BusinessLevel>();
                business.UpgradeLevels = new int[2];
                entity.Get<BusinessIncomeTimer>();
            }
        }
    }
}