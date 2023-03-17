using UnityEngine;

namespace Clicker.Infrastructure
{
    public sealed class Bootstrapper : MonoBehaviour
    {
        private GameStateMachine _stateMachine;
        private ServiceLocator _serviceLocator;

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
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
            _stateMachine = new GameStateMachine(_serviceLocator, this);
            _stateMachine.Change<BootstrapState>();
        }
    }
}