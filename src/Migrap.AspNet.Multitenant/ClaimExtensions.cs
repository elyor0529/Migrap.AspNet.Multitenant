using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace Migrap.AspNet.Multitenant {
    public static class ClaimExtensions {
        public static string Tenant(this IEnumerable<Claim> claims) {
            return nameof(Tenant).ToLower();
        }

        internal static void AddClaim(this ClaimsIdentity identity, Func<IEnumerable<Claim>, Func<string>> type, string value) {
            identity.AddClaim(type(identity.Claims)(), value);
        }

        internal static void AddClaim(this ClaimsIdentity identity, string type, string value) {
            identity.AddClaim(new Claim(type, value));
        }
    }
}