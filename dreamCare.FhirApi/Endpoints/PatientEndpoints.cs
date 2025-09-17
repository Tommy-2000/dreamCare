using dreamCare.FhirApi.Aidbox.HL7_Fhir_R4_Core;

namespace dreamCare.FhirApi.Endpoints;

public static class PatientEndpoints
{
    public static void MapPatientEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Patient").WithTags(nameof(Patient));

        group.MapGet("/", () =>
        {
            return new [] { new Patient() };
        })
        .WithName("GetAllPatients")
        .WithOpenApi();

        group.MapGet("/{id}", (int id) =>
        {
            //return new Patient { ID = id };
        })
        .WithName("GetPatientById")
        .WithOpenApi();

        group.MapPut("/{id}", (int id, Patient input) =>
        {
            return TypedResults.NoContent();
        })
        .WithName("UpdatePatient")
        .WithOpenApi();

        group.MapPost("/", (Patient model) =>
        {
            //return TypedResults.Created($"/api/Patients/{model.ID}", model);
        })
        .WithName("CreatePatient")
        .WithOpenApi();

        group.MapDelete("/{id}", (int id) =>
        {
            //return TypedResults.Ok(new Patient { ID = id });
        })
        .WithName("DeletePatient")
        .WithOpenApi();
    }
}
