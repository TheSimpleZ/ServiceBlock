using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using ServiceBlock.Extensions;
using ServiceBlock.Interface;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.AspNetCore.Mvc.Controllers;
using Serilog;
using ServiceBlock.Interface.Resource;
using System.ComponentModel;

namespace ServiceBlock.Core
{
    class GenericControllerFeatureProvider : IApplicationFeatureProvider<ControllerFeature>
    {
        public void PopulateFeature(IEnumerable<ApplicationPart> parts, ControllerFeature feature)
        {
            var publicResourceControllers = Block.ResourceTypes.Where(r => !r.HasAttribute<ReadOnlyAttribute>()).Select(r => typeof(ResourceController<>).MakeGenericType(r).GetTypeInfo());
            foreach (var controller in publicResourceControllers)
            {
                feature.Controllers.Add(controller);
            }

            var readOnlyResourceControllers = Block.ResourceTypes.Where(r => r.HasAttribute<ReadOnlyAttribute>()).Select(r => typeof(ReadOnlyResourceController<>).MakeGenericType(r).GetTypeInfo());
            foreach (var controller in readOnlyResourceControllers)
            {
                feature.Controllers.Add(controller);
            }
        }
    }
}