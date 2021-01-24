using System;
using System.Runtime.Serialization;

namespace Heikal.Lubricant.Core.BusinessException
{
    [Serializable]
    public class LineServiceException: GenericServiceException
    {
        public LineServiceException()
                    : base()
        {
        }
        public LineServiceException(string message)
            : base(message)
        {
        }
        public LineServiceException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
        protected LineServiceException(SerializationInfo serializationInfo, StreamingContext streamingContext)
            : base(serializationInfo, streamingContext)
        {
        }
    }
}
