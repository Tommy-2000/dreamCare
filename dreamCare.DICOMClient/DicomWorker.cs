using Microsoft.AspNetCore.Http.Features;

namespace dreamCare.DICOMClient;

public class DicomWorker : IWebHost
{
    public void Dispose()
    {
        throw new NotImplementedException();
    }

    public void Start()
    {
        throw new NotImplementedException();
    }

    public async Task StartAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        throw new NotImplementedException();
    }

    public async Task StopAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        throw new NotImplementedException();
    }

    public IFeatureCollection ServerFeatures { get; }
    public IServiceProvider Services { get; }
}