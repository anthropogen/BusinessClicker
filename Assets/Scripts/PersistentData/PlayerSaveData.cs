using System.Collections.Generic;

namespace Clicker.PersistentData
{
    [System.Serializable]
    public class PlayerSaveData
    {
        public int Balance;
        public List<BusinessSaveData> BusinessData = new List<BusinessSaveData>();
    }
}
