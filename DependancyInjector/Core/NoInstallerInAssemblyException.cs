using System;
using System.Runtime.Serialization;

namespace DependancyInjector.Core
{
    [Serializable]
    internal class NoInstallerInAssemblyException : Exception
    {
        public NoInstallerInAssemblyException()
        {
        }

        public NoInstallerInAssemblyException(string message) : base(message)
        {
        }

        public NoInstallerInAssemblyException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NoInstallerInAssemblyException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}