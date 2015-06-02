using System;

namespace Migrap.AspNet.Multitenant {
    public static class TenantExtensions {
        public static ITenant ThrowIfNull(this ITenant tenant) {
            if(tenant == null) {
                throw new TenantNotFoundException();
            }

            return tenant;
        }

        public static bool Equals<TTenant>(this TTenant tenant, TTenant value, params Func<TTenant, object>[] selectors) where TTenant : ITenant {
            foreach(var selector in selectors) {
                var x = selector(tenant);
                var y = selector(value);

                if(false == x.Equals(y)) {
                    return false;
                }
            }

            return true;
        }
    }
}