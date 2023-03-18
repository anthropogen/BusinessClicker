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
        private EcsWorld ecsWorld;
        private EcsSystems systems;

        public GameLoopState(IAssetProvider assetProvider, IStaticDataService staticDataService)
        {
            _assetProvider = assetProvider;
            _staticDataService = staticDataService;
        }

        public void Enter()
        {
            ecsWorld = new EcsWorld();
            systems = new EcsSystems(ecsWorld);

            systems.Add(new CreateBusinessViewSystem(_assetProvider, _staticDataService));
            systems.Add(new InitBusinessSystem());
            systems.Add(new BusinessProgressSystem());

            systems.OneFrame<NeedInitBusinessEvent>();

            systems.ConvertScene();
            systems.Init();
        }

        public void Exit()
        {
            systems.Destroy();
            ecsWorld.Destroy();
        }

        public void Run()
        {
            systems?.Run();
        }
    }
}
