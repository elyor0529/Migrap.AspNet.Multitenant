namespace Migrap.AspNet.Multitenant.Features {
    public interface ITenantFeature {
        ITenant Tenant { get; }
    }
}