using Clicker.Components;
using Clicker.Events;
using Clicker.PersistentData;
using Clicker.StaticData;
using Leopotam.Ecs;

namespace Clicker.Systems
{
    public class UpdateBusinessViewButtonsSystem : IEcsRunSystem
    {
        private readonly PlayerData _playerData = null;
        private readonly EcsFilter<BalanceChangedEvent> _balanceFilter = null;
        private readonly EcsFilter<BusinessInitializedEvent> _initFilter = null;
        private readonly EcsFilter<BusinessView, BusinessStaticDataReference, BusinessLevel> _businessFilter = null;


        public void Run()
        {
            if (!IsNeedUpdate())
                return;
            foreach (var index in _businessFilter)
            {
                ref var view = ref _businessFilter.Get1(index);
                ref var staticData = ref _businessFilter.Get2(index);
                ref var levelData = ref _businessFilter.Get3(index);

                UpdateLevelUpButton(view, staticData, levelData);
                UpdateUpgradeButtons(view, staticData, levelData);
            }
        }

        private bool IsNeedUpdate()
            => _balanceFilter.GetEntitiesCount() > 0 || _initFilter.GetEntitiesCount() > 0;


        private void UpdateUpgradeButtons(BusinessView view, BusinessStaticDataReference staticData, BusinessLevel levelData)
        {
            foreach (var button in view.UpgradeButtons)
            {
                if (!staticData.StaticData.HasMultiplier(button.UpgradeType, levelData.UpgradeLevels[(int)button.UpgradeType]))
                {
                    button.SetInteractable(false);
                    button.SetPurchased();
                    continue;
                }

                var multiplier = staticData.StaticData.GetMultipier(button.UpgradeType, levelData.UpgradeLevels[(int)button.UpgradeType]);
                button.SetInteractable(multiplier.Price <= _playerData.Balance && levelData.Level > 0);
                button.SetPrice(multiplier.Price);
                button.SetMultiplier(multiplier.IncomeMultiplier);
            }
        }

        private void UpdateLevelUpButton(BusinessView view, BusinessStaticDataReference staticData, BusinessLevel levelData)
        {
            var price = CalculateHelper.CalculateLevelPrice(levelData.Level, staticData.StaticData.BasePrice);
            view.UpLevelButton.SetInteractable(price <= _playerData.Balance);
            view.UpLevelButton.SetPrice(price);
        }
    }
}
