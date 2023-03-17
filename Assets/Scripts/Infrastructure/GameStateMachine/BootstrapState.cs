namespace Clicker.Infrastructure
{
    public class BootstrapState : IGameState
    {
        private readonly ServiceLocator _serviceLocator;
        private readonly GameStateMachine _gameStateMachine;

        public BootstrapState(GameStateMachine gameStateMachine, ServiceLocator serviceLocator, Bootstrapper bootstrapper)
        {
            _gameStateMachine = gameStateMachine;
            _serviceLocator = serviceLocator;

            RegiseterServices(bootstrapper);
        }

        public void Enter()
        {
            _gameStateMachine.Change<LoadGameState>();
        }

        public void Exit()
        {
        }

        public void Run()
        {

        }

        private void RegiseterServices(Bootstrapper bootstrapper)
        {
            _serviceLocator.Register<ISceneLoadService>(new SceneLoadService(bootstrapper));
            _serviceLocator.Register<IPersistentDataService>(new PersistentDataService());
        }
    }
}
