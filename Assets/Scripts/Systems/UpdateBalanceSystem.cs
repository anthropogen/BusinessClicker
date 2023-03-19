using Clicker.Components;
using Clicker.Events;
using Clicker.PersistentData;
using Leopotam.Ecs;

namespace Clicker.Systems
{
    public class UpdateBalanceSystem : IEcsRunSystem, IEcsInitSystem
    {
        private readonly EcsFilter<BalanceView> _balanceViewFilter;
        private readonly EcsFilter<BalanceChangedEvent> _changedBalanceFilter;
        private readonly PlayerData _playerData;

        public void Init()
        {
            UpdateBalanceView();
        }

        public void Run()
        {
            if (_changedBalanceFilter.GetEntitiesCount() < 1)
                return;

            UpdateBalanceView();
        }


        private void UpdateBalanceView()
        {
            foreach (var index in _balanceViewFilter)
            {
                ref var view = ref _balanceViewFilter.Get1(index);
                view.Counter.text = $"{_playerData.Balance}$";
            }
        }
    }
}
