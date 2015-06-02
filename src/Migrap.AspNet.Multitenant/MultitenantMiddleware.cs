using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Http;
using Microsoft.Framework.Logging;

namespace Migrap.AspNet.Multitenant {
    public class MultitenantMiddleware {
        private readonly RequestDelegate _next;
        private readonly ITenantProvider _tenantProvider;
        private readonly ILogger _logger;
        
        public MultitenantMiddleware(RequestDelegate next, ITenantProvider tenantProvider, ILoggerFactory loggerFactory) {
            _next = next;
            _tenantProvider = tenantProvider;
            _logger = loggerFactory.CreateLogger<MultitenantMiddleware>();
        }

        public async Task Invoke(HttpContext context) {
            using (_logger.BeginScope("MultitenantMiddleware")) {
                var tenant = await GetTenantAsync(context);

                _logger.LogInformation("Resolved tenant: {0}", tenant);

                context.Feature(x => x.Tenant, tenant);

                await _next(context);
            }
        }

        protected Task<ITenant> GetTenantAsync(HttpContext context) {
            return _tenantProvider.GetTenantAsync(context);
        }
    }
}