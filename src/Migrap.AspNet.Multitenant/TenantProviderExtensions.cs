using System.Reflection;

namespace Migrap.AspNet.Multitenant {
    public static class TenantProviderExtensions {
        public static TypeInfo Default(this ITenantProviderExtension extension) {
            return typeof(DefaultTenantProvider).GetTypeInfo();
        }
    }
}