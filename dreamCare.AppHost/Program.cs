var builder = DistributedApplication.CreateBuilder(args);


// Connect to existing Azure resources
var dreamcareCosmosName = builder.AddParameter("dreamcare-cosmos");
var dreamcareResourceGroup = builder.AddParameter("dreamcare-resource-group");

// Add the connection to the Cosmos Db resource using the parameters
var cosmosService = builder.AddAzureCosmosDB("dreamcare-cosmos")
    .AsExisting(dreamcareCosmosName, dreamcareResourceGroup);

//var migrationService = builder.AddProject<Projects.dreamCare_MigrationService>("migrationservice")
//    .WithReference(sqlDb)
//    .WaitFor(sqlDb); // Wait for the backup database to build first before launching migrations

// Configure KeyCloak IAM for authentication with a username and password
//var kcUsername = appBuilder.AddParameter("dreamcare-user", secret: true);
//var kcPassword = appBuilder.AddParameter("dreamcare-pass", secret: true);
//var keycloakService = appBuilder.AddKeycloak("dreamcare-keycloak", 8080, kcUsername, kcPassword);

var apiService = builder.AddProject<Projects.dreamCare_ApiService>("apiservice")
    .WithReference(cosmosService)
    .WaitFor(cosmosService); 

builder.AddProject<Projects.dreamCare_WebApp>("webapp")
    .WithExternalHttpEndpoints()
    .WithReference(apiService);

// The Web and MAUI Apps can continue building without fully depending on the ApiService

// MAUI projects are registered differently than other project types, with AddMobileProject. Aspire settings
// that are normally set as environment variables at launch time are in the case of MAUI instead generated
// in the specified MAUI app project directory, in the AspireAppSettings.g.cs file.
builder.AddMobileProject("mauiapp", "../dreamCare.MAUIApp")
    .WithReference(apiService);

builder.Build().Run();
