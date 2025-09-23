
var appBuilder = DistributedApplication.CreateBuilder(args);


// Add the FhirApi that interacts with Fhir data from the Aidbox test server
var fhirApi = appBuilder.AddProject<Projects.dreamCare_FHIRApi>("fhirApi");

appBuilder.Build().Run();
