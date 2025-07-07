using dreamCare.DICOMClient;
using dreamCare.ServiceDefaults;
using FellowOakDicom;

var builder = WebApplication.CreateBuilder(args);

// Add service defaults & Aspire components.
builder.AddServiceDefaults();
// Add services to the container.
builder.Services.AddProblemDetails();

// Add ApiServices with the configuration properties
builder.Services.AddApiServices(builder.Configuration);

// Add DICOM support through fo-dicom package
builder.Services.AddFellowOakDicom();

builder.Services.AddOpenApi();

// Connect to existing Azure Blob Storage instance
builder.AddAzureBlobContainerClient("dreamcare-dicom");

var app = builder.Build();

// This is still necessary for now until fo-dicom has first-class AspNetCore integration
DicomSetupBuilder.UseServiceProvider(app.Services);

//// Configure the HTTP request pipeline.
//app.UseHttpsRedirection();

// Have an automatic exeception handler for testing
app.UseExceptionHandler(options => { });

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.MapDefaultEndpoints();

app.Run();

