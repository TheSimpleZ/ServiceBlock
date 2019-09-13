using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceBlock.Interface.Storage
{
    public interface IStorage<T>
    {
        Task<IEnumerable<T>> Get();
        Task<T> Get(Guid Id);

        Task<T> Create(T resource);
        Task<T> Replace(T resource);
        Task Delete(Guid Id);

    }
}