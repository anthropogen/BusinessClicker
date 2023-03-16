using System;
using System.ComponentModel.Design;

namespace Clicker.Infrastructure
{
    public interface IService
    {
    }

    public class ServiceLocator
    {
        public void Register<TService>(TService service) where TService : IService, new()
        {

        }

        public TService Release<TService>() where TService : IService, new()
        {
            throw new InvalidOperationException($"Doesn't have {typeof(TService)}");
        }
    }
}
