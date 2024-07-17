using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;

namespace EgressPortal.Auth;

public class AdminAuthorizationHandler : AuthorizationHandler<AdminAuthorizationRequirement>
{
    private const string ADMIN_ROLE_CLAIM_VALUE = "ADM";
    
    private readonly NavigationManager _navigationManager;
    
    public AdminAuthorizationHandler(NavigationManager navigationManager)
    {
        _navigationManager = navigationManager;
    }
    
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, AdminAuthorizationRequirement requirement)
    {
        if (IsAdmin(context.User))
            context.Succeed(requirement);
        
        return Task.CompletedTask;
    }

    private static bool IsAdmin(ClaimsPrincipal principal) =>
        principal.HasClaim(c =>
            c.Type.Equals(ClaimTypes.Role) &&
            c.Value.Equals(ADMIN_ROLE_CLAIM_VALUE, StringComparison.OrdinalIgnoreCase));
}