using dreamCare.FhirApi.FhirServices;
using Hl7.Fhir.Model;

namespace dreamCare.FhirApi.Endpoints;

public static class PatientEndpoints
{

    public static void MapPatientEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/fhir/Patient").WithTags(nameof(Patient));

        group.MapGet("/{id}", (Id patientId, PatientFhirService patientFhirService) =>
        {
            var returnedPatient = patientFhirService.GetPatientById(patientId);
            return TypedResults.Ok(returnedPatient);
        })
        .WithName("GetPatientById")
        .WithOpenApi();

        group.MapPut("/{id}", (Id patientId, Patient inputPatient, PatientFhirService patientFhirService) =>
        {
            var returnedPatient = patientFhirService.UpdatePatient(inputPatient);
            return TypedResults.Ok(returnedPatient);
        })
        .WithName("UpdatePatientById")
        .WithOpenApi();

        group.MapPost("/", (Patient inputPatient, PatientFhirService patientFhirService) =>
        {
            var returnedPatient = patientFhirService.CreatePatient(inputPatient);
            return TypedResults.Created($"/fhir/Patient/{returnedPatient.Id}", returnedPatient);
        })
        .WithName("CreatePatient")
        .WithOpenApi();


    }
}
