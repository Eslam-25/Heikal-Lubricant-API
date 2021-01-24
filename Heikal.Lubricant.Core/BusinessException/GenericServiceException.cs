using System;
using System.Runtime.Serialization;

namespace Heikal.Lubricant.Core.BusinessException
{
    [Serializable]
    public class GenericServiceException : Exception
    {
        public GenericServiceException()
            : base()
        {
        }
        public GenericServiceException(string message)
            : base(message)
        {
        }
        public GenericServiceException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
        protected GenericServiceException(SerializationInfo serializationInfo, StreamingContext streamingContext)
            : base(serializationInfo, streamingContext)
        {
        }
    }
}
