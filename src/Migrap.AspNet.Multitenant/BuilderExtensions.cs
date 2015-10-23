using Microsoft.AspNet.Builder;

namespace Migrap.AspNet.Multitenant {
    public static class BuilderExtensions {
        public static IApplicationBuilder UseMultitenant(this IApplicationBuilder builder) {
            return builder.UseMiddleware<MultitenantMiddleware>();            
        }

#if OPTIONS
        private static IApplicationBuilder UseMultitenant(this IApplicationBuilder builder, Action<MultitenantOptions> configureOptions = null, string optionsName = "") {
            return builder.UseMiddleware<MultitenantMiddleware>(new ConfigureOptions<MultitenantOptions>(configureOptions ?? (o => { })) {
                Name = optionsName
            });
        }
#endif
    }
}