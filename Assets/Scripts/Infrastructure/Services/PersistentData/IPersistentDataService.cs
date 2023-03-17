using Clicker.PersistentData;

namespace Clicker.Infrastructure
{
    public interface IPersistentDataService : IService
    {
        PlayerSaveData PlayerData { get; }

        void Load();
        void Save();
    }
}