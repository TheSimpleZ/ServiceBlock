using System.Linq;
using System.Net.Http;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using ServiceBlock.Extensions;
using ServiceBlock.Interface.Resource;

namespace ServiceBlock.Internal
{
    class QueryParametersOperationFilter : IOperationFilter
    {

        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (context.ApiDescription.HttpMethod == HttpMethod.Get.Method)
            {
                var resourceType = context.MethodInfo.DeclaringType?.GetGenericArguments().Single();
                if (resourceType != null)
                {
                    var queryables = AbstractResource.GetQueryableProperties(resourceType);
                    var parameters = queryables.Select(q => new OpenApiParameter()
                    {
                        Name = q.Name,
                        In = ParameterLocation.Query,
                        Schema = new OpenApiSchema()
                        {
                            Type = q.GetJsonType()
                        }
                    });

                    foreach (var parameter in parameters)
                        operation.Parameters.Add(parameter);
                }
            }
        }
    }
}