using dreamCare.FHIRClient.Exceptions;

namespace dreamCare.FHIRClient
{
    public static class ApiServices
    {

        public static IServiceCollection AddApiServices(this IServiceCollection apiServices, IConfiguration configuration)
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

            //apiServices.AddHealthChecks().AddDbContextCheck<ApiDbContext>();

            apiServices.AddExceptionHandler<GlobalExceptionHandler>();

            apiServices.AddEndpointsApiExplorer();


            // Add support for Swagger when interfacing with the API in development mode
            //apiServices.AddSwaggerGen(swaggerOptions =>
            //{
            //    swaggerOptions.SwaggerDoc("v1", new OpenApiInfo { Title = "dreamCare POC API", Version = "v1" });

            //    //swaggerOptions.OperationFilter<SecurityRequirementsFilter>(); // Use a filter when securing Swagger Api operations
            //    //swaggerOptions.EnableAnnotations();
            //    swaggerOptions.DescribeAllParametersInCamelCase();

            //    swaggerOptions.AddSecurityDefinition(
            //        "bearerAuth",
            //        new OpenApiSecurityScheme
            //        {
            //            Type = SecuritySchemeType.Http,
            //            Scheme = "bearer",
            //            BearerFormat = "JWT",
            //            Description = "JWT Authorization header using the Bearer scheme.",
            //        }
            //    );
            //});


            // Add support for Cross-Origin Resource Sharing -- REMOVE BEFORE PRODUCTION AND CONFIGURE HTTP DOMAINS AND METHODS!
            apiServices.AddCors(option =>
            {
                option.AddPolicy(
                    "development",
                    builder =>
                    {
                        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                    });
            });


            apiServices.AddOpenApi();


            // Add endpoints for client services
            


            // Return configured ApiServices
            return apiServices;

        }
    }
}
