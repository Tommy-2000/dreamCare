using dreamCare.FhirApi.Aidbox.HL7_Fhir_R4_Core;

namespace dreamCare.FhirApi.Endpoints;

public static class PractitionerEndpoints
{
    public static void MapPractitionerEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Practitioner").WithTags(nameof(Practitioner));

        group.MapGet("/", () =>
        {
            return new [] { new Practitioner() };
        })
        .WithName("GetAllPractitioners")
        .WithOpenApi();

        group.MapGet("/{id}", (int id) =>
        {
            //return new Practitioner { ID = id };
        })
        .WithName("GetPractitionerById")
        .WithOpenApi();

        group.MapPut("/{id}", (int id, Practitioner input) =>
        {
            return TypedResults.NoContent();
        })
        .WithName("UpdatePractitioner")
        .WithOpenApi();

        group.MapPost("/", (Practitioner model) =>
        {
            //return TypedResults.Created($"/api/Practitioners/{model.ID}", model);
        })
        .WithName("CreatePractitioner")
        .WithOpenApi();

        group.MapDelete("/{id}", (int id) =>
        {
            //return TypedResults.Ok(new Practitioner { ID = id });
        })
        .WithName("DeletePractitioner")
        .WithOpenApi();
    }
}
