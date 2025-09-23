namespace dreamCare.FhirApi.Security;

public class FhirLoggingHandler : DelegatingHandler
{

    private readonly Serilog.ILogger _fhirLogger;

    public FhirLoggingHandler(Serilog.ILogger fhirLogger)
    {
        _fhirLogger = fhirLogger;
    }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        _fhirLogger.Information("Request: " + request);

        try
        {
            var fhirResponse = await base.SendAsync(request, cancellationToken);
            _fhirLogger.Information("Response: " + request);
            return fhirResponse;
        }
        catch (Exception ex)
        {
            _fhirLogger.Error("Failed to retrieve response: " + ex);
            throw;
        }
        
    }
}