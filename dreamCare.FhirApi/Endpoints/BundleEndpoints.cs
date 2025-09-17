using dreamCare.FhirApi.Aidbox.HL7_Fhir_R4_Core;

namespace dreamCare.FhirApi.Endpoints;

public static class BundleEndpoints
{
    public static void MapBundleEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Bundle").WithTags(nameof(Bundle));

        group.MapGet("/", () =>
        {
            return new [] { new Bundle.BundleEntry() };
        })
        .WithName("GetAllBundles")
        .WithOpenApi();

        group.MapGet("/{id}", (int id) =>
        {
            //return new Bundle { ID = id };
        })
        .WithName("GetBundleById")
        .WithOpenApi();

        group.MapPut("/{id}", (int id, Bundle input) =>
        {
            return TypedResults.NoContent();
        })
        .WithName("UpdateBundle")
        .WithOpenApi();

        group.MapPost("/", (Bundle model) =>
        {
            //return TypedResults.Created($"/api/Bundles/{model.ID}", model);
        })
        .WithName("CreateBundle")
        .WithOpenApi();

        group.MapDelete("/{id}", (int id) =>
        {
            //return TypedResults.Ok(new Bundle { ID = id });
        })
        .WithName("DeleteBundle")
        .WithOpenApi();
    }
}
