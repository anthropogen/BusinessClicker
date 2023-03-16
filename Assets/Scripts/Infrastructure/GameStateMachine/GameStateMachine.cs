using System;
using System.Collections.Generic;
using System.Linq;

namespace Clicker.Infrastructure
{
    public sealed class GameStateMachine : IDisposable
    {
        private readonly Dictionary<Type, IGameState> _states;
        private IGameState _current;

        public GameStateMachine(Dictionary<Type, IGameState> states)
        {
            _states = states;
        }

        public void Change<TState>() where TState : IGameState, new()
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
                UnityEngine.Debug.Log($"dispose state {state.ToString()}");
            }
        }
    }
}