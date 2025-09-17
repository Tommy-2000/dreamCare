using Microsoft.AspNetCore.Authorization;

namespace dreamCare.FhirApi.Security;

public class FhirAuthScopeRequirement(string issuer, string scope) : IAuthorizationRequirement
{
    public string AuthIssuer { get; } = issuer ?? throw new ArgumentNullException(nameof(issuer));
    public string AuthScope { get; } = scope ?? throw new ArgumentNullException(nameof(scope));
}