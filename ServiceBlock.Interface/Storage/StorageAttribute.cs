using System;
using System.Linq;
using ServiceBlock.Extensions;

namespace ServiceBlock.Interface.Storage
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public class StorageAttribute : Attribute
    {

        public Type StorageType { get; set; }

        public StorageAttribute(Type storageType)
        {
            if (!storageType.IsSubclassOfRawGeneric(typeof(Storage<>)))
                throw new InvalidStorageException($"{storageType} must implement {nameof(Storage)}<T>");

            this.StorageType = storageType;
        }
    }
}