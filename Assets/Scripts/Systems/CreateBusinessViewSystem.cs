using Clicker.Components;
using Clicker.Infrastructure;
using Clicker.Providers;
using Leopotam.Ecs;
using UnityEngine;

namespace Clicker.Systems
{
    public class CreateBusinessViewSystem : IEcsInitSystem
    {
        private readonly EcsFilter<BusinessViewParent> parentFilter;
        private readonly IStaticDataService _staticDataService;
        private IAssetProvider _assetProvider;

        public CreateBusinessViewSystem(IAssetProvider assetProvider, IStaticDataService staticDataService)
        {
            _assetProvider = assetProvider;
            _staticDataService = staticDataService;
        }

        public void Init()
        {
            foreach (var parentId in parentFilter)
            {
                var parent = parentFilter.Get1(parentId);

                foreach (var businessData in _staticDataService.GetAllBusinessDatas())
                {
                    var view = GameObject.Instantiate(_assetProvider.BusinessViewTemplate, parent.Transform);
                    view.GetComponent<BusinessStaticDataReferenceProvider>().Construct(businessData);
                }
            }
        }
    }
}