using System;
using System.Linq;

namespace mService.Interface.Storage
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public class StorageAttribute : Attribute
    {

        public Type storageType { get; set; }

        public StorageAttribute(Type storageType)
        {
            if (!storageType.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IStorage<>)))
                throw new InvalidStorageException($"{storageType} must implement IStorage<>");

            this.storageType = storageType;
        }
    }
}