namespace Migrap.AspNet.Multitenant {
    internal partial class Tenant : ITenant {
        internal Tenant(string name) {
            Name = name;
        }

        public string Name { get; }
    }
}