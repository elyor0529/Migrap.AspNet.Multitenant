using System;
using Microsoft.AspNet.Http;
using Migrap.AspNet.Multitenant.Features;

namespace Migrap.AspNet.Multitenant {
    public static class HttpContextExtensions {
        public static ITenantFeature Feature(this HttpContext context, Func<HttpContext, Func<Type>> feature) {
            return (ITenantFeature)context.Features[feature(context)()];
        }

        public static void Feature(this HttpContext context, Func<HttpContext, Func<Type>> feature, ITenantFeature instance) {
            context.Features[feature(context)()] = instance;
        }

        public static void Feature(this HttpContext context, Func<HttpContext, Func<Type>> feature, ITenant tenant) {
            context.Features[feature(context)()] = new TenantFeature(tenant);;
        }

        public static Type Tenant(this HttpContext context) {
            return typeof(ITenantFeature);
        }
    }    
}