using Clicker.Components;
using Clicker.StaticData;
using Voody.UniLeo;

namespace Clicker.Providers
{
    public class BusinessStaticDataReferenceProvider : MonoProvider<BusinessStaticDataReference>
    {
        public void Construct(BusinessStaticData staticData)
            => value.StaticData = staticData;
    }
}