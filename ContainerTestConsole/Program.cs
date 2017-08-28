using DependancyInjector.API;
using DependancyInjector.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestAssembly;

namespace ContainerTestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            IContainer container = new Container();
            container.Configure().ForAssembly().ContainingClass<MyInstaller>().Install();
            

            ITestComponent ti = container.Resolve<ITestComponent>();
            ti.Test();


            Console.ReadKey();
        }
    }
}
