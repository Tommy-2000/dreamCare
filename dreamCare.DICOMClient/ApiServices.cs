using dreamCare.DICOMClient.Exceptions;

namespace dreamCare.DICOMClient
{
    public static class ApiServices
    {
        public static IServiceCollection AddApiServices(this IServiceCollection apiServices, IConfiguration configuration)
        {
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


            // Add support for Cross-Origin Resource Sharing
            // Use this when testing with the Flutter front-end
            // REMOVE BEFORE DEPLOYING TO PRODUCTION!
            apiServices.AddCors(option =>
            {
                option.AddPolicy(
                    "development",
                    builder =>
                    {
                        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                    });
            });


            // Return configured ApiServices
            return apiServices;

        }
    }
}
