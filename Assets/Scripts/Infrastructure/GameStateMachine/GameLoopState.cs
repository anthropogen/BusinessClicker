using Clicker.Events;
using Clicker.PersistentData;
using Clicker.Systems;
using Leopotam.Ecs;
using Leopotam.Ecs.UnityIntegration;
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

            _systems.Inject(new PlayerData());

            _systems.ConvertScene();
            _systems.Init();

#if UNITY_EDITOR
            EcsWorldObserver.Create(_ecsWorld);
            EcsSystemsObserver.Create(_systems);
#endif
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
            _systems.OneFrame<BalanceChangedEvent>();
            _systems.OneFrame<BusinessInitializedEvent>();
            _systems.OneFrame<UpBusinessLevelEvent>();
        }

        private void AddSystems()
        {
            _systems.Add(new LevelUpBusinessSystem());
            _systems.Add(new CreateBusinessViewSystem(_assetProvider, _staticDataService));
            _systems.Add(new InitBusinessSystem());
            _systems.Add(new BusinessProgressSystem());
            _systems.Add(new BusinessIncomeSystem());
            _systems.Add(new UpdateBalanceSystem());
            _systems.Add(new UpdateBusinessViewButtonsSystem());
        }
    }
}
