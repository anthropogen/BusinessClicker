namespace Clicker.Infrastructure
{
    public class BootstrapState : IGameState
    {
        private readonly ServiceLocator _serviceLocator;

        public BootstrapState(ServiceLocator serviceLocator)
        {
           _serviceLocator = serviceLocator;
        }

        public void Enter()
        {
        }

        public void Exit()
        {
        }

        public void Run()
        {

        }
    }
}
