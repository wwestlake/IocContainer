using System;
using System.Runtime.Serialization;

namespace DependancyInjector.Core
{
    [Serializable]
    internal class InvalidInstallerException : Exception
    {
        public InvalidInstallerException()
        {
        }

        public InvalidInstallerException(string message) : base(message)
        {
        }

        public InvalidInstallerException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidInstallerException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}