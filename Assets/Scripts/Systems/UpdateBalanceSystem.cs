using Clicker.Components;
using Clicker.Events;
using Clicker.PersistentData;
using Leopotam.Ecs;

namespace Clicker.Systems
{
    public class UpdateBalanceSystem : IEcsRunSystem, IEcsInitSystem
    {
        private readonly EcsWorld _ecsWorld;
        private readonly EcsFilter<BalanceView> _balanceFilter;
        private readonly EcsFilter<AddIncomeEvent> _incomeFilter;
        private readonly PlayerData _playerData;

        public void Init()
        {
            UpdateBalanceView();
        }

        public void Run()
        {
            if (_incomeFilter.GetEntitiesCount() < 1)
                return;

            UpdateBalanceView();
        }


        private void UpdateBalanceView()
        {
            foreach (var index in _balanceFilter)
            {
                ref var view = ref _balanceFilter.Get1(index);
                view.Counter.text = $"{_playerData.Balance}$";
            }
            SendBalanceChangedEvent();
        }

        private void SendBalanceChangedEvent()
        {
            var entity = _ecsWorld.NewEntity();
            entity.Get<BalanceChangedEvent>();
        }
    }
}
