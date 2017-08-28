using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependancyInjector.API
{
    public interface IConfigure
    {
        IAssemblyLocator ForAssembly();
        IConfigure Register(IRegistryEntry entry);
        IRegistryEntry Component<T>() where T: class;
    }

    internal interface IConfigureInternal : IConfigure
    {
        IList<IRegistryEntry> Registry { get; }
    }

}
