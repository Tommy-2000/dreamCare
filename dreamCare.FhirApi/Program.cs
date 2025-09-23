using dreamCare.FhirApi;
using dreamCare.FhirApi.Endpoints;
using dreamCare.ServiceDefaults;
using Serilog;
using Serilog.Events;
using Serilog.Templates;
using Serilog.Templates.Themes;


// Setup Serilog before building the FhirApi

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Override("Microsoft.AspNetCore.Hosting", LogEventLevel.Warning)
    .MinimumLevel.Override("Microsoft.AspNetCore.Mvc", LogEventLevel.Warning)
    .MinimumLevel.Override("Microsoft.AspNetCore.Routing", LogEventLevel.Warning)
    .WriteTo.Console()
    .CreateBootstrapLogger();

Log.Information("Starting up Serilog!");


// Start building the FhirApi
try
{
    var builder = WebApplication.CreateBuilder(args);

    // Add service defaults so the Aspire project can track this APIClient.
    builder.AddServiceDefaults();

    // Set Serilog as the logging provider
    builder.Host.UseSerilog((context, loggerConfig) =>
        loggerConfig.ReadFrom.Configuration(context.Configuration)
                .Enrich.FromLogContext()
                .WriteTo.Console(new ExpressionTemplate(
                    "[{@t:HH:mm:ss} {@l:u3}{#if @tr is not null} ({substring(@tr,0,4)}:{substring(@sp,0,4)}){#end}] {@m}\n{@x}",
                    theme: TemplateTheme.Code
                ))
    );

    // Add ApiServices with the configuration properties
    builder.Services.AddApiServices(builder.Configuration);

    var app = builder.Build();

    // Add Serilog logging middleware
    app.UseSerilogRequestLogging();

    //// Configure the HTTP request pipeline.
    //app.UseHttpsRedirection();

    // Have an automatic exeception handler for testing
    app.UseExceptionHandler(options => { });

    if (app.Environment.IsDevelopment())
    {
        app.UseDeveloperExceptionPage();
    }

    // Add CORS to allow for the Flutter Client to access the API
    app.UseCors("flutterClientAccess");


    //// Enable authentication middleware
    app.UseAuthentication();

    //// Enable authorization middleware
    app.UseAuthorization();

    // Map endpoints here
    app.MapConditionEndpoints();
    app.MapDiagnosticReportEndpoints();
    app.MapEncounterEndpoints();
    app.MapObservationEndpoints();
    app.MapPatientEndpoints();
    app.MapPractitionerEndpoints();

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


