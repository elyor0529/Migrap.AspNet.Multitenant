using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Http;

namespace Migrap.AspNet.Multitenant {
    public class DefaultTenantProvider : ITenantProvider {
        public Task<ITenant> GetTenantAsync(HttpContext context) {
            var tenant = (ITenant)null;
            var identity = context.User.Identity as ClaimsIdentity;
            var domain = identity?.Name?.Split(new char[] { '@' }, 2)?.LastOrDefault();

            if(domain != null) {
                tenant = new Tenant(domain);
            }

            return Task.FromResult(tenant);
        }
    }
}