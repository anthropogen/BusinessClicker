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
        private readonly IPersistentDataService _persistentDataService;
        private EcsWorld _ecsWorld;
        private EcsSystems _systems;

        public GameLoopState(IAssetProvider assetProvider, IStaticDataService staticDataService, IPersistentDataService persistentDataService)
        {
            _assetProvider = assetProvider;
            _staticDataService = staticDataService;
            _persistentDataService = persistentDataService;
        }

        public void Enter()
        {
            _ecsWorld = new EcsWorld();
            _systems = new EcsSystems(_ecsWorld);
            AddSystems();
            AddOneFrameComponents();

            _systems.Inject(_persistentDataService.PlayerData);

            _systems.ConvertScene();
            _systems.Init();

#if UNITY_EDITOR
            Leopotam.Ecs.UnityIntegration.EcsWorldObserver.Create(_ecsWorld);
            Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create(_systems);
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
            _systems.OneFrame<IncomeChangedEvent>();
            _systems.OneFrame<UpgradeBusinessEvent>();
        }

        private void AddSystems()
        {
            _systems.Add(new LevelUpBusinessSystem());
            _systems.Add(new UpgradeSystem());
            _systems.Add(new CreateBusinessViewSystem(_assetProvider, _staticDataService));
            _systems.Add(new InitBusinessSystem());
            _systems.Add(new BusinessProgressSystem());
            _systems.Add(new BusinessIncomeSystem());
            _systems.Add(new UpdateBalanceSystem());
            _systems.Add(new UpdateBusinessViewButtonsSystem());
            _systems.Add(new UpdateIncomeViewSystem());
        }
    }
}
