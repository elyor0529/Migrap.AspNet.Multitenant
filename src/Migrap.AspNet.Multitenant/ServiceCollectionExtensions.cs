using System;
using System.Reflection;
using Microsoft.Framework.DependencyInjection;

namespace Migrap.AspNet.Multitenant {
    public static class ServiceCollectionExtensions {
        public static IServiceCollection AddMultitenant(this IServiceCollection services) {
            services.AddMultitenant(x => x.Default);

            return services;
        }

        public static IServiceCollection AddMultitenant(this IServiceCollection services, Func<ITenantProviderExtension, Func<TypeInfo>> provider) {
            var descriptor = new ServiceDescriptor(typeof(ITenantProvider), provider(null)().AsType(), ServiceLifetime.Scoped);

            services.TryAdd(descriptor);

            return services;
        }        
    }
}