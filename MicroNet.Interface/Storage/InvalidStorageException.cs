namespace MicroNet.Interface.Storage
{
    [System.Serializable]
    public class InvalidStorageException : System.Exception
    {
        public InvalidStorageException() { }
        public InvalidStorageException(string message) : base(message) { }
        public InvalidStorageException(string message, System.Exception inner) : base(message, inner) { }
        protected InvalidStorageException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}