using dreamCare.FhirApi.Exceptions;
using dreamCare.FhirApi.Security;
using Hl7.Fhir.Rest;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using System.Security.Claims;

namespace dreamCare.FhirApi
{
    public static class ApiServices
    {

        public static IServiceCollection AddApiServices(this IServiceCollection apiServices, IConfiguration apiConfig)
        {
            // Configure Aidbox headers and token validation
            apiServices.AddOptions<FhirClient>()
                .ValidateDataAnnotations()
                .ValidateOnStart();

            // Configure the routing to use lower case
            apiServices.Configure<RouteOptions>(options =>
            {
                options.LowercaseUrls = true;
                options.LowercaseQueryStrings = true;
            });

            // Add OpenAPI documentation to FhirApi
            apiServices.AddOpenApi();

            // Add services that catch failed requests
            apiServices.AddProblemDetails();

            // Add JWT Token Authentication from Auth0

            // Define the domain from Auth0
            var auth0Domain = $"https://{apiConfig["Auth0_Authority"]}/";
            apiServices.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.Authority = auth0Domain;
                    options.Audience = apiConfig["Auth0_Audience"];
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        NameClaimType = ClaimTypes.NameIdentifier
                    };
                });

            // Add Authorization with permissions set by Auth0
            apiServices.AddAuthorization(options =>
            {
                // Patient permissions
                options.AddPolicy("read:patients",
                    policy => policy.Requirements.Add(
                        new FhirAuthScopeRequirement("read:patients", auth0Domain)));
                options.AddPolicy("write:patients",
                    policy => policy.Requirements.Add(
                        new FhirAuthScopeRequirement("write:patients", auth0Domain)));
                // DiagnositcReport permissions
                options.AddPolicy("read:diagnosticreports",
                    policy => policy.Requirements.Add(
                        new FhirAuthScopeRequirement("read:diagnosticreports", auth0Domain)));
                options.AddPolicy("write:diagnosticreports",
                    policy => policy.Requirements.Add(
                        new FhirAuthScopeRequirement("write:diagnosticreports", auth0Domain)));
            });


            // Add AuthorisationHandler to a singleton with the fhirAuthScopeHandler
            apiServices.AddSingleton<IAuthorizationHandler, FhirAuthScopeHandler>();


            // Add FhirClient as a HttpClient
            apiServices.AddHttpClient<FhirClient>();

            // Add support for Cors when connecting this project to the Flutter client
            apiServices.AddCors(option =>
            {
                option.AddPolicy(
                    "flutterClientAccess", builder => { builder.WithOrigins("http://locahost:8080").AllowAnyMethod().AllowAnyHeader().AllowCredentials(); });
            });

            // Add ExceptionHandler
            apiServices.AddExceptionHandler<GlobalExceptionHandler>();

            // Add Endpoints with an EndpointsApiExplorer
            apiServices.AddEndpointsApiExplorer();


            // Return configured ApiServices
            return apiServices;
        }

        public static FhirClient GetFhirClient(IConfiguration config)
        {
            var aidboxClientUrl = config["Aidbox_Client_Url"];

            if (aidboxClientUrl != null)
            {
                // Configure logging message handlers for FHIRClient
                var loggingHandler = new FhirLoggingHandler(Log.Logger);

                var aidBoxClientUri = new Uri(aidboxClientUrl);

                var fhirClient = new FhirClient(aidBoxClientUri, new FhirClientSettings
                {
                    PreferredFormat = ResourceFormat.Json,
                    UseAsync = true,
                    VerifyFhirVersion = true
                }, loggingHandler);

                return fhirClient;
            }
            else
            {
                throw new InvalidOperationException("Aidbox Client Config is null, please add necessary parameters to secrets.json");
            }
        }

    }
}