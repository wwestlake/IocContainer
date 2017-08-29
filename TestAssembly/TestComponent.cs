using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAssembly
{
    public class TestComponent : ITestComponent
    {
        private IDependency _depends1;
        private IDependency _depends2;

        public TestComponent()
        {

        }

        public TestComponent(IDependency depends1)
        {
            _depends1 = depends1;
        }


        public TestComponent(IDependency depends1, IDependency depends2)
        {
            _depends1 = depends1;
            _depends2 = depends2;
        }

        public void Test()
        {
            if (_depends1 != null) _depends1.Test();
            if (_depends2 != null) _depends2.Test();
        }

    }
}
