using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Mvc.Controllers;
using Serilog;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc.Authorization;
using System.Collections.Generic;
using System;
using Microsoft.Extensions.Options;
using System.Reflection;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using System.Threading.Tasks;

namespace ServiceBlock.Internal
{
    class Startup
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
            var settings = section.Get<Options.ServiceBlock>() ?? new Options.ServiceBlock();
            services.Configure<Options.ServiceBlock>(section);

            services.AddMvc(o =>
            {
                o.Conventions.Add(new GenericControllerRouteConvention());

                if (settings.SecurityEnabled)
                    o.Filters.Add(new AuthorizeFilter());
            }).
            ConfigureApplicationPartManager(m =>
                m.FeatureProviders.Add(new GenericControllerFeatureProvider()
            ));

            services.AddHealthChecks();
            services.AddStorageServices();
            services.RunServiceRegistrators(Configuration);



            if (settings.SecurityEnabled)
            {
                services.AddAuthentication(options =>
               {
                   options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                   options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
               })
               .AddCookie()
               .AddOpenIdConnect(options =>
               {
                   options.Authority = "https://dev-nlzfjvrr.eu.auth0.com";
                   options.ClientId = settings?.Security?.ClientId;
                   options.ClientSecret = settings?.Security?.ClientSecret;
                   options.ResponseType = OpenIdConnectResponseType.Code;
                   options.GetClaimsFromUserInfoEndpoint = true;
                   options.Scope.Add("openid");
                   options.Scope.Add("profile");
                   //    options.SaveTokens = true;

                   options.Events = new OpenIdConnectEvents
                   {
                       OnRedirectToIdentityProvider = context =>
                       {
                           context.ProtocolMessage.SetParameter("audience", settings?.Security?.ApiIdentifier);

                           return Task.FromResult(0);
                       }
                   };
               });
            }

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = Assembly.GetEntryAssembly()?.GetName().Name ?? "ServiceBlock API", Version = "v1" });

                // Group actions by controller name
                c.TagActionsBy(api => new[]
                { (api.ActionDescriptor as ControllerActionDescriptor)?.ControllerTypeInfo.GetGenericArguments().SingleOrDefault()?.Name
                    ?? (api.ActionDescriptor as ControllerActionDescriptor)?.ControllerName
                });

                // Filter out readonly properties from write ops
                c.SchemaFilter<ReadOnlySchemaFilter>();

                // If security is enabled
                if (settings.SecurityEnabled)
                {
                    c.OperationFilter<SecurityRequirementsOperationFilter>();
                    c.OperationFilter<QueryParametersOperationFilter>();

                    c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                    {
                        Type = SecuritySchemeType.OAuth2,
                        Flows = new OpenApiOAuthFlows
                        {
                            Implicit = new OpenApiOAuthFlow
                            {
                                AuthorizationUrl = new Uri($"{settings?.Security?.Domain}authorize", UriKind.Absolute),
                                Scopes = settings?.Security?.Scopes.ToDictionary(k => k)
                            }
                        },

                    });
                }
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IOptionsMonitor<Options.ServiceBlock> settingsAccessor)
        {
            var settings = settingsAccessor.CurrentValue;
            var logger = app.ApplicationServices.GetService<ILogger<Startup>>();
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
                var apiName = Assembly.GetEntryAssembly()?.GetName().Name ?? "ServiceBlock API";
                c.SwaggerEndpoint("/swagger/v1/swagger.json", apiName);
                c.RoutePrefix = string.Empty;
                if (settings.SecurityEnabled)
                {
                    c.OAuthClientId(settings.Security?.ClientId);
                    c.OAuthClientSecret(settings.Security?.ClientSecret);
                    c.OAuthAppName(apiName);
                    c.OAuthAdditionalQueryStringParams(new Dictionary<string, string> {
                        {"audience", settings.Security?.ApiIdentifier ?? ""}
                    });
                }
            });

            app.UseRouting();

            if (settings.SecurityEnabled)
            {
                logger.LogInformation("Security enabled");
                app.UseAuthentication();
                app.UseAuthorization();
            }

            app.ApplicationServices.RunServiceWarmUp();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHealthChecks("/health");
            });
        }
    }
}
