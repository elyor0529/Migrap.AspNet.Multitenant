namespace Migrap.AspNet.Multitenant.Features {
    public class TenantFeature : ITenantFeature {
        public TenantFeature(ITenant tenant) {
            Tenant = tenant;
        }

        public ITenant Tenant { get; }        
    }
}