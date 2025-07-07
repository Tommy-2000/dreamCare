using dreamCare.ServiceDefaults;
using dreamCare.FHIRClient;
using dreamCare.FHIRClient.Endpoints;
using Hl7.Fhir.Rest;
using Hl7.Fhir.Specification;
using Hl7.Fhir.Model;

var builder = WebApplication.CreateBuilder(args);

// Add service defaults so the Aspire project can track this APIClient.
builder.AddServiceDefaults();

// Add services to the container.
builder.Services.AddProblemDetails();

// Add ApiServices with the configuration properties
builder.Services.AddApiServices(builder.Configuration);

var app = builder.Build();

//// Configure the HTTP request pipeline.
//app.UseHttpsRedirection();

// Have an automatic exeception handler for testing
app.UseExceptionHandler(options => { });

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}


app.MapPatientEndpoints();

app.MapPractitionerEndpoints();

app.MapEncounterEndpoints();

app.MapObservationEndpoints();

app.MapConditionEndpoints();


app.Run();

