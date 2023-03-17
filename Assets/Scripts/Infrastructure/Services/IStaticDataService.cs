using Clicker.StaticData;

namespace Clicker.Infrastructure
{
    public interface IStaticDataService : IService
    {
        BusinessStaticData[] GetAllBusinessDatas();
    }
}