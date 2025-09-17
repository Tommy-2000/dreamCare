using dreamCare.FhirApi.Aidbox.HL7_Fhir_R4_Core;

namespace dreamCare.FhirApi.Endpoints;

public static class ObservationEndpoints
{
    public static void MapObservationEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Observation").WithTags(nameof(Observation));

        group.MapGet("/", () =>
        {
            //return new [] { new Observation() };
        })
        .WithName("GetAllObservations")
        .WithOpenApi();

        group.MapGet("/{id}", (int id) =>
        {
            //return new Observation { ID = id };
        })
        .WithName("GetObservationById")
        .WithOpenApi();

        group.MapPut("/{id}", (int id, Observation input) =>
        {
            return TypedResults.NoContent();
        })
        .WithName("UpdateObservation")
        .WithOpenApi();

        group.MapPost("/", (Observation model) =>
        {
            //return TypedResults.Created($"/api/Observations/{model.ID}", model);
        })
        .WithName("CreateObservation")
        .WithOpenApi();

        group.MapDelete("/{id}", (int id) =>
        {
            //return TypedResults.Ok(new Observation { ID = id });
        })
        .WithName("DeleteObservation")
        .WithOpenApi();
    }
}
