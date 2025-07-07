namespace dreamCare.FHIRClient.Security;

public class FhirLoggingHandler(ILogger fhirLogger) : DelegatingHandler
{
    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        fhirLogger.LogTrace("Request: " + request);

        try
        {
            var fhirResponse = await base.SendAsync(request, cancellationToken);
            fhirLogger.LogTrace("Response: " + request);
            return fhirResponse;
        }
        catch (Exception ex)
        {
            fhirLogger.LogError("Failed to retrieve response: " + ex);
            throw;
        }
        
    }
}