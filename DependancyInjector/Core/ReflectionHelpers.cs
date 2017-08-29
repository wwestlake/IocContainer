using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DependancyInjector.Core
{
    public static class ReflectionHelpers
    {
        
        public static IEnumerable<ConstructorInfo> GetConstructors(this Type type, Expression<Func<ConstructorInfo, bool>> predicate)
        {
            var condition = predicate.Compile();
            var result = new List<ConstructorInfo>();
            foreach (var con in type.GetConstructors())
            {
                if (condition(con))
                {
                    result.Add(con);
                } 
            }
            return result.AsEnumerable();
        }

        public static IEnumerable<MethodInfo> GetMethods(this Type type, Expression<Func<MethodInfo, bool>> predicate)
        {
            var condition = predicate.Compile();
            var result = new List<MethodInfo>();
            foreach (var method in type.GetMethods())
            {
                if (condition(method))
                {
                    result.Add(method);
                }
            }
            return result.AsEnumerable();
        }

        public static IEnumerable<ParameterInfo> GetParameters(this ConstructorInfo ctor, Expression<Func<ParameterInfo, bool>> predicate)
        {
            var condition = predicate.Compile();
            var result = new List<ParameterInfo>();
            foreach (var parameter in ctor.GetParameters())
            {
                if (condition(parameter))
                {
                    result.Add(parameter);
                }
            }
            return result.AsEnumerable();
        }


    }
}
