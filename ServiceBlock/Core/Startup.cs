using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Mvc.Controllers;
using ServiceBlock.Extensions;
using Serilog;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc.Authorization;

namespace ServiceBlock.Core
{
    public class Startup
    {

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.Configure<ConsoleLifetimeOptions>(options => options.SuppressStatusMessages = true);
            var section = Configuration.GetSection(nameof(ServiceBlock));
            var settings = section.Get<Options.ServiceBlock>();
            services.Configure<Options.ServiceBlock>(section);

            services.AddMvc(o =>
            {
                o.Conventions.Add(new GenericControllerRouteConvention());

                if (settings?.Security != null)
                    o.Filters.Add(new AuthorizeFilter());
            }).
            ConfigureApplicationPartManager(m =>
                m.FeatureProviders.Add(new GenericControllerFeatureProvider()
            ));

            services.AddHealthChecks();


            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(options =>
            {
                options.Authority = settings?.Security?.Domain;
                options.Audience = settings?.Security?.ApiIdentifier;
            });



            services.AddResourceEventListeners();
            services.AddStorageServices();

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
                c.TagActionsBy(api => new[]
                { (api.ActionDescriptor as ControllerActionDescriptor)?.ControllerTypeInfo.GetGenericArguments().SingleOrDefault()?.Name
                    ?? (api.ActionDescriptor as ControllerActionDescriptor)?.ControllerName
});
                c.SchemaFilter<ReadOnlySchemaFilter>();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseSerilogRequestLogging();

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = string.Empty;
            });

            app.UseRouting();


            app.UseAuthentication();
            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHealthChecks("/health");
            });
        }
    }
}
