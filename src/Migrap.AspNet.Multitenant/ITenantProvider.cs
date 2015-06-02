using System.Threading.Tasks;
using Microsoft.AspNet.Http;

namespace Migrap.AspNet.Multitenant {
    public interface ITenantProvider {
        Task<ITenant> GetTenantAsync(HttpContext context);
    }    
}