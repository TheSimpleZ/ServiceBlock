using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace ServiceBlock.Core
{
    public class ReadOnlySchemaFilter : ISchemaFilter
    {
        public void Apply(OpenApiSchema model, SchemaFilterContext context)
        {
            if (model.Properties == null)
            {
                return;
            }

            foreach (var schemaProperty in model.Properties)
            {
                var property = context.Type.GetProperty(schemaProperty.Key, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);

                if (property != null)
                {
                    var attr = property.GetCustomAttributes<ReadOnlyAttribute>(false).SingleOrDefault();
                    if (attr != null && attr.IsReadOnly)
                    {
                        // https://github.com/swagger-api/swagger-ui/issues/3445#issuecomment-339649576
                        if (schemaProperty.Value.Reference != null)
                        {
                            schemaProperty.Value.AllOf = new List<OpenApiSchema>()
                            {
                                new OpenApiSchema()
                                {
                                    Reference = schemaProperty.Value.Reference
                                }
                            };
                            schemaProperty.Value.Reference = null;
                        }

                        schemaProperty.Value.ReadOnly = true;
                    }
                }
            }
        }
    }
}