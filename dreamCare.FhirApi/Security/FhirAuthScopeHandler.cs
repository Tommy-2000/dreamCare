using Microsoft.AspNetCore.Authorization;

namespace dreamCare.FhirApi.Security;

public class FhirAuthScopeHandler : AuthorizationHandler<FhirAuthScopeRequirement>
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext authContext, FhirAuthScopeRequirement authRequirement)
    {
        if (!authContext.User.HasClaim(c => c.Type == "scope" && c.Issuer == authRequirement.AuthIssuer))
        {
            return Task.CompletedTask;
        }

        var authScopes = authContext.User
            .FindFirst(c => c.Type == "scope" && c.Issuer == authRequirement.AuthIssuer)
            ?.Value.Split(' ');

        if (authScopes != null && authScopes.Any(s => s == authRequirement.AuthScope))
        {
            authContext.Succeed(authRequirement);
        }
        
        return Task.CompletedTask;
    }
}