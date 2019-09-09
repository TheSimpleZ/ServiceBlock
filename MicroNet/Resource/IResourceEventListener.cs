using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MicroNet
{
    public interface IResourceEventListener<T>
    {
        Task<IEnumerable<T>> OnGet(IEnumerable<T> resources);
        Task<T> OnGet(T resource);

        Task<T> OnCreate(T resource);
        Task<T> OnReplace(T resource);
        Task OnDelete(Guid Id);

    }
}