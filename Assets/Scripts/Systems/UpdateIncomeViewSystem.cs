using Clicker.Components;
using Clicker.Events;
using Clicker.StaticData;
using Leopotam.Ecs;

namespace Clicker.Systems
{
    public class UpdateIncomeViewSystem : IEcsRunSystem
    {
        private readonly EcsFilter<BusinessView, BusinessStaticDataReference, BusinessLevel, IncomeChangedEvent> _filter = null;

        public void Run()
        {
            foreach (var index in _filter)
            {
                ref var view = ref _filter.Get1(index);
                ref var staticData = ref _filter.Get2(index);
                ref var business = ref _filter.Get3(index);

                var firstPercent = staticData.StaticData.GetPercentMultiplier(UpgradeType.UpgradeFirst, business.UpgradeLevels[0]);
                var secondPercent = staticData.StaticData.GetPercentMultiplier(UpgradeType.UpgradeSecond, business.UpgradeLevels[1]);
                int level = business.Level > 0 ? business.Level : 1;
                var income = CalculateHelper.CalculateIncome(level, staticData.StaticData.BaseIncome, firstPercent, secondPercent);
                view.IncomeText.text = $"{income}$";
            }
        }
    }
}
