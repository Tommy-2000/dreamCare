namespace dreamCare.FhirApi.Security;

public class FhirLoggingHandler : DelegatingHandler
{

    private readonly ILogger _fhirLogger;

    public FhirLoggingHandler(ILogger fhirLogger)
    {
        _fhirLogger = fhirLogger;
    }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        _fhirLogger.LogTrace("Request: " + request);

        try
        {
            var fhirResponse = await base.SendAsync(request, cancellationToken);
            _fhirLogger.LogTrace("Response: " + request);
            return fhirResponse;
        }
        catch (Exception ex)
        {
            _fhirLogger.LogError("Failed to retrieve response: " + ex);
            throw;
        }
        
    }
}