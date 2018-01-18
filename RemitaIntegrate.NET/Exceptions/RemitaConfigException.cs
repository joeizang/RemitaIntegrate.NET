using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace RemitaIntegrate.NET.Exceptions
{
    public class RemitaConfigException : Exception
    {
        public RemitaConfigException()
        {
        }

        public RemitaConfigException(string message) : base(message)
        {
        }

        public RemitaConfigException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected RemitaConfigException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
