using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Clicker.Infrastructure
{
    public class Bootstrapper : MonoBehaviour
    {
        private GameStateMachine _stateMachine;
        private void Awake()
        {
            var states = new Dictionary<Type, IGameState>();
            states[typeof(BootstrapState)] = new BootstrapState();
            _stateMachine = new GameStateMachine(states);
            _stateMachine.Change<BootstrapState>();
        }

        private void Update()
        {
            _stateMachine.Run();
        }

        private void OnDestroy()
        {
            _stateMachine.Dispose();
        }
    }
}