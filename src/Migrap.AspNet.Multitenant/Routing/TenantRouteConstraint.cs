using Microsoft.AspNet.Http;
using Microsoft.AspNet.Routing;
using Migrap.AspNet.Multitenant;
using System;
using System.Collections.Generic;

namespace Migrap.AspNet.Routing {
    public class TenantRouteConstraint : IRouteConstraint {
        public const string TenantKey = "tenant";
        private readonly ISet<string> _tenants = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        private readonly ITenantService _tenantService;

        public TenantRouteConstraint(ITenantService tenantService) {
            _tenantService = tenantService;
        }

        public bool Match(HttpContext httpContext, IRouter route, string routeKey, IDictionary<string, object> values, RouteDirection routeDirection) {
            var address = httpContext.Request.Headers["Host"][0].Split('.');

            if(address.Length < 2) {
                return false;
            }

            var tenant = address[0];

            if(!values.ContainsKey("tenant")) {
                values.Add("tenant", tenant);
            }

            return true;
        }
    }    
}