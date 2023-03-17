namespace Clicker.Infrastructure
{
    public class LoadGameState : IGameState
    {
        public const string GameLevel = "Game";
        private readonly ISceneLoadService _sceneLoadService;
        private readonly IPersistentDataService _persistentDataService;
        private readonly GameStateMachine _gameStateMachine;

        public LoadGameState(ISceneLoadService sceneLoadService, IPersistentDataService persistentDataService, GameStateMachine gameStateMachine)
        {
            _sceneLoadService = sceneLoadService;
            _persistentDataService = persistentDataService;
            _gameStateMachine = gameStateMachine;
        }

        public void Enter()
        {
            _persistentDataService.Load();

            //create game world;
            //
            //

            _sceneLoadService.LoadLevel(GameLevel, () => _gameStateMachine.Change<GameState>());
        }

        public void Exit()
        {

        }

        public void Run()
        {

        }
    }
}
