using System;
using System.Linq;
using ServiceBlock.Extensions;

namespace ServiceBlock.Interface.Storage
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public class StorageAttribute : Attribute
    {

        public Type StorageType { get; set; }

        // Summary: This attribute should be used to mark the storage type of a resource
        //   Parameters:
        //     storageType: The type of storage that should be used
        public StorageAttribute(Type storageType)
        {
            if (!storageType.IsSubclassOfRawGeneric(typeof(Storage<>)))
                throw new InvalidStorageException($"{storageType} must implement {nameof(Storage)}<T>");

            this.StorageType = storageType;
        }
    }
}