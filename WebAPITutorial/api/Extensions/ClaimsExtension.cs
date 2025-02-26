using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace api.Extensions
{
    public static class ClaimsExtension
    {
        public static string GetUsername(this ClaimsPrincipal claims)
        {
            return claims.Claims.SingleOrDefault(c => c.Type.Equals(ClaimTypes.GivenName))!.Value;
        }
    }
}