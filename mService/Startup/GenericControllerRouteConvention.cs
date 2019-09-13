using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace mService.Startup
{
    public class GenericControllerRouteConvention : IControllerModelConvention
    {
        public void Apply(ControllerModel controller)
        {
            if (controller.ControllerType.IsGenericType)
            {
                var genericType = controller.ControllerType.GenericTypeArguments[0];
                var customNameAttribute = genericType.GetCustomAttribute<RouteAttribute>();
                var attr = new Microsoft.AspNetCore.Mvc.RouteAttribute($"/{genericType.Name}");

                // TODO: Add custom routes

                controller.Selectors.Add(new SelectorModel
                {
                    AttributeRouteModel = new AttributeRouteModel(attr),
                });
            }
        }
    }
}