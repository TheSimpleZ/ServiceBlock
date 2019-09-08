using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.AspNetCore.Mvc.Controllers;

namespace MicroNet.Startup
{
    public class GenericControllerFeatureProvider : IApplicationFeatureProvider<ControllerFeature>
    {
        public void PopulateFeature(IEnumerable<ApplicationPart> parts, ControllerFeature feature)
        {
            var currentAssembly = Assembly.GetEntryAssembly();
            var candidates = currentAssembly.GetExportedTypes().Where(x => typeof(IResource).IsAssignableFrom(x));

            foreach (var candidate in candidates)
            {
                feature.Controllers.Add(
                    typeof(ResourceController<>).MakeGenericType(candidate).GetTypeInfo()
                );
            }
        }
    }
}