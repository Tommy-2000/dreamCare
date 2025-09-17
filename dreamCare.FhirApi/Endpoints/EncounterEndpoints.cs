using dreamCare.FhirApi.Aidbox.HL7_Fhir_R4_Core;

namespace dreamCare.FhirApi.Endpoints;

public static class EncounterEndpoints
{
    public static void MapEncounterEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Encounter").WithTags(nameof(Encounter));

        group.MapGet("/", () =>
        {
            //return new [] { new Encounter() };
        })
        .WithName("GetAllEncounters")
        .WithOpenApi();

        group.MapGet("/{id}", (int id) =>
        {
            //return new Encounter { ID = id };
        })
        .WithName("GetEncounterById")
        .WithOpenApi();

        group.MapPut("/{id}", (int id, Encounter input) =>
        {
            return TypedResults.NoContent();
        })
        .WithName("UpdateEncounter")
        .WithOpenApi();

        group.MapPost("/", (Encounter model) =>
        {
            //return TypedResults.Created($"/api/Encounters/{model.ID}", model);
        })
        .WithName("CreateEncounter")
        .WithOpenApi();

        group.MapDelete("/{id}", (int id) =>
        {
            //return TypedResults.Ok(new Encounter { ID = id });
        })
        .WithName("DeleteEncounter")
        .WithOpenApi();
    }
}
