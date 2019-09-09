using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using MicroNet.Extensions;
using MicroNet.Interface;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.AspNetCore.Mvc.Controllers;

namespace MicroNet.Startup
{
    public class GenericControllerFeatureProvider : IApplicationFeatureProvider<ControllerFeature>
    {
        public void PopulateFeature(IEnumerable<ApplicationPart> parts, ControllerFeature feature)
        {
            var candidates = Assembly.GetEntryAssembly().GetAllTypes().Where(x => typeof(IResource).IsAssignableFrom(x) && x.IsClass && !x.IsAbstract);

            foreach (var candidate in candidates)
            {
                feature.Controllers.Add(
                    typeof(ResourceController<>).MakeGenericType(candidate).GetTypeInfo()
                );
            }
        }
    }
}