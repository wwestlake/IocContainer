using DependancyInjector.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependancyInjector.Core
{
    public class RegistryEntry : IRegistryEntry
    {
        Type key;
        Type result;

        internal RegistryEntry(Type t)
        {
            Key = t;
        }

        public Type Key
        {
            get
            {
                return key;
            }

            set
            {
                key = value;
            }
        }

        public Type Result
        {
            get
            {
                return result;
            }

            set
            {
                result = value;
            }
        }

        public static IRegistryEntry For<T>() where T: class
        {
            return new RegistryEntry(typeof(T));
        }

        IRegistryEntry IRegistryEntry.Use<T>()
        {
            this.Result = typeof(T);
            return this;
        }



    }
}
