using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.UserSecrets;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using ServiceBlock.Extensions;
using ServiceBlock.Interface;
using ServiceBlock.Interface.Storage;


namespace ServiceBlock.Messaging
{
    public class MessagingServiceRegistrator : IServiceConfiguration
    {
        public void Registrations(IServiceCollection services, IConfiguration config)
        {
            services.Scan(scan =>
                scan.FromApplicationDependencies()
                    .AddClasses(classes => classes.AssignableTo(typeof(ResourceEventListener<>)))
                    .AsSelf()
                    .WithSingletonLifetime()
            );

            services.TryAddSingleton<EventClient, Clients.RabbitMq>();

            var resourcesWithEvent = BlockInfo.ResourceTypes
            .Where(t => t.HasAttribute<EmitEventsAttribute>());

            foreach (var resource in resourcesWithEvent)
            {
                services.AddSingleton(typeof(ResourceEventPublisher<>).MakeGenericType(resource));
            }
        }

        public void WarmUp(IServiceProvider services)
        {
            services.GetService<EventClient>();
            foreach (var resource in BlockInfo.ResourceTypes.Where(t => t.HasAttribute<EmitEventsAttribute>()))
            {
                services.GetServices(typeof(ResourceEventPublisher<>).MakeGenericType(resource));
            }

            foreach (var listener in BlockInfo.BlockTypes.Where(t => t.IsSubclassOfRawGeneric(typeof(ResourceEventListener<>))))
            {
                services.GetServices(listener);
            }

        }
    }
}