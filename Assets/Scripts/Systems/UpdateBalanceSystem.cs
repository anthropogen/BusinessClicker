using Clicker.Components;
using Clicker.PersistentData;
using Leopotam.Ecs;
using UnityEngine;

namespace Clicker.Systems
{
    public class UpdateBalanceSystem : IEcsRunSystem
    {
        private readonly EcsFilter<BalanceView> _filter;
        private readonly PlayerData _playerData;
        public void Run()
        {
            foreach (var index in _filter)
            {
                ref var view = ref _filter.Get1(index);
                view.Counter.text = $"{_playerData.Balance}$";
            }
        }
    }
}
