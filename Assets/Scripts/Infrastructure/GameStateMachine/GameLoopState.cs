using Clicker.Events;
using Clicker.Systems;
using Leopotam.Ecs;
using Voody.UniLeo;

namespace Clicker.Infrastructure
{
    public class GameLoopState : IRunGameState
    {
        private readonly IAssetProvider _assetProvider;
        private readonly IStaticDataService _staticDataService;
        private EcsWorld _ecsWorld;
        private EcsSystems _systems;

        public GameLoopState(IAssetProvider assetProvider, IStaticDataService staticDataService)
        {
            _assetProvider = assetProvider;
            _staticDataService = staticDataService;
        }

        public void Enter()
        {
            _ecsWorld = new EcsWorld();
            _systems = new EcsSystems(_ecsWorld);
            AddSystems();
            AddOneFrameComponents();
            _systems.ConvertScene();
            _systems.Init();
        }


        public void Exit()
        {
            _systems.Destroy();
            _ecsWorld.Destroy();
        }

        public void Run()
        {
            _systems?.Run();
        }

        private void AddOneFrameComponents()
        {
            _systems.OneFrame<NeedInitBusinessEvent>();
            _systems.OneFrame<AddIncomeEvent>();
        }

        private void AddSystems()
        {
            _systems.Add(new CreateBusinessViewSystem(_assetProvider, _staticDataService));
            _systems.Add(new InitBusinessSystem());
            _systems.Add(new BusinessProgressSystem());
        }
    }
}
