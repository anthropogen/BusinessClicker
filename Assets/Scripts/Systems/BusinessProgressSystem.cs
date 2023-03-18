using Clicker.Components;
using Leopotam.Ecs;

namespace Clicker.Systems
{
    public class BusinessProgressSystem : IEcsRunSystem
    {
        private readonly EcsFilter<BusinessView, BusinessStaticDataReference, Business> _ecsFilter = null;

        public void Run()
        {
            foreach (var businessView in _ecsFilter)
            {

            }
        }
    }
}