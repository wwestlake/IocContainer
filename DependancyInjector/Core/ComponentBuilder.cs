using DependancyInjector.API;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DependancyInjector.Core
{
    public class ComponentBuilder<T> where T: class
    {
        private IContainer _container;
        private Type _implementation;

        public ComponentBuilder(IContainer container, Type implementation)
        {
            _container = container;
            _implementation = implementation;
        }

        internal T Build()
        {
            return Build(typeof(T));
        }

        internal T Build(Type type)
        {
            var constructor = GetConstructor(_implementation);
            var parameters = constructor.GetParameters();
            List<object> paramList = new List<object>();
            foreach (var p in parameters)
            {
                paramList.Add(_container.Resolve(p.ParameterType));
            }
            return type.Assembly.CreateInstance(_implementation.FullName, false, BindingFlags.CreateInstance, null, paramList.ToArray(), CultureInfo.CurrentCulture, null) as T;
        }


        ConstructorInfo GetConstructor()
        {
            return GetConstructor(_implementation);
        }


        /// <summary>
        /// Finds and selects the constructor that:
        ///    1. Contains the greatest number of dependencies
        ///    2. All dependencies are resolvable by the container
        ///    3. Or the default constructor if no other constructors meets the criteria
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        ConstructorInfo GetConstructor(Type type)
        {
            IConfigureInternal config = _container.Configure() as IConfigureInternal;
            var ctors = type.GetConstructors(x => x.GetParameters().Count() == 0 || x.GetParameters().All(y => config.Registry.Where(z => z.Key == y.ParameterType).Count() > 0));

            int max = 0;
            ConstructorInfo result = ctors.FirstOrDefault();
            foreach (var ctor in ctors)
            {
                var count = ctor.GetParameters().Count();
                if ( count > max)
                {
                    result = ctor;
                    max = count;
                }
            }
            return result;
        }


    }
}
