using DependancyInjector.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependancyInjector.Core
{
    public class Container : IContainer
    {
        IConfigureInternal _configuration;

        public IConfigure Configure()
        {
            return _configuration ?? (_configuration = new Configure(this));
        }



        public T Resolve<T>() where T: class
        {
            var t = typeof(T);
            var result = _configuration.Registry.First(x => x.Key == t);
            ComponentBuilder<T> builder = new ComponentBuilder<T>(this, result.Result);
            return builder.Build();
        }

        public object Resolve(Type type)
        {

            return _configuration.Registry.First(x => x.Key == type);

        }

    }
}
