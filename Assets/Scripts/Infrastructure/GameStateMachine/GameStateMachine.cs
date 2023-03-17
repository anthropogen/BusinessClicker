using System;
using System.Collections.Generic;
using System.Linq;

namespace Clicker.Infrastructure
{
    public sealed class GameStateMachine : IDisposable
    {
        private readonly Dictionary<Type, IGameState> _states;
        private readonly ServiceLocator _serviceLocator;
        private IGameState _current;

        public GameStateMachine(ServiceLocator serviceLocator, Bootstrapper bootstrapper)
        {
            _serviceLocator = serviceLocator;
            var states = new Dictionary<Type, IGameState>();
            states[typeof(BootstrapState)] = new BootstrapState(this, _serviceLocator, bootstrapper);
            states[typeof(LoadGameState)] = new LoadGameState(_serviceLocator.Release<ISceneLoadService>(), _serviceLocator.Release<IPersistentDataService>(), this);
            states[typeof(GameState)] = new GameState();
            _states = states;
        }

        public void Change<TState>() where TState : class, IGameState
        {
            var type = typeof(TState);
            if (_states.TryGetValue(type, out var next))
            {
                _current?.Exit();
                _current = next;
                _current.Enter();
            }
            else
                throw new InvalidOperationException($"Doesn't have {type} state");
        }

        public void Run()
            => _current?.Run();

        public void Dispose()
        {
            foreach (var state in _states.Values.Where(s => s is IDisposable))
            {
                (state as IDisposable).Dispose();
                UnityEngine.Debug.Log($"dispose state {state.ToString()}");
            }
        }
    }
}