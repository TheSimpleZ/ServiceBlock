using System;
using System.Collections.Generic;

namespace Startup
{
    public interface IResource
    {
        Guid Id { get; set; }
    }
}