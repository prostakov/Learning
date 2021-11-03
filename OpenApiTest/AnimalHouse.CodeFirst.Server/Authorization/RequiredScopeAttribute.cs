using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AnimalHouse.CodeFirst.Server.Authorization
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = false, AllowMultiple = false)]
    public class RequiredScopeAttribute : TypeFilterAttribute
    {
        public RequiredScopeAttribute(params string[] allowedScopes) : base(typeof(RequiredScopeFilter))
        {
            Arguments = new[] {allowedScopes};
        }
    }

    public class RequiredScopeFilter : IAuthorizationFilter
    {
        private static readonly IEnumerable<string> _scopeClaimTypes = new HashSet<string>(StringComparer.OrdinalIgnoreCase) {
            "http://schemas.microsoft.com/identity/claims/scope",
            "scope",
            "scp"
        };
        
        private readonly string[] _allowedScopes;

        public RequiredScopeFilter(string[] allowedScopes)
        {
            _allowedScopes = allowedScopes;
        }
        
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var scopeClaim = context.HttpContext.User.Claims.FirstOrDefault(x => _scopeClaimTypes.Contains(x.Type));
            
            if (scopeClaim == null) 
                context.Result = new ForbidResult();

            var scopes = scopeClaim!.Value.Split(' ');
            
            if (_allowedScopes.Any(x => !scopes.Contains(x, StringComparer.OrdinalIgnoreCase)))
                context.Result = new ForbidResult();
        }
    }
}