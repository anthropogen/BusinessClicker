using Clicker.Components;
using Clicker.Events;
using Leopotam.Ecs;
using UnityEngine;

namespace Clicker.Systems
{
    public class BusinessProgressSystem : IEcsRunSystem
    {
        private readonly EcsFilter<BusinessView, BusinessStaticDataReference, BusinessIncomeTimer> _ecsFilter = null;

        public void Run()
        {
            foreach (var index in _ecsFilter)
            {
                ref var entity = ref _ecsFilter.GetEntity(index);
                ref var timer = ref entity.Get<BusinessIncomeTimer>();
                ref var staticData = ref entity.Get<BusinessStaticDataReference>();
                ref var view = ref entity.Get<BusinessView>();
                timer.Time += Time.deltaTime;
                if (timer.Time >= staticData.StaticData.IncomeDelay)
                {
                    timer.Time = 0;
                    entity.Get<AddIncomeEvent>();
                }
                var percent = timer.Time / staticData.StaticData.IncomeDelay;
                view.ProgressFill.value = percent;
            }
        }
    }
}