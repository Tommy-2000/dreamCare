using System.Net;
using System.Net.Sockets;

namespace dreamCare.FhirApi.Security;

public class FhirRetryHandler : DelegatingHandler
{
    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        while (true)
        {
            try
            {
                var fhirResponse = await base.SendAsync(request, cancellationToken);
                if (fhirResponse.StatusCode == HttpStatusCode.ServiceUnavailable)
                {
                    await Task.Delay(5000, cancellationToken);
                    continue;
                }

                if (fhirResponse.StatusCode == HttpStatusCode.TooManyRequests)
                {
                    await Task.Delay(5000, cancellationToken);
                    continue;
                }

                return fhirResponse;
            }
            catch (Exception ex) when (IsNetworkError(ex))
            {
                Console.WriteLine(ex);
                throw;
            }
        }
    }

    private static bool IsNetworkError(Exception ex)
    {
        if (ex is SocketException)
            return true;
        if (ex.InnerException != null)
            return IsNetworkError(ex.InnerException);
        return false;
    }
}