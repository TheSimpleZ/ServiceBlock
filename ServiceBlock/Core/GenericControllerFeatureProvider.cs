using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using ServiceBlock.Extensions;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.AspNetCore.Mvc.Controllers;
using System.ComponentModel;

namespace ServiceBlock.Core
{
    class GenericControllerFeatureProvider : IApplicationFeatureProvider<ControllerFeature>
    {
        public void PopulateFeature(IEnumerable<ApplicationPart> parts, ControllerFeature feature)
        {
            foreach (var controller in Block.Controllers)
            {
                feature.Controllers.Add(controller);
            }
        }
    }
}