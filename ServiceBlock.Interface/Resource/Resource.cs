using System;
using System.ComponentModel;

namespace ServiceBlock.Interface.Resource
{
    public abstract class Resource
    {
        [ReadOnly(true)]
        public virtual Guid Id { get; set; } = Guid.NewGuid();
    }
}