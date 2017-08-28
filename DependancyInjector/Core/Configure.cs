using DependancyInjector.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependancyInjector.Core
{
    public class Configure : IConfigureInternal
    {
        IAssemblyLocator _assemblyLocator;
        private IContainer _container;
        List<IRegistryEntry> entries = new List<IRegistryEntry>();

        public IList<IRegistryEntry> Registry
        {
            get
            {
                return entries;
            }
        }

        public Configure(IContainer container)
        {
            _container = container;
        }

        public IRegistryEntry Component<T>() where T : class
        {
            return RegistryEntry.For<T>();
        }

        public IAssemblyLocator ForAssembly()
        {
            return _assemblyLocator ?? (_assemblyLocator = new AssemblyLocator(_container));
        }

        public IConfigure Register(IRegistryEntry entry)
        {
            entries.Add(entry);
            return this;
        }


    }
}
