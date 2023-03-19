using Clicker.Components;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Clicker.PersistentData
{
    [System.Serializable]
    public class PlayerData
    {
        public int Balance = 10000;

        public Dictionary<string, BusinessLevel> Business = new Dictionary<string, BusinessLevel>();
    }
    [System.Serializable]
    public class PlayerSaveData
    {
        public int Balance;
        public List<BusinessSaveData> BusinessData = new List<BusinessSaveData>();
    }

    [System.Serializable]
    public class BusinessSaveData
    {
        public string Name;
        public BusinessLevel Level;
    }

    public static class PersistentExtension
    {
        public static PlayerSaveData ToPlayerSaveData(this PlayerData data)
        {
            var result = new PlayerSaveData();
            result.Balance = data.Balance;
            data.Business.Select(b => new BusinessSaveData { Name = b.Key, Level = b.Value }).ToList();
            return result;
        }

        public static PlayerData ToPlayerData(this PlayerSaveData saveData)
        {
            var result = new PlayerData();
            result.Balance = saveData.Balance;
            result.Business = saveData.BusinessData.ToDictionary(b => b.Name, b => b.Level);
            return result;
        }

        public static string ToJson(this PlayerSaveData saveData)
            => JsonUtility.ToJson(saveData);

        public static PlayerSaveData FromJson(this string json)
            => JsonUtility.FromJson<PlayerSaveData>(json);
    }
}
