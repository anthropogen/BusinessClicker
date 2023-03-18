using Clicker.Providers;

namespace Clicker.Infrastructure
{
    public interface IAssetProvider : IService
    {
        BusinessViewProvider BusinessViewTemplate { get; }
    }
}