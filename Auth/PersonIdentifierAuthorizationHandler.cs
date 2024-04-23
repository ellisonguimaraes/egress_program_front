using System.Security.Claims;
using EgressPortal.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;

namespace EgressPortal.Auth;

public class PersonIdentifierAuthorizationHandler : AuthorizationHandler<PersonIdentifierAuthorizationRequirement>
{
    private readonly NavigationManager _navigationManager;

    #region Constants
    private const string PERSON_ID_CLAIM_NAME = "personid";
    private const string COMPLETE_REGISTER_CLAIM_NAME = "hascompleteregister";
    #endregion

    public PersonIdentifierAuthorizationHandler(NavigationManager navigationManager)
    {
        _navigationManager = navigationManager;
    }

    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, PersonIdentifierAuthorizationRequirement requirement)
    {
        if (HasPersonIdentifierAndCompleteRegister(context.User))
            context.Succeed(requirement);
        else
            _navigationManager.NavigateTo(RouteSettings.CompleteRegisterRoute);

        return Task.CompletedTask;
    }

    private static bool HasPersonIdentifierAndCompleteRegister(ClaimsPrincipal principal)
        => principal.HasClaim(c => c.Type.Equals(PERSON_ID_CLAIM_NAME, StringComparison.OrdinalIgnoreCase) && !string.IsNullOrWhiteSpace(c.Value))
        && principal.HasClaim(c => c.Type.Equals(COMPLETE_REGISTER_CLAIM_NAME, StringComparison.OrdinalIgnoreCase) && bool.TryParse(c.Value, out var hasCompleteRegister) && hasCompleteRegister);
}