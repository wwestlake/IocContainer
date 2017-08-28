using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependancyInjector.API
{
    public interface IRegistryEntry
    {
        IRegistryEntry Use<T>() where T : class;
        Type Key { get; set; }
        Type Result { get; set; }
    }
}
