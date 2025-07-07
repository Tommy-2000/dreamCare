using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace dreamCare.ApiService.Security
{
    public class SecurityRequirementsFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            throw new NotImplementedException();
        }
    }
}