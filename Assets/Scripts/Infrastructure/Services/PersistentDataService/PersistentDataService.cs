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
            if (!PlayerPrefs.HasKey(SavePath))
            {
                PlayerData = new PlayerData();
                return;
            }
            PlayerData = PlayerPrefs.GetString(SavePath).
                FromJson().
                ToPlayerData();
        }

        public void Save()
        {
            var json = PlayerData.ToPlayerSaveData()
                .ToJson();
            PlayerPrefs.SetString(SavePath, json);
            PlayerPrefs.Save();
        }
    }
}

