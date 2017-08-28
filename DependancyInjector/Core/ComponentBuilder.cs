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

        ConstructorInfo GetConstructor(Type type)
        {
            var csts = from c in type.GetConstructors()
                       where c.GetParameters().Count() == 0 || c.GetParameters().All(x => x.ParameterType.IsInterface)
                       select c;
            return csts.FirstOrDefault();
        }


    }
}
