using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using ServiceBlock.Extensions;
using ServiceBlock.Interface.Resource;
using Newtonsoft.Json.Schema;
using Newtonsoft.Json.Schema.Generation;

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
                            Type = new JSchemaGenerator().Generate(q.PropertyType).Type.ToString()
                        }
                    });

                    foreach (var parameter in parameters)
                        operation.Parameters.Add(parameter);
                }
            }
        }
    }
}