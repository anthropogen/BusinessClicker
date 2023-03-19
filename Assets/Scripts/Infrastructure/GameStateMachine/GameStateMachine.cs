using System;
using System.Collections.Generic;

namespace Clicker.Infrastructure
{
    public sealed class GameStateMachine : IDisposable
    {
        private readonly Dictionary<Type, IGameState> _states;
        private readonly ServiceLocator _serviceLocator;
        private IGameState _currentState;
        private IRunGameState _currentRunState;

        public GameStateMachine(ServiceLocator serviceLocator, IAssetProvider _assetProvider, PersistentMonoProvider persistentMono, Bootstrapper bootstrapper)
        {
            _serviceLocator = serviceLocator;
            var states = new Dictionary<Type, IGameState>();
            states[typeof(BootstrapState)] = new BootstrapState(this, _serviceLocator, _assetProvider,persistentMono, bootstrapper);
            states[typeof(LoadGameState)] = new LoadGameState(_serviceLocator.Release<ISceneLoadService>(), _serviceLocator.Release<IPersistentDataService>(), this);
            states[typeof(GameLoopState)] = new GameLoopState(_assetProvider, _serviceLocator.Release<IStaticDataService>(), _serviceLocator.Release<IPersistentDataService>());
            _states = states;
        }

        public void Change<TState>() where TState : class, IGameState
        {
            var type = typeof(TState);
            if (_states.TryGetValue(type, out var next))
            {
                _currentState?.Exit();
                _currentState = next;
                _currentState.Enter();
                _currentRunState = next as IRunGameState;
            }
            else
                throw new InvalidOperationException($"Doesn't have {type} state");
        }

        public void Run()
            => _currentRunState?.Run();

        public void Dispose()
            => _currentState.Exit();
    }
}