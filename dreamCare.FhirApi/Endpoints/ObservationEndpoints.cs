
using dreamCare.FhirApi.FhirServices;
using Hl7.Fhir.Model;

namespace dreamCare.FhirApi.Endpoints;

public static class ObservationEndpoints
{
    public static void MapObservationEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/fhir/Observation").WithTags(nameof(Observation));

        group.MapGet("/{id}", (Id observationId, Observation inputObservation, ObservationFhirService observationFhirService) =>
        {
            var returnedObservation = observationFhirService.GetObservationById(observationId);
            return TypedResults.Ok(returnedObservation);
        })
        .WithName("GetObservationById")
        .WithOpenApi();

        group.MapPut("/{id}", (Id observationId, Observation inputObservation, ObservationFhirService observationFhirService) =>
        {
            var returnedObservation = observationFhirService.UpdateObservation(inputObservation);
            return TypedResults.Ok(returnedObservation);
        })
        .WithName("UpdateObservation")
        .WithOpenApi();

        group.MapPost("/", (Observation inputObservation, ObservationFhirService observationFhirService) =>
        {
            var returnedObservation = observationFhirService.CreateObservation(inputObservation);
            return TypedResults.Created($"/fhir/Observation/{returnedObservation.Id}", returnedObservation);
        })
        .WithName("CreateObservation")
        .WithOpenApi();
    }
}
