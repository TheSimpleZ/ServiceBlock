using System;
using System.ComponentModel;

namespace ServiceBlock.Interface.Resource
{
    public abstract class AbstractResource
    {
        [ReadOnly(true)]
        public virtual Guid Id { get; set; } = Guid.NewGuid();
    }
}