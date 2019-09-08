using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Startup
{
    public interface ITransformer<T>
    {
        Task<IEnumerable<T>> OnGet(IEnumerable<T> resources);
        Task<T> OnGet(T resource);

        Task<T> OnCreate(T resource);
        Task<T> OnReplace(T resource);
        Task<T> OnDelete(Guid Id);

    }
}