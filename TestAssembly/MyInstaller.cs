using DependancyInjector.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAssembly
{
    public class MyInstaller : IContainerInstaller
    {
        public void Install(IContainer container, IConfigure config)
        {
            Console.WriteLine("Installer Called");

            container.Configure().Register(config.Component<ITestComponent>().Use<TestComponent>());
            container.Configure().Register(config.Component<IDependency>().Use<Dependency>());
        }
    }
}
