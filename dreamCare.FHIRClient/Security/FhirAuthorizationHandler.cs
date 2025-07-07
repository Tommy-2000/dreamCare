namespace dreamCare.FHIRClient.Security;

public class FhirAuthorizationHandler : HttpClientHandler
{
    public System.Net.Http.Headers.AuthenticationHeaderValue AuthorisationHeader { get; set; }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        // If the header is not null, set the authorisation header
        request.Headers.Authorization = AuthorisationHeader;
        return await base.SendAsync(request, cancellationToken);
    }
}