namespace Clicker.Infrastructure
{
    public class BootstrapState : IGameState
    {
        private readonly ServiceLocator _serviceLocator;
        private readonly GameStateMachine _gameStateMachine;
        public BootstrapState(GameStateMachine gameStateMachine, ServiceLocator serviceLocator, IAssetProvider _assetProvider, PersistentMonoProvider persistentMono, Bootstrapper bootstrapper)
        {
            _gameStateMachine = gameStateMachine;
            _serviceLocator = serviceLocator;
            RegiseterServices(bootstrapper, _assetProvider);
            persistentMono.Construct(_serviceLocator.Release<IPersistentDataService>());
        }

        public void Enter()
        {
            _gameStateMachine.Change<LoadGameState>();
        }

        public void Exit()
        {
        }

        private void RegiseterServices(Bootstrapper bootstrapper, IAssetProvider _assetProvider)
        {
            _serviceLocator.Register(_assetProvider);
            _serviceLocator.Register<ISceneLoadService>(new SceneLoadService(bootstrapper));
            _serviceLocator.Register<IPersistentDataService>(new PersistentDataService());
            _serviceLocator.Register<IStaticDataService>(new StaticDataService());
        }
    }
}
