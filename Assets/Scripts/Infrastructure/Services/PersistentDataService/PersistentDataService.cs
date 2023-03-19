using Clicker.PersistentData;
using UnityEngine;

namespace Clicker.Infrastructure
{
    public class PersistentDataService : IPersistentDataService
    {
        public const string SavePath = "PlayerData";

        public PlayerData PlayerData { get; private set; }

        public void Load()
        {
            PlayerData = new PlayerData();
        }

        public void Save()
        {

        }
    }
}

