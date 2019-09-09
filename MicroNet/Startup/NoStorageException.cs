using System.Runtime.Serialization;

namespace MicroNet.Storage
{
    [System.Serializable]
    public class NoStorageException : System.Exception
    {
        public NoStorageException() { }
        public NoStorageException(string message) : base(message) { }
        public NoStorageException(string message, System.Exception inner) : base(message, inner) { }
        protected NoStorageException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}