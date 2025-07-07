
var appBuilder = DistributedApplication.CreateBuilder(args);


// Connect to existing Azure resources
//var dreamcareFHIRName = appBuilder.AddParameter("dreamcare-fhir");
//var dreamcareDICOMName = appBuilder.AddParameter("dreamcare-dicom");
//var dreamcareResourceGroup = appBuilder.AddParameter("dreamcare-resource-group");

// Add the FhirClient that interacts with Fhir data from the Aidbox test server
appBuilder.AddProject<Projects.dreamCare_FHIRClient>("fhirClient");

// Add the DICOMClient that interacts with DICOM data from the DICOM test server
//appBuilder.AddProject<Projects.dreamCare_DICOMClient>("dicomClient");



appBuilder.Build().Run();
