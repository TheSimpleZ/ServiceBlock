using System;
using System.Collections.Generic;

namespace Startup
{
    public interface IStorage<T>
    {
        IEnumerable<T> Get();
    }
}