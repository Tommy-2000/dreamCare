using dreamCare.ApiService;
using dreamCare.MigrationService;
using dreamCare.ServiceDefaults;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<ApiDbWorker>();

// Add Aspire support to add this as a background worker in AppHost
builder.AddServiceDefaults();

builder.Services.AddOpenTelemetry().WithTracing(tracing => tracing.AddSource(ApiDbWorker.ActivitySourceName));


var backgroundService = builder.Build();
backgroundService.Run();
