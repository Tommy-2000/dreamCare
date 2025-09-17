namespace dreamCare.FhirApi.Security;

public class FhirAuthHandler : HttpClientHandler
{
    public System.Net.Http.Headers.AuthenticationHeaderValue AuthorisationHeader { get; set; }
    
    protected async override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        // If the header is not null, set the authorisation header
        if (AuthorisationHeader != null)
            request.Headers.Authorization = AuthorisationHeader;
        return await base.SendAsync(request, cancellationToken);
    }
}