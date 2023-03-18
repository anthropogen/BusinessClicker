using Clicker.Components;
using Clicker.Events;
using Leopotam.Ecs;

namespace Clicker.Systems
{
    public class InitBusinessSystem : IEcsRunSystem
    {
        private readonly EcsFilter<BusinessView, BusinessStaticDataReference, NeedInitBusinessEvent>.Exclude<Business> filter = null;

        public void Run()
        {
            foreach (var index in filter)
            {
                ref var entity = ref filter.GetEntity(index);
                ref var business = ref entity.Get<Business>();
                UnityEngine.Debug.Log("int business");
            }
        }
    }
}