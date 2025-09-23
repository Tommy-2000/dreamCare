
using dreamCare.FhirApi.FhirServices;
using Hl7.Fhir.Model;

namespace dreamCare.FhirApi.Endpoints;

public static class ConditionEndpoints
{
    public static void MapConditionEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/fhir/Condition").WithTags(nameof(Condition));

        group.MapGet("/{id}", (Id conditionId, Condition inputCondition, ConditionFhirService conditionFhirService) =>
        {
            var returnedCondition = conditionFhirService.GetConditionById(conditionId);
            return TypedResults.Ok(returnedCondition);
        })
        .WithName("GetConditionById")
        .WithOpenApi();

        group.MapPut("/{id}", (Id conditionId, Condition inputCondition, ConditionFhirService conditionFhirService) =>
        {
            var returnedCondition = conditionFhirService.UpdateCondition(inputCondition);
            return TypedResults.Ok(returnedCondition);
        })
        .WithName("UpdateCondition")
        .WithOpenApi();

        group.MapPost("/", (Condition inputCondition, ConditionFhirService conditionFhirService) =>
        {
            var returnedCondition = conditionFhirService.CreateCondition(inputCondition);
            return TypedResults.Created($"/fhir/Condition/{returnedCondition.Id}", returnedCondition);
        })
        .WithName("CreateCondition")
        .WithOpenApi();

    }
}
