using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAssembly
{
    public class TestComponent : ITestComponent
    {
        private IDependency _depends;

        public TestComponent(IDependency depends)
        {
            _depends = depends;
        }

        public void Test()
        {
            _depends.Test();
        }

    }
}
