using dreamCare.FhirApi;
using dreamCare.ServiceDefaults;
using Serilog;


// Setup Serilog before building the FhirApi

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateBootstrapLogger();

Log.Information("Starting up Serilog!");


// Start building the FhirApi
try
{
    var builder = WebApplication.CreateBuilder(args);

    // Add service defaults so the Aspire project can track this APIClient.
    builder.AddServiceDefaults();

    // Add ApiServices with the configuration properties
    builder.Services.AddApiServices(builder.Configuration);

    var app = builder.Build();

    //// Configure the HTTP request pipeline.
    //app.UseHttpsRedirection();

    // Have an automatic exeception handler for testing
    app.UseExceptionHandler(options => { });

    if (app.Environment.IsDevelopment()) 
    {
        // Set the OpenApi Document endpoint within the development environment
        app.MapOpenApi();
        app.UseDeveloperExceptionPage();
    }
    
    // Enable authentication middleware
    app.UseAuthentication();
    app.UseAuthorization();

    // Map endpoints here

    // Run asyncronously to ensure all tasks are completed
    await app.RunAsync();

    Log.Information("Stopped cleanly");
    return 0; // Return with code 0
}
catch (Exception ex)
{
    Log.Fatal(ex, "An unhandled exception occurred while bootstrapping Serilog to the WebApi");
    return 1; // Return with code 1
}
finally
{
    Log.CloseAndFlush();
}


