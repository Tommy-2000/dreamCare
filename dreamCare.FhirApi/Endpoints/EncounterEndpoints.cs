
using dreamCare.FhirApi.FhirServices;
using Hl7.Fhir.Model;

namespace dreamCare.FhirApi.Endpoints;

public static class EncounterEndpoints
{
    public static void MapEncounterEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/fhir/Encounter").WithTags(nameof(Encounter));

        group.MapGet("/{id}", (Id encounterId, Encounter inputEncounter, EncounterFhirService encounterFhirService) =>
        {
            var returnedEncounter = encounterFhirService.GetEncounterById(encounterId);
            return TypedResults.Ok(returnedEncounter);
        })
        .WithName("GetEncounterById")
        .WithOpenApi();

        group.MapPut("/{id}", (Id encounterId, Encounter inputEncounter, EncounterFhirService encounterFhirService) =>
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
