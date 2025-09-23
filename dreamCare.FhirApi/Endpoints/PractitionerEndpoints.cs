using dreamCare.FhirApi.FhirServices;
using Hl7.Fhir.Model;

namespace dreamCare.FhirApi.Endpoints;

public static class PractitionerEndpoints
{
    public static void MapPractitionerEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/fhir/Practitioner").WithTags(nameof(Practitioner));

        group.MapGet("/{id}", (Id practitionerId, Practitioner inputPractitioner, PractitionerFhirService practitionerFhirService) =>
        {
            var returnedPractitioner = practitionerFhirService.GetPractitionerById(practitionerId);
            return TypedResults.Ok(returnedPractitioner);
        })
        .WithName("GetPractitionerById")
        .WithOpenApi();

        group.MapPut("/{id}", (Id practitionerId, Practitioner inputPractitioner, PractitionerFhirService practitionerFhirService) =>
        {
            var returnedPractitioner = practitionerFhirService.UpdatePractitioner(inputPractitioner);
            return TypedResults.Ok(returnedPractitioner);
        })
        .WithName("UpdatePatientById")
        .WithOpenApi();

        group.MapPost("/", (Practitioner inputPractitioner, PractitionerFhirService practitionerFhirService) =>
        {
            var returnedPractitioner = practitionerFhirService.CreatePractitioner(inputPractitioner);
            return TypedResults.Created($"/fhir/Practitioner/{returnedPractitioner.Id}", returnedPractitioner);
        })
        .WithName("CreatePatient")
        .WithOpenApi();
    }
}
