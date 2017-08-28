using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAssembly
{
    public class Dependency : IDependency
    {
        public void Test()
        {
            Console.WriteLine("Dependency Reolved and Injected!!");
        }
    }
}
