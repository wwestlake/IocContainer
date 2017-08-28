using DependancyInjector.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DependancyInjector.Core
{
    public class AssemblyConfig : IAssemblyConfig
    {
        private Assembly _assembly;
        private IContainer _container;
        private IEnumerable<Type> _installers;


        public AssemblyConfig(Assembly assembly, IContainer container)
        {
            _assembly = assembly;
            _container = container;

            var installers = (from c in assembly.GetTypes() where typeof(IContainerInstaller).IsAssignableFrom(c) select c);

            if (installers.Count() == 0)
            {
                throw new NoInstallerInAssemblyException();
            }

            _installers = installers;

        }

        public void Install()
        {
            foreach (var installerType in _installers)
            {
                var installer = installerType.Assembly.CreateInstance(installerType.FullName) as IContainerInstaller;
                if (installer == null) throw new InvalidInstallerException();
                installer.Install(_container, _container.Configure());
            }
        }


    }
}
