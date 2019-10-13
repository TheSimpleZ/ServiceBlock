using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using ServiceBlock.Extensions;
using ServiceBlock.Interface;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.AspNetCore.Mvc.Controllers;
using Serilog;
using ServiceBlock.Interface.Resource;

namespace ServiceBlock.Core
{
    class GenericControllerFeatureProvider : IApplicationFeatureProvider<ControllerFeature>
    {
        public void PopulateFeature(IEnumerable<ApplicationPart> parts, ControllerFeature feature)
        {
            var resourceControllers = Block.GetResourceTypes().Select(r => typeof(ResourceController<>).MakeGenericType(r).GetTypeInfo());
            foreach (var controller in resourceControllers)
            {
                feature.Controllers.Add(controller);
                Log.Logger.Information("Controller for resource {ResourceName} has been registered.", controller.GetGenericArguments().FirstOrDefault().Name);
            }
        }
    }
}