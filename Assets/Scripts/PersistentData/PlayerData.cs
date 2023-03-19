using Clicker.Components;
using System.Collections.Generic;

namespace Clicker.PersistentData
{
    [System.Serializable]
    public class PlayerData
    {
        public int Balance = 10000;

        public Dictionary<string, BusinessLevel> Business = new Dictionary<string, BusinessLevel>();
    }
}
