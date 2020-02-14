using System.Linq;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.AspNetCore.Http;

namespace ServiceBlock.Internal
{
    class ReDocOperationFilter : IOperationFilter
    {

        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            operation.Summary = OperationDescription(context);
        }

        private string OperationDescription(OperationFilterContext context)
        {
            var resourceName = context.MethodInfo.DeclaringType?.GetGenericArguments().Single().Name;
            var methodName = context.ApiDescription.HttpMethod;

            if (HttpMethods.IsGet(methodName))
            {
                if (!context.MethodInfo.GetParameters().Any())
                    return $"Retrieve all {resourceName}";
                else
                    return $"Retrieve {resourceName}";
            }

            if (HttpMethods.IsPost(methodName))
                return $"Create {resourceName}";

            if (HttpMethods.IsPut(methodName))
                return $"Replace {resourceName}";

            if (HttpMethods.IsDelete(methodName))
                return $"Delete {resourceName}";

            return methodName;
        }
    }
}