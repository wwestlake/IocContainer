using DependancyInjector.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DependancyInjector.Core
{
    public class AssemblyLocator : IAssemblyLocator
    {
        private IContainer _container;

        public AssemblyLocator(IContainer container)
        {
            _container = container;
        }

        public IAssemblyConfig ContainingClass<T>()
        {
            return new AssemblyConfig(typeof(T).Assembly, _container);
        }
    }
}
