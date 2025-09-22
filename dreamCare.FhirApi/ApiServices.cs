using dreamCare.FhirApi.Exceptions;
using dreamCare.FhirApi.Security;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using Serilog.Templates;
using Serilog.Templates.Themes;
using System.Security.Claims;

namespace dreamCare.FhirApi
{
    public static class ApiServices
    {
        public static IServiceCollection AddApiServices(this IServiceCollection apiServices, IConfiguration apiConfig)
        {
            // Configure Aidbox headers and token validation
            apiServices.AddOptions<AidboxClient>()
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

            // Add Serilog logging to the FhirApi
            apiServices.AddSerilog((services, lc) => lc.ReadFrom.Configuration(apiConfig)
                .ReadFrom.Services(services)
                .Enrich.FromLogContext()
                .WriteTo.Console(new ExpressionTemplate(
                    "[{@t:HH:mm:ss} {@l:u3}{#if @tr is not null} ({substring(@tr,0,4)}:{substring(@sp,0,4)}){#end}] {@m}\n{@x}",
                    theme: TemplateTheme.Code
                )));

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
    }
}