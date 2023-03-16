using System;
using System.Collections.Generic;
using UnityEngine;

namespace Clicker.Infrastructure
{
    public sealed class Bootstrapper : MonoBehaviour
    {
        private GameStateMachine _stateMachine;
        private ServiceLocator _serviceLocator;

        private void Awake()
        {
            CreateGameStateMachine();
        }

        private void Update()
        {
            _stateMachine.Run();
        }

        private void OnDestroy()
        {
            _stateMachine.Dispose();
        }

        private void CreateGameStateMachine()
        {
            _serviceLocator = new ServiceLocator();
            var states = new Dictionary<Type, IGameState>();
            states[typeof(BootstrapState)] = new BootstrapState(_serviceLocator);
            _stateMachine = new GameStateMachine(states);
            _stateMachine.Change<BootstrapState>();
        }
    }
}