using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependancyInjector.API
{
    public interface IContainer
    {
        IConfigure Configure();
        T Resolve<T>() where T : class;
        object Resolve(Type type);
    }
}
