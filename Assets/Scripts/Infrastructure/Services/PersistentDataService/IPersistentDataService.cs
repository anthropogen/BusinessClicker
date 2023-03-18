using Clicker.PersistentData;

namespace Clicker.Infrastructure
{
    public interface IPersistentDataService : IService
    {
        PlayerData PlayerData { get; }

        void Load();
        void Save();
    }
}