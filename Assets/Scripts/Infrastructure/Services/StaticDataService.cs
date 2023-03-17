using Clicker.StaticData;
using UnityEngine;

namespace Clicker.Infrastructure
{
    public class StaticDataService : IStaticDataService
    {
        public const string BusinessConfigsPath = "Business";

        public BusinessStaticData[] GetAllBusinessDatas()
            => Resources.LoadAll<BusinessStaticData>(BusinessConfigsPath);
    }
}
