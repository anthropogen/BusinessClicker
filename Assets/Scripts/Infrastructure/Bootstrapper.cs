using UnityEngine;

namespace Clicker.Infrastructure
{
    public sealed class Bootstrapper : MonoBehaviour
    {
        [SerializeField] private AssetProvider _assetProvider;
        [SerializeField] private PersistentMonoProvider persistentMono;
        private GameStateMachine _stateMachine;
        private ServiceLocator _serviceLocator;

        private void Awake()
        {
            Application.targetFrameRate = 60;
            DontDestroyOnLoad(gameObject);
            CreateGameStateMachine();
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

        private void CreateGameStateMachine()
        {
            _serviceLocator = new ServiceLocator();
            _stateMachine = new GameStateMachine(_serviceLocator, _assetProvider, persistentMono, this);
        }
    }
}